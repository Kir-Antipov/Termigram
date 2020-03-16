using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.Messages
{
	public class AnimationMessage
	{
		#region Var
		public InputOnlineFile Animation { get; }
		public int Duration { get; }
		public int Width { get; }
		public int Height { get; }
		public InputMedia? Thumb { get; }
		public string? Caption { get; }
		public ParseMode ParseMode { get; }
		public int ReplyToMessageId { get; }
		public bool DisableNotification { get; }
		public IReplyMarkup? ReplyMarkup { get; }
		#endregion

		#region Init
		public AnimationMessage(InputOnlineFile animation, int duration = 0, int width = 0, int height = 0, InputMedia? thumb = null, string? caption = null, ParseMode? parseMode = null, int replyToMessageId = 0, bool disableNotification = false, IReplyMarkup replyMarkup = null)
		{
			Animation = animation;
			Duration = duration;
			Width = width;
			Height = height;
			Thumb = thumb;
			Caption = caption;
			ParseMode = parseMode ?? ParseModeExtensions.RecognizeSuitableParseMode(caption);
			ReplyToMessageId = replyToMessageId;
			DisableNotification = disableNotification;
			ReplyMarkup = replyMarkup;
		}
		#endregion

		#region Functions
		public override string ToString() => Caption ?? base.ToString();
		#endregion
	}
}
