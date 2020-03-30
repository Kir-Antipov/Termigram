using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class VoiceMessage : IMediaMessage, IPlayableMediaMessage
	{
		#region Var
		public InputOnlineFile Voice { get; }
		public int Duration { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public ChatId? ChatId { get; }

		InputOnlineFile IMessage<InputOnlineFile>.Content => Voice;
		#endregion

		#region Init
		public VoiceMessage(string voice, int duration = 0, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
			: this(new InputOnlineFile(voice), duration, caption, parseMode, disableNotification, replyToMessageId, replyMarkup, chatId) { }

		public VoiceMessage(InputOnlineFile voice, int duration = 0, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
		{
			Voice = voice;
			Duration = duration;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
			ChatId = chatId;
		}
		#endregion
	}
}
