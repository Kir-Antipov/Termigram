using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class PhotoMessageProcessor : ResultProcessorBase<PhotoMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, PhotoMessage result) =>
            bot.Client.SendPhotoAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.Photo, result.Caption, result.ParseMode, result.DisableNotification, result.ReplyToMessageId);
    }
}
