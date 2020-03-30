using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class PhotoMessage : IMediaMessage
    {
		#region Var
		public InputOnlineFile Photo { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; set; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public ChatId? ChatId { get; }

		InputOnlineFile IMessage<InputOnlineFile>.Content => Photo;
		#endregion

		#region Init
		public PhotoMessage(string photo, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
			: this(new InputOnlineFile(photo), caption, parseMode, disableNotification, replyToMessageId, replyMarkup, chatId) { }

		public PhotoMessage(InputOnlineFile photo, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
		{
			Photo = photo;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
			ChatId = chatId;
		}
		#endregion
	}
}
