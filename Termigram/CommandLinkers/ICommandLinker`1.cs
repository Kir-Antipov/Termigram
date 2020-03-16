using System.Reflection;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public interface ICommandLinker<in TCommand> : ICommandLinker where TCommand : ICommand
    {
        bool CanBeLinked(TCommand command, MethodInfo method);

        bool ICommandLinker.CanBeLinked(ICommand command, MethodInfo method) => command is TCommand typedCommand && CanBeLinked(typedCommand, method);
    }
}
