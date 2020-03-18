using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class ChatActionMessageProcessor : ResultProcessorBase<ChatActionMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, ChatActionMessage result) =>
            bot.Client.SendChatActionAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.ChatAction);
    }
}
