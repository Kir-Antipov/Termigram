using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class GameMessageProcessor : ResultProcessorBase<GameMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, GameMessage result) =>
            bot.Client.SendGameAsync(command.Update.GetChatId().Identifier, result.GameShortName, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup);
    }
}
