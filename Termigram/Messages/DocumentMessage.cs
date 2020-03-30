using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class DocumentMessage : IMediaMessage, IMediaThumbMessage
	{
		#region Var
		public InputOnlineFile Document { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; set; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public InputMedia? Thumb { get; }
		public ChatId? ChatId { get; }

		InputOnlineFile IMessage<InputOnlineFile>.Content => Document;
		#endregion

		#region Init
		public DocumentMessage(string document, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, InputMedia? thumb = null, ChatId? chatId = null)
			: this(new InputOnlineFile(document), caption, parseMode, disableNotification, replyToMessageId, replyMarkup, thumb, chatId) { }

		public DocumentMessage(InputOnlineFile document, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, InputMedia? thumb = null, ChatId? chatId = null)
		{
			Document = document;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
			Thumb = thumb;
			ChatId = chatId;
		}
		#endregion
	}
}
