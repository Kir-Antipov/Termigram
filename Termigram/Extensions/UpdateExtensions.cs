using System;
using System.Diagnostics.CodeAnalysis;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Termigram.Extensions
{
    public static class UpdateExtensions
    {
        public static bool TryGetText(this Update update, [NotNullWhen(true)]out string? text)
        {
            text = update switch
            {
                { InlineQuery: { Query: { } innerText } } => innerText,
                { ChosenInlineResult: { Query: { } innerText } } => innerText,
                { CallbackQuery: { Data: { } innerText } } => innerText,
                { CallbackQuery: { Message: { Text: { } innerText } } } => innerText,
                { Message: { Text: { } innerText } } => innerText,
                { ChannelPost: { Text: { } innerText } } => innerText,
                { EditedChannelPost: { Text: { } innerText } } => innerText,
                { EditedMessage: { Text: { } innerText } } => innerText,
                _ => default
            };

            return text is { };
        }

        public static string GetText(this Update update) => TryGetText(update, out string? text) ? text : throw new ArgumentException(nameof(update));

        public static bool TryGetChatId(this Update update, [NotNullWhen(true)]out ChatId? chatId)
        {
            chatId = update switch
            {
                { CallbackQuery: { Message: { Chat: { Id: { } id } } } } => id,
                { ChannelPost: { Chat: { Id: { } id } } } => id,
                { EditedChannelPost: { Chat: { Id: { } id } } } => id,
                { EditedMessage: { Chat: { Id: { } id } } } => id,
                { Message: { Chat: { Id: { } id } } } => id,
                _ => default(long?)
            };

            return chatId is { };
        }

        public static ChatId GetChatId(this Update update) => TryGetChatId(update, out ChatId? chatId) ? chatId : throw new ArgumentException(nameof(update));

        public static bool TryGetUser(this Update update, [NotNullWhen(true)]out User? user)
        {
            user = update switch
            {
                { CallbackQuery: { From: { } from } } => from,
                { ChannelPost: { From: { } from } } => from,
                { ChosenInlineResult: { From: { } from } } => from,
                { EditedChannelPost: { From: { } from } } => from,
                { EditedMessage: { From: { } from } } => from,
                { InlineQuery: { From: { } from } } => from,
                { Message: { From: { } from } } => from,
                { PollAnswer: { User: { } from } } => from,
                { PreCheckoutQuery: { From: { } from } } => from,
                { ShippingQuery: { From: { } from } } => from,
                _ => default
            };

            return user is { };
        }

        public static User GetUser(this Update update) => TryGetUser(update, out User? user) ? user : throw new ArgumentException(nameof(update));

        public static bool TryGetUserId(this Update update, [NotNullWhen(true)]out ChatId? chatId)
        {
            if (TryGetUser(update, out User? user))
            {
                chatId = user.Id;
                return true;
            }
            else
            {
                chatId = default;
                return false;
            }
        }

        public static ChatId GetUserId(this Update update) => TryGetUserId(update, out ChatId? chatId) ? chatId : throw new ArgumentException(nameof(update));

        public static bool TryGetChatIdOrUserId(this Update update, [NotNullWhen(true)]out ChatId? id)
        {
            if (TryGetChatId(update, out id) || TryGetUserId(update, out id))
                return true;

            id = default;
            return false;
        }

        public static ChatId GetChatIdOrUserId(this Update update) => TryGetChatIdOrUserId(update, out ChatId? id) ? id : throw new ArgumentException(nameof(update));

        public static bool TryGetUsername(this Update update, [NotNullWhen(true)]out string? username)
        {
            username = TryGetUser(update, out User? user) ? user.Username : default;
            return username is { };
        }

        public static string GetUsername(this Update update) => TryGetUsername(update, out string? username) ? username : throw new ArgumentException(nameof(update));

        public static bool TryGetMessage(this Update update, [NotNullWhen(true)]out Message? message)
        {
            message = update switch
            {
                { ChannelPost: { } msg } => msg,
                { EditedChannelPost: { } msg } => msg,
                { Message: { } msg } => msg,
                { EditedMessage: { } msg } => msg,
                _ => default
            };

            return message is { };
        }

        public static Message GetMessage(this Update update) => TryGetMessage(update, out Message? message) ? message : throw new ArgumentException(nameof(update));
    }
}
