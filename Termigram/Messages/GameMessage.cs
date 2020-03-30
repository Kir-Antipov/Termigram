using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class GameMessage : IMessage<string>, ISilentMessage, IReplyMessage, IMarkupMessage
    {
		#region Var
		public string GameShortName { get; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public InlineKeyboardMarkup? ReplyMarkup { get; }
		public ChatId? ChatId { get; }

		string IMessage<string>.Content => GameShortName;
		IReplyMarkup? IMarkupMessage.ReplyMarkup => ReplyMarkup;
		#endregion

		#region Init
		public GameMessage(string gameShortName, bool disableNotification = false, int replyToMessageId = 0, InlineKeyboardMarkup? replyMarkup = null, ChatId? chatId = null)
		{
			GameShortName = gameShortName;
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
			ChatId = chatId;
		}
		#endregion
	}
}
