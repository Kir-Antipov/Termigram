using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class PollMessageProcessor : ResultProcessorBase<PollMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, PollMessage result) =>
            bot.Client.SendPollAsync(command.Update.GetChatIdOrUserId(), result.Question, result.Options, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup, default, result.IsAnonymous, result.Type, result.AllowsMultipleAnswers, result.CorrectOptionId, result.IsClosed);
    }
}
