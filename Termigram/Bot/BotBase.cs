using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Options;

namespace Termigram.Bot
{
    public abstract class BotBase : IBot
    {
        #region Var
        public IOptions Options { get; }
        public ITelegramBotClient Client { get; }

        protected readonly ICommandInfo[] Commands;
        protected readonly ICommandInfo? DefaultCommand;

        private readonly ConcurrentDictionary<int, TaskCompletionSource<Update?>> AwaitingUpdateFromUser;
        private readonly ConcurrentDictionary<(long, int), TaskCompletionSource<Update?>> AwaitingUpdateFromChatUser;
        #endregion

        #region Init
        protected BotBase(IOptions options)
        {
            Options = options;
            Client = options.Proxy is { } ? new TelegramBotClient(options.Token, options.Proxy) : new TelegramBotClient(options.Token, options.HttpClient);
            Commands = options.CommandExtractor.ExtractCommands(GetType(), out DefaultCommand);

            AwaitingUpdateFromUser = new ConcurrentDictionary<int, TaskCompletionSource<Update?>>();
            AwaitingUpdateFromChatUser = new ConcurrentDictionary<(long, int), TaskCompletionSource<Update?>>();
        }
        #endregion

        #region Functions
        public virtual async Task RunAsync(CancellationToken cancellationToken = default)
        {
            Client.OnUpdate += OnUpdate;
            Client.StartReceiving(Options.AllowedUpdates?.ToArray(), cancellationToken);
            while (!cancellationToken.IsCancellationRequested)
                await Task.Delay(Options.CancellationCheckInterval);
            Client.StopReceiving();
            Client.OnUpdate -= OnUpdate;
        }

        private async void OnUpdate(object sender, UpdateEventArgs e) => await OnUpdateAsync((ITelegramBotClient)sender, e.Update);

