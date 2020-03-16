using System.Collections.Generic;
using Telegram.Bot.Types;

namespace Termigram.Messages
{
	public class MediaGroupMessage
    {
		#region Var
		public IEnumerable<IAlbumInputMedia> MediaGroup { get; }
		public bool DisableNotification { get; }
		public int ReplyToMessageId { get; }
		#endregion

		#region Init
		public MediaGroupMessage(params IAlbumInputMedia[] mediaGroup) : this((IEnumerable<IAlbumInputMedia>)mediaGroup) { }

		public MediaGroupMessage(IEnumerable<IAlbumInputMedia> mediaGroup, bool disableNotification = false, int replyToMessageId = 0)
		{
			MediaGroup = mediaGroup;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
		}
		#endregion
	}
}
