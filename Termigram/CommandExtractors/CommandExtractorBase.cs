using System;
using Termigram.CommandInfos;

namespace Termigram.CommandExtractors
{
    public abstract class CommandExtractorBase : ICommandExtractor
    {
        public abstract ICommandInfo[] ExtractCommands(Type botType, out ICommandInfo? defaultCommand);
    }
}
