using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Termigram.CommandInfos;
using Termigram.Commands;
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
        #endregion

        #region Init
        protected BotBase(IOptions options)
        {
            Options = options;
            Client = options.Proxy is { } ? new TelegramBotClient(options.Token, options.Proxy) : new TelegramBotClient(options.Token, options.HttpClient);
            Commands = options.CommandExtractor.ExtractCommands(GetType(), out DefaultCommand);
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

        private async void OnUpdate(object sender, UpdateEventArgs e) => await OnUpdateAsync((ITelegramBotClient)sender, e);

        protected virtual async Task OnUpdateAsync(ITelegramBotClient sender, UpdateEventArgs e)
        {
            if (!TryParseCommand(e.Update, out ICommand? command))
                return;

            if (!TryLinkCommand(command, out ICommandInfo? commandInfo))
                return;

            try
            {
                object? result = await InvokeCommandAsync(command, commandInfo);

                if (await TryProcessResultAsync(command, result))
                    return;

                if (result is IEnumerable enumerable)
                {
                    foreach (object? subResult in enumerable)
                        await TryProcessResultAsync(command, subResult);
                }
                else if (result is IAsyncEnumerable<object?> asyncEnumerable)
                {
                    await foreach (object? subResult in asyncEnumerable)
                        await TryProcessResultAsync(command, subResult);
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
            commandInfo = default;
            for (int i = 0; i < Options.Linkers.Count; ++i)
                for (int j = 0; j < Commands.Length; ++j)
                    if (Options.Linkers[i].CanBeLinked(command, Commands[j]))
                    {
                        commandInfo = Commands[j];
                        return true;
                    }

            if (DefaultCommand is { })
            {
                commandInfo = DefaultCommand;
                return true;
            }

            return false;
        }

        protected virtual async Task<object?> InvokeCommandAsync(ICommand command, ICommandInfo commandInfo)
        {
            try
            {
                object? result = Options.CommandInvoker.Invoke(command, commandInfo, this);

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

        protected virtual async Task<bool> TryProcessResultAsync(ICommand command, object? result)
        {
            for (int i = 0; i < Options.ResultProcessors.Count; ++i)
                if (await Options.ResultProcessors[i].TryProcessResultAsync(this, command, result))
                    return true;

            return false;
        }

        public override bool Equals(object obj) => obj is IBot bot && bot.Options.Token == Options.Token;
        public override int GetHashCode() => Options.Token.GetHashCode();
        public override string ToString() => Options.Token;
        #endregion
    }
}
