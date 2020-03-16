using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class VideoNoteMessage
    {
		#region Var
		public InputTelegramFile VideoNote { get; }
		public int Duration { get; }
		public int Length { get; }
		public InputMedia? Thumb { get; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		#endregion

		#region Init
		public VideoNoteMessage(InputTelegramFile videoNote, int duration = 0, int length = 0, InputMedia? thumb = null, int replyToMessageId = 0, bool disableNotification = false, IReplyMarkup? replyMarkup = null)
		{
			VideoNote = videoNote;
			Duration = duration;
			Length = length;
			Thumb = thumb;
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
		}
		#endregion
	}
}
