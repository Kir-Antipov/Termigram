using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class TextMessageProcessor : ResultProcessorBase<TextMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, TextMessage result) =>
            bot.Client.SendTextMessageAsync(command.Update.GetChatIdOrUserId(), result.Text, result.ParseMode, result.DisableWebPagePreview, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup);
    }
}
