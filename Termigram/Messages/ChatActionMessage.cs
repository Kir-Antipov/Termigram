using Telegram.Bot.Types.Enums;

namespace Termigram.Messages
{
	public class ChatActionMessage
    {
		#region Var
		public ChatAction ChatAction { get; }
		#endregion

		#region Init
		public ChatActionMessage(ChatAction chatAction) => ChatAction = chatAction;
		#endregion

		#region Functions
		public static implicit operator ChatAction(ChatActionMessage message) => message.ChatAction;
		public static implicit operator ChatActionMessage(ChatAction chatAction) => new ChatActionMessage(chatAction);
		#endregion
	}
}
