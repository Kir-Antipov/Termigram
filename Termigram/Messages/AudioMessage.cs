using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class AudioMessage
    {
		#region Var
		public InputOnlineFile Audio { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; }
		public int Duration { get; }
		public string? Performer { get; }
		public string? Title { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public InputMedia? Thumb { get; }
		#endregion

		#region Init
		public AudioMessage(InputOnlineFile audio, string? caption = null, ParseMode? parseMode = null, int duration = 0, string? performer = null, string? title = null, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, InputMedia? thumb = null)
		{
			Audio = audio;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			Duration = duration;
			Performer = performer;
			Title = title;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
			Thumb = thumb;
		}
		#endregion
	}
}
