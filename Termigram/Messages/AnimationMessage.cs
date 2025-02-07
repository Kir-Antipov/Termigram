﻿using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class AnimationMessage : IMediaMessage, IMediaThumbMessage, IPlayableMediaMessage
	{
		#region Var
		public InputOnlineFile Animation { get; }
		public int Duration { get; }
		public int Width { get; }
		public int Height { get; }
		public InputMedia? Thumb { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public ChatId? ChatId { get; }

		InputOnlineFile IMessage<InputOnlineFile>.Content => Animation;
		#endregion

		#region Init
		public AnimationMessage(string animation, int duration = 0, int width = 0, int height = 0, InputMedia? thumb = null, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
			: this(new InputOnlineFile(animation), duration, width, height, thumb, caption, parseMode, disableNotification, replyToMessageId, replyMarkup, chatId) { }

		public AnimationMessage(InputOnlineFile animation, int duration = 0, int width = 0, int height = 0, InputMedia? thumb = null, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
		{
			Animation = animation;
			Duration = duration;
			Width = width;
			Height = height;
			Thumb = thumb;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
			ChatId = chatId;
		}
		#endregion

		#region Functions
		public override string ToString() => Caption ?? base.ToString();
		#endregion
	}
}
