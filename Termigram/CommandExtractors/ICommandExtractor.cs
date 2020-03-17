using System;
using Termigram.CommandInfos;

namespace Termigram.CommandExtractors
{
    public interface ICommandExtractor
    {
        ICommandInfo[] ExtractCommands(Type botType, out ICommandInfo? defaultCommand);
    }
}
