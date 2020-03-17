using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public abstract class CommandLinkerBase<TCommand, TCommandInfo> : ICommandLinker<TCommand, TCommandInfo> where TCommand : ICommand where TCommandInfo : ICommandInfo
    {
        public abstract bool CanBeLinked(TCommand command, TCommandInfo commandInfo);
    }
}
