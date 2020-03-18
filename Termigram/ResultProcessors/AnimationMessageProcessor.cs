using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class AnimationMessageProcessor : ResultProcessorBase<AnimationMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, AnimationMessage result) =>
            bot.Client.SendAnimationAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.Animation, result.Duration, result.Width, result.Height, result.Thumb, result.Caption, result.ParseMode, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup);
    }
}
