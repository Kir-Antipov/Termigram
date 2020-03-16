using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;

namespace Termigram.ResultProcessors
{
    public class ChatActionProcessor : ResultProcessorBase<ChatAction>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, ChatAction result) =>
            bot.Client.SendChatActionAsync(command.Update.GetChatIdOrUserId(), result);
    }
}
