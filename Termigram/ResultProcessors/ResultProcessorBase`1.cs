using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;

namespace Termigram.ResultProcessors
{
    public abstract class ResultProcessorBase<TResult> : IResultProcessor<TResult>
    {
        public virtual async Task<bool> TryProcessResultAsync(IBot bot, ICommand command, TResult result)
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

        protected virtual Task ProcessResultAsync(IBot bot, ICommand command, TResult result) => Task.CompletedTask;
    }
}
