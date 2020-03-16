using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;

namespace Termigram.ResultProcessors
{
    public interface IResultProcessor<in TCommand, in TResult> : IResultProcessor<TResult> where TCommand : ICommand
    {
        Task<bool> TryProcessResultAsync(IBot bot, TCommand command, TResult result);

        Task<bool> IResultProcessor<TResult>.TryProcessResultAsync(IBot bot, ICommand command, TResult result)
        {
            if (command is TCommand typedCommand)
                return TryProcessResultAsync(bot, typedCommand, result);

            return Task.FromResult(false);
        }
    }
}
