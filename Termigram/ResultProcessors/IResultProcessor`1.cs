using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;

namespace Termigram.ResultProcessors
{
    public interface IResultProcessor<in TResult> : IResultProcessor
    {
        Task<bool> TryProcessResultAsync(IBot bot, ICommand command, TResult result);

        Task<bool> IResultProcessor.TryProcessResultAsync(IBot bot, ICommand command, object? result)
        {
            if (result is TResult typedResult)
                return TryProcessResultAsync(bot, command, typedResult);

            return Task.FromResult(false);
        }
    }
}
