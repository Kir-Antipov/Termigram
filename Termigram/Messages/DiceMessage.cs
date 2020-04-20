using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class DiceMessage : IMessage, ISilentMessage, IReplyMessage, IMarkupMessage
    {
		public ChatId? ChatId { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }

		public static readonly DiceMessage Dice = new DiceMessage();

		public DiceMessage(ChatId? chatId = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null)
		{
			ChatId = chatId;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
		}
	}
}
