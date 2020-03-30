using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class VideoMessage : IMediaMessage, IMediaThumbMessage, IPlayableMediaMessage
	{
		#region Var
		public InputOnlineFile Video { get; }
		public int Duration { get; }
		public int Width { get; }
		public int Height { get; }
		public InputMedia? Thumb { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; }
		public bool SupportsStreaming { get; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		public ChatId? ChatId { get; }

		InputOnlineFile IMessage<InputOnlineFile>.Content => Video;
		#endregion

		#region Init
		public VideoMessage(string video, int duration = 0, int width = 0, int height = 0, InputMedia? thumb = null, string? caption = null, ParseMode? parseMode = null, bool supportsStreaming = false, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
			: this(new InputOnlineFile(video), duration, width, height, thumb, caption, parseMode, supportsStreaming, disableNotification, replyToMessageId, replyMarkup, chatId) { }

		public VideoMessage(InputOnlineFile video, int duration = 0, int width = 0, int height = 0, InputMedia? thumb = null, string? caption = null, ParseMode? parseMode = null, bool supportsStreaming = false, bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup? replyMarkup = null, ChatId? chatId = null)
		{
			Video = video;
			Duration = duration;
			Width = width;
			Height = height;
			Thumb = thumb;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			SupportsStreaming = supportsStreaming;
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
			ChatId = chatId;
		}
		#endregion
	}
}
