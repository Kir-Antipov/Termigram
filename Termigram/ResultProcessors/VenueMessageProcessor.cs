using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class VenueMessageProcessor : ResultProcessorBase<VenueMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, VenueMessage result) =>
            bot.Client.SendVenueAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.Latitude, result.Longitude, result.Title, result.Address, result.FoursquareId, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup, default, result.FoursquareType);
    }
}
