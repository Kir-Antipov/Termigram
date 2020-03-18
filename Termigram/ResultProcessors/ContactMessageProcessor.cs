using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class ContactMessageProcessor : ResultProcessorBase<ContactMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, ContactMessage result) =>
            bot.Client.SendContactAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.PhoneNumber, result.Firstname, result.Lastname, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup, default, result.VCard);
    }
}
