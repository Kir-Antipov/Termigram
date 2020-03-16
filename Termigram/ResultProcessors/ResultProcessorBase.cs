using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;

namespace Termigram.ResultProcessors
{
    public abstract class ResultProcessorBase : IResultProcessor
    {
        public virtual async Task<bool> TryProcessResultAsync(IBot bot, ICommand command, object? result)
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

        protected virtual Task ProcessResultAsync(IBot bot, ICommand command, object? result) => Task.CompletedTask;
    }
}
