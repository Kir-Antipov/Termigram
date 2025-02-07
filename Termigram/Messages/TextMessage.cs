﻿using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
    public class TextMessage : IMessage<string>, ISilentMessage, IReplyMessage, IMarkupMessage
    {
        #region Var
        public string Text { get; }
        public ParseMode ParseMode { get; }
        public bool DisableWebPagePreview { get; }
        public bool DisableNotification { get; }
        public int ReplyToMessageId { get; }
        public IReplyMarkup? ReplyMarkup { get; }
        public ChatId? ChatId { get; }

        string IMessage<string>.Content => Text;
        #endregion

        #region Init
        public TextMessage(string text, ParseMode? parseMode = null, bool disableWebPagePreview = false, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
        {
            Text = text;
            ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(text);
            DisableWebPagePreview = disableWebPagePreview;
            DisableNotification = disableNotification;
            ReplyToMessageId = replyToMessageId;
            ReplyMarkup = replyMarkup;
            ChatId = chatId;
        }
        #endregion

        #region Functions
        public static implicit operator string(TextMessage message) => message.Text;
        public static implicit operator TextMessage(string text) => new TextMessage(text);

        public override string ToString() => Text;
        public override int GetHashCode() => Text.GetHashCode();
        public override bool Equals(object? obj) => obj is TextMessage message && Text == message.Text;
        #endregion
    }
}
