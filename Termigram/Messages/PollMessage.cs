using System.Collections.Generic;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
	public class PollMessage
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
		#endregion

		#region Init
		public PollMessage(string question, IEnumerable<string> options, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, bool? isAnonymous = null, PollType? type = null, bool? allowsMultipleAnswers = null, int? correctOptionId = null, bool? isClosed = null)
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
		}
		#endregion
	}
}
