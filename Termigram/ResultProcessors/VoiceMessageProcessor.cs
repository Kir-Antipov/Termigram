using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class VoiceMessageProcessor : ResultProcessorBase<VoiceMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, VoiceMessage result) =>
            bot.Client.SendVoiceAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.Voice, result.Caption, result.ParseMode, result.Duration, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup);
    }
}
