using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandInvokers
{
    public abstract class CommandInvokerBase : ICommandInvoker
    {
        public object? Invoke(ICommand command, ICommandInfo commandInfo) => InvokeImpl(command, commandInfo, null);
        public object? Invoke(ICommand command, ICommandInfo commandInfo, object target) => InvokeImpl(command, commandInfo, target);

        protected abstract object? InvokeImpl(ICommand command, ICommandInfo commandInfo, object? target);
    }
}
