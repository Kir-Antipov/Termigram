using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class AudioMessageProcessor : ResultProcessorBase<AudioMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, AudioMessage result) =>
            bot.Client.SendAudioAsync(command.Update.GetChatIdOrUserId(), result.Audio, result.Caption, result.ParseMode, result.Duration, result.Performer, result.Title, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup, default, result.Thumb);
    }
}
