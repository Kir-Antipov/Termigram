using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public interface ICommandLinker
    {
        bool CanBeLinked(ICommand command, ICommandInfo commandInfo);
    }
}
