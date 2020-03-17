using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public interface ICommandLinker<in TCommand> : ICommandLinker where TCommand : ICommand
    {
        bool CanBeLinked(TCommand command, ICommandInfo commandInfo);

        bool ICommandLinker.CanBeLinked(ICommand command, ICommandInfo commandInfo) => command is TCommand typedCommand && CanBeLinked(typedCommand, commandInfo);
    }
}
