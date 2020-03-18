using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class VideoNoteMessageProcessor : ResultProcessorBase<VideoNoteMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, VideoNoteMessage result) =>
            bot.Client.SendVideoNoteAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.VideoNote, result.Duration, result.Length, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup, default, result.Thumb);
    }
}
