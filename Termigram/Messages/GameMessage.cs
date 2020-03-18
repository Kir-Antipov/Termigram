using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class GameMessage
    {
		#region Var
		public string GameShortName { get; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public InlineKeyboardMarkup? ReplyMarkup { get; }
		public ChatId? ChatId { get; }
		#endregion

		#region Init
		public GameMessage(string gameShortName, int replyToMessageId = 0, bool disableNotification = false, InlineKeyboardMarkup? replyMarkup = null, ChatId? chatId = null)
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
