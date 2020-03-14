using System.Reflection;
using Termigram.Commands;

namespace Termigram.CommandInvokers
{
    public interface ICommandInvoker
    {
        object? Invoke(ICommand command, MethodInfo method);

        object? Invoke(ICommand command, MethodInfo method, object target);
    }
}
