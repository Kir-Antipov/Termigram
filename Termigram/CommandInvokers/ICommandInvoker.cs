using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandInvokers
{
    public interface ICommandInvoker
    {
        object? Invoke(ICommand command, ICommandInfo commandInfo);

        object? Invoke(ICommand command, ICommandInfo commandInfo, object target);
    }
}
