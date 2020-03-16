using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class LocationMessageProcessor : ResultProcessorBase<LocationMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, LocationMessage result) =>
            bot.Client.SendLocationAsync(command.Update.GetChatIdOrUserId(), result.Latitude, result.Longitude, result.LivePeriod, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup);
    }
}