        protected virtual async Task OnUpdateAsync(ITelegramBotClient sender, Update update)
        {
            if (TrySetResult(update))
                return;

            if (!TryParseCommand(update, out ICommand? command))
                return;

            if (!TryLinkCommand(command, out ICommandInfo? commandInfo))
                return;

            try
            {
                object? result = await InvokeCommandAsync(command, commandInfo);

                if (await TryProcessResultAsync(command, result))
                    return;

                if (result is IEnumerable enumerable)
                    result = enumerable.Cast<object?>().AsAsyncEnumerable();

                if (result is IAsyncEnumerable<object?> asyncEnumerable)
                {
                    DateTime lastMessageSent = DateTime.Now.AddSeconds(-1);
                    await foreach (object? subResult in asyncEnumerable)
                    {
                        // Only one message per second in one chat
                        // https://core.telegram.org/bots/faq#my-bot-is-hitting-limits-how-do-i-avoid-this
                        const int millisecondsPerSecond = 1000;
                        int delay = millisecondsPerSecond - (int)(DateTime.Now - lastMessageSent).TotalMilliseconds;
                        if (delay > 0 && delay <= millisecondsPerSecond)
                            await Task.Delay(delay);

                        await TryProcessResultAsync(command, subResult);
                        lastMessageSent = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                await TryProcessResultAsync(command, ex);
            }
        }

        protected virtual bool TryParseCommand(Update update, [NotNullWhen(true)]out ICommand? command)
        {
            command = default;
            for (int i = 0; i < Options.Parsers.Count; ++i)
                if (Options.Parsers[i].TryParse(update, out command))
                    return true;

            return false;
        }

        protected virtual bool TryLinkCommand(ICommand command, [NotNullWhen(true)]out ICommandInfo? commandInfo)
        {
            commandInfo = Commands
                .Select(info => (CommandInfo: info, Compatibility: Options.Linkers.Max(linker => linker.GetCompatibility(command, info, Options.Converters, Options.DefaultValueProviders, Options.SpecialValueProviders))))
                .Where(x => x.Compatibility > 0)
                .OrderByDescending(x => x.Compatibility)
                .FirstOrDefault().CommandInfo;

            commandInfo ??= DefaultCommand;

            return commandInfo is { };
        }

        protected virtual async Task<object?> InvokeCommandAsync(ICommand command, ICommandInfo commandInfo)
        {
            try
            {
                object? result = Options.CommandInvoker.Invoke(command, commandInfo, this, Options.Converters, Options.DefaultValueProviders, Options.SpecialValueProviders);

                if (result is Task task)
                {
                    await task;
                    PropertyInfo resultProperty = task.GetType().GetProperty(nameof(Task<bool>.Result));
                    result = resultProperty is { } ? resultProperty.GetValue(task) : default;
                }

                return result;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        protected virtual ReplyKeyboardMarkup GenerateReplyKeyboardMarkup(params string[] methodNames) =>
            GenerateReplyKeyboardMarkup(itemsInRow: 2, methodNames: methodNames);
        
        protected virtual ReplyKeyboardMarkup GenerateReplyKeyboardMarkup(int itemsInRow = 2, bool resizeKeyboard = true, bool oneTimeKeyboard = false, params string[] methodNames) =>
            GenerateReplyKeyboardMarkup(methodNames.Batch(itemsInRow), resizeKeyboard, oneTimeKeyboard);

        protected virtual ReplyKeyboardMarkup GenerateReplyKeyboardMarkup(IEnumerable<IEnumerable<string>> commandNames, bool resizeKeyboard = true, bool oneTimeKeyboard = false) =>
            new ReplyKeyboardMarkup(commandNames.Select(row => row.Select(commandName => new KeyboardButton(Commands.First(x => x.Method.Name == commandName).Name))), resizeKeyboard, oneTimeKeyboard);
        
        protected virtual InlineKeyboardMarkup GenerateInlineKeyboardMarkup(params string[] methodNames) =>
            GenerateInlineKeyboardMarkup(itemsInRow: 2, methodNames: methodNames);
        
        protected virtual InlineKeyboardMarkup GenerateInlineKeyboardMarkup(int itemsInRow = 2, params string[] methodNames) =>
            GenerateInlineKeyboardMarkup(methodNames.Batch(itemsInRow));

        protected virtual InlineKeyboardMarkup GenerateInlineKeyboardMarkup(IEnumerable<IEnumerable<string>> commandNames) =>
            new InlineKeyboardMarkup(commandNames.Select(row => row.Select(commandName => Commands.First(x => x.Method.Name == commandName).Name).Select(commandName => new InlineKeyboardButton { Text = commandName, CallbackData = commandName })));

        protected virtual async Task<bool> TryProcessResultAsync(ICommand command, object? result)
        {
            for (int i = 0; i < Options.ResultProcessors.Count; ++i)
                if (await Options.ResultProcessors[i].TryProcessResultAsync(this, command, result))
                    return true;

            return false;
        }

        protected virtual Task<Update?> WaitForUpdateAsync(User user, CancellationToken cancellationToken = default) =>
            WaitForResultAsync(AwaitingUpdateFromUser, user.Id, cancellationToken);

        protected virtual Task<Update?> WaitForUpdateAsync(ChatId chat, User user, CancellationToken cancellationToken = default) =>
            WaitForResultAsync(AwaitingUpdateFromChatUser, (chat.Identifier, user.Id), cancellationToken);

        protected virtual async Task<string?> WaitForAnswerAsync(User user, CancellationToken cancellationToken = default)
        {
            Update? update = await WaitForUpdateAsync(user, cancellationToken);
            if (update is null)
                return null;

            update.TryGetText(out string? result);
            return result;
        }

        protected virtual async Task<string?> WaitForAnswerAsync(ChatId chat, User user, CancellationToken cancellationToken = default)
        {
            Update? update = await WaitForUpdateAsync(chat, user, cancellationToken);
            if (update is null)
                return null;

            update.TryGetText(out string? result);
            return result;
        }

        private static Task<TResult> WaitForResultAsync<TKey, TResult>(ConcurrentDictionary<TKey, TaskCompletionSource<TResult>> dictionary, TKey key, CancellationToken cancellationToken)
        {
            const int maxDelay_ms = 10 * 60 * 1000; // 10 minutes in ms

            TaskCompletionSource<TResult> updateSource = new TaskCompletionSource<TResult>();

            if (!cancellationToken.CanBeCanceled)
                cancellationToken = new CancellationTokenSource(maxDelay_ms).Token;

            cancellationToken.Register(() =>
            {
                dictionary.TryRemove(key, out _);
                updateSource.TrySetResult(default!);
            });

            dictionary.AddOrUpdate(key, updateSource, (a, b) => updateSource);
            return updateSource.Task;
        }

        private bool TrySetResult(Update update)
        {
            if (update.TryGetUser(out User? user))
            {
                if (update.TryGetChatId(out ChatId? chatId) && AwaitingUpdateFromChatUser.TryRemove((chatId.Identifier, user.Id), out TaskCompletionSource<Update?> updateChatSource))
                {
                    updateChatSource.TrySetResult(update);
                    return true;
                }

                if (AwaitingUpdateFromUser.TryRemove(user.Id, out TaskCompletionSource<Update?> updateSource))
                {
                    updateSource.TrySetResult(update);
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj) => obj is IBot bot && bot.Options.Token == Options.Token;
        public override int GetHashCode() => Options.Token.GetHashCode();
        public override string ToString() => Options.Token;
        #endregion
    }
}
