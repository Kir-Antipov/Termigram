using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class ContactMessage : IMessage, ISilentMessage, IReplyMessage, IMarkupMessage
    {
		#region Var
		public string PhoneNumber { get; }
		public string Firstname { get; }
		public string? Lastname { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public string? VCard { get; }
		public ChatId? ChatId { get; }
		#endregion

		#region Init
		public ContactMessage(string phoneNumber, string firstname, string? lastname = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, string? vCard = null, ChatId? chatId = null)
		{
			PhoneNumber = phoneNumber;
			Firstname = firstname;
			Lastname = lastname;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
			VCard = vCard;
			ChatId = chatId;
		}
		#endregion
	}
}
