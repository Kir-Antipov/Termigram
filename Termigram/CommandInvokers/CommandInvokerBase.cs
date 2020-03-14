using System.Reflection;
using Termigram.Commands;

namespace Termigram.CommandInvokers
{
    public abstract class CommandInvokerBase : ICommandInvoker
    {
        public object? Invoke(ICommand command, MethodInfo method) => InvokeImpl(command, method, null);
        public object? Invoke(ICommand command, MethodInfo method, object target) => InvokeImpl(command, method, target);

        protected abstract object? InvokeImpl(ICommand command, MethodInfo method, object? target);
    }
}
