using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class VideoMessageProcessor : ResultProcessorBase<VideoMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, VideoMessage result) =>
            bot.Client.SendVideoAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.Video, result.Duration, result.Width, result.Height, result.Caption, result.ParseMode, result.SupportsStreaming, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup, default, result.Thumb);
    }
}
