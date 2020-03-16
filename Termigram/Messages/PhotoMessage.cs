using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class PhotoMessage
    {
		#region Var
		public InputOnlineFile Photo { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; set; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		#endregion

		#region Init
		public PhotoMessage(InputOnlineFile photo, string? caption = null, ParseMode? parseMode = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null)
		{
			Photo = photo;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
		}
		#endregion
	}
}
