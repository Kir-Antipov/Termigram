using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class VoiceMessage
    {
		#region Var
		public InputOnlineFile Voice { get; }
		public int Duration { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		#endregion

		#region Init
		public VoiceMessage(InputOnlineFile voice, int duration = 0, string? caption = null, ParseMode? parseMode = null, int replyToMessageId = 0, bool disableNotification = false, IReplyMarkup? replyMarkup = null)
		{
			Voice = voice;
			Duration = duration;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
		}
		#endregion
	}
}
