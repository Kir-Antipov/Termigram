using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public interface ICommandLinker<in TCommand, in TCommandInfo> : ICommandLinker<TCommand> where TCommand : ICommand where TCommandInfo : ICommandInfo
    {
        bool CanBeLinked(TCommand command, TCommandInfo commandInfo);

        bool ICommandLinker<TCommand>.CanBeLinked(TCommand command, ICommandInfo commandInfo) => commandInfo is TCommandInfo typedCommandInfo && CanBeLinked(command, typedCommandInfo);
    }
}
