using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public abstract class CommandLinkerBase<TCommand> : ICommandLinker<TCommand> where TCommand : ICommand
    {
        public abstract bool CanBeLinked(TCommand command, ICommandInfo commandInfo);
    }
}
