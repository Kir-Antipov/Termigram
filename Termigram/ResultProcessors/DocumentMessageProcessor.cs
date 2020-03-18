using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class DocumentMessageProcessor : ResultProcessorBase<DocumentMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, DocumentMessage result) =>
            bot.Client.SendDocumentAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.Document, result.Caption, result.ParseMode, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup, default, result.Thumb);
    }
}
