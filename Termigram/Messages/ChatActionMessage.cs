using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Termigram.Messages
{
	public class ChatActionMessage
    {
		#region Var
		public ChatAction ChatAction { get; }
		public ChatId? ChatId { get; }
		#endregion

		#region Init
		public ChatActionMessage(ChatAction chatAction, ChatId? chatId = null)
		{
			ChatAction = chatAction;
			ChatId = chatId;
		}
		#endregion

		#region Functions
		public static implicit operator ChatAction(ChatActionMessage message) => message.ChatAction;
		public static implicit operator ChatActionMessage(ChatAction chatAction) => new ChatActionMessage(chatAction);
		#endregion
	}
}
