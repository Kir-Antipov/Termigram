using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class ContactMessage
    {
		#region Var
		public string PhoneNumber { get; }
		public string Firstname { get; }
		public string? Lastname { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public string? VCard { get; }
		#endregion

		#region Init
		public ContactMessage(string phoneNumber, string firstname, string? lastname = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, string? vCard = null)
		{
			PhoneNumber = phoneNumber;
			Firstname = firstname;
			Lastname = lastname;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
			VCard = vCard;
		}
		#endregion
	}
}
