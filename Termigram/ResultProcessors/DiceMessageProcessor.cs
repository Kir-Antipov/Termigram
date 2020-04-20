using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class DiceMessageProcessor : ResultProcessorBase<DiceMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, DiceMessage result) =>
            bot.Client.SendDiceAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup);
    }
}
