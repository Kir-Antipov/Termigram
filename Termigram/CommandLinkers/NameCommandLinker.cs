using System;
using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public class NameCommandLinker : CommandLinkerBase
    {
        public override bool CanBeLinked(ICommand command, ICommandInfo commandInfo) =>
            command.Name.Equals(commandInfo.Name, StringComparison.InvariantCultureIgnoreCase);
    }
}
