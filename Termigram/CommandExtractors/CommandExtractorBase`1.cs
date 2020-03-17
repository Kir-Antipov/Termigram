using System;
using Termigram.CommandInfos;

namespace Termigram.CommandExtractors
{
    public abstract class CommandExtractorBase<TCommand> : ICommandExtractor<TCommand> where TCommand : class, ICommandInfo
    {
        public abstract TCommand[] ExtractCommands(Type botType, out TCommand? defaultCommand);
    }
}
