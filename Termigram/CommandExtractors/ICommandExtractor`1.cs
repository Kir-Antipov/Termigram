using System;
using Termigram.CommandInfos;

namespace Termigram.CommandExtractors
{
    public interface ICommandExtractor<TCommand> : ICommandExtractor where TCommand : class, ICommandInfo 
    {
        TCommand[] ExtractCommands(Type botType, out TCommand? defaultCommand);

        ICommandInfo[] ICommandExtractor.ExtractCommands(Type botType, out ICommandInfo? defaultCommand)
        {
            TCommand[] result = ExtractCommands(botType, out TCommand? typedCommand);
            defaultCommand = typedCommand;
            return result;
        }
    }
}
