using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;

namespace Termigram.ResultProcessors
{
    public interface IResultProcessor
    {
        Task<bool> TryProcessResultAsync(IBot bot, ICommand command, object? result);
    }
}
