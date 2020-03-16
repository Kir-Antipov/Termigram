using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class MediaGroupMessageProcessor : ResultProcessorBase<MediaGroupMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, MediaGroupMessage result) =>
            bot.Client.SendMediaGroupAsync(result.MediaGroup, command.Update.GetChatIdOrUserId(), result.DisableNotification, result.ReplyToMessageId);
    }
}
