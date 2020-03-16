using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class StickerMessage
    {
		#region Var
		public InputOnlineFile Sticker { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		#endregion

		#region Init
		public StickerMessage(InputOnlineFile sticker, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null)
		{
			Sticker = sticker;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
		}
		#endregion
	}
}
