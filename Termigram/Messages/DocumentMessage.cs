using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class DocumentMessage
    {
		#region Var
		public InputOnlineFile Document { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; set; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public InputMedia? Thumb { get; }
		#endregion

		#region Init
		public DocumentMessage(InputOnlineFile document, string? caption = null, ParseMode? parseMode = null, int replyToMessageId = 0, bool disableNotification = false, IReplyMarkup? replyMarkup = null, InputMedia? thumb = null)
		{
			Document = document;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
			Thumb = thumb;
		}
		#endregion

	}
}
