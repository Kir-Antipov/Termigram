using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class VenueMessage
    {
		#region Var
		public float Latitude { get; }
		public float Longitude { get; }
		public string Title { get; }
		public string Address { get; }
		public string? FoursquareId { get; }
		public string? FoursquareType { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public ChatId? ChatId { get; }
		#endregion

		#region Init
		public VenueMessage(float latitude, float longitude, string title, string address, string? foursquareId = null, string? foursquareType = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
		{
			Latitude = latitude;
			Longitude = longitude;
			Title = title;
			Address = address;
			FoursquareId = foursquareId;
			FoursquareType = foursquareType;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
			ChatId = chatId;
		}
		#endregion
	}
}
