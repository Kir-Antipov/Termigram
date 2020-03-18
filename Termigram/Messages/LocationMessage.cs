using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class LocationMessage
    {
		#region Var
		public float Latitude { get; }
		public float Longitude { get; }
		public int LivePeriod { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public ChatId? ChatId { get; }
		#endregion

		#region Init
		public LocationMessage(float latitude, float longitude, int livePeriod = 0, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
		{
			Latitude = latitude;
			Longitude = longitude;
			LivePeriod = livePeriod;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
			ChatId = chatId;
		}
		#endregion
	}
}
