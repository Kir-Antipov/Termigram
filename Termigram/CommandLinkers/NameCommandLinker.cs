using System;
using Termigram.CommandInfos;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public class NameCommandLinker : CommandLinkerBase
    {
        public override bool CanBeLinked(ICommand command, ICommandInfo commandInfo)
        {
            for (int i = 0; i < commandInfo.Names.Count; ++i)
                if (command.Name.Equals(commandInfo.Names[i], StringComparison.InvariantCultureIgnoreCase))
                    return true;

            return false;
        }
    }
}
