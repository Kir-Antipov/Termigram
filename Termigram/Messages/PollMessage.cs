using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class PollMessage : IMessage<string>, ISilentMessage, IReplyMessage, IMarkupMessage
    {
		#region Var
		public string Question { get; }
		public IEnumerable<string> Options { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public bool? IsAnonymous { get; }
		public PollType? Type { get; }
		public bool? AllowsMultipleAnswers { get; }
		public int? CorrectOptionId { get; }
		public bool? IsClosed { get; }
		public ChatId? ChatId { get; }

		string IMessage<string>.Content => Question;
		#endregion

		#region Init
		public PollMessage(string question, params string[] options) : this(question, options, false) { }

		public PollMessage(string question, IEnumerable<string> options, bool? isAnonymous = null, PollType? type = null, bool? allowsMultipleAnswers = null, int? correctOptionId = null, bool? isClosed = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
		{
			Question = question;
			Options = options;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
			IsAnonymous = isAnonymous;
			Type = type;
			AllowsMultipleAnswers = allowsMultipleAnswers;
			CorrectOptionId = correctOptionId;
			IsClosed = isClosed;
			ChatId = chatId;
		}
		#endregion
	}
}
