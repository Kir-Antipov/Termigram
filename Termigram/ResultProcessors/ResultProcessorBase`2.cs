using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;

namespace Termigram.ResultProcessors
{
    public abstract class ResultProcessorBase<TCommand, TResult> : IResultProcessor<TCommand, TResult> where TCommand : ICommand
    {
        public virtual async Task<bool> TryProcessResultAsync(IBot bot, TCommand command, TResult result)
        {
            try
            {
                await ProcessResultAsync(bot, command, result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected virtual Task ProcessResultAsync(IBot bot, TCommand command, TResult result) => Task.CompletedTask;
    }
}
