using System;
using System.Reflection;
using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class ExceptionProcessor : ResultProcessorBase<Exception>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, Exception result)
        {
            TextMessage message = result switch
            {
                AggregateException aggregate => aggregate.InnerException.Message,
                TargetInvocationException targetInvocation => targetInvocation.InnerException.Message,
                _ => result.Message
            };

            return bot.Client.SendTextMessageAsync(command.Update.GetChatIdOrUserId(), message.Text, message.ParseMode, message.DisableWebPagePreview, message.DisableNotification, message.ReplyToMessageId, message.ReplyMarkup);
        }
    }
}
