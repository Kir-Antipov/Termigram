using System.Collections.Generic;
using Telegram.Bot.Types;

namespace Termigram.Messages
{
	public class MediaGroupMessage : IMessage, ISilentMessage, IReplyMessage
    {
		#region Var
		public IEnumerable<IAlbumInputMedia> MediaGroup { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		public ChatId? ChatId { get; }
		#endregion

		#region Init
		public MediaGroupMessage(params IAlbumInputMedia[] mediaGroup) : this((IEnumerable<IAlbumInputMedia>)mediaGroup) { }

		public MediaGroupMessage(IEnumerable<IAlbumInputMedia> mediaGroup, bool disableNotification = false, int replyToMessageId = 0, ChatId? chatId = null)
		{
			MediaGroup = mediaGroup;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ChatId = chatId;
		}
		#endregion
	}
}
