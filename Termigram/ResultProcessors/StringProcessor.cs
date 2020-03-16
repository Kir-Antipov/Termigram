using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class StringProcessor : ResultProcessorBase<string>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, string result)
        {
            TextMessage message = result;

            return bot.Client.SendTextMessageAsync(command.Update.GetChatIdOrUserId(), message.Text, message.ParseMode, message.DisableWebPagePreview, message.DisableNotification, message.ReplyToMessageId, message.ReplyMarkup);
        }
    }
}
