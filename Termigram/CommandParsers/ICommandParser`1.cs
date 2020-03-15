using System.Diagnostics.CodeAnalysis;
using Telegram.Bot.Types;
using Termigram.Commands;

namespace Termigram.CommandParsers
{
    public interface ICommandParser<TCommand> : ICommandParser where TCommand : class, ICommand
    {
        bool TryParse(Update update, [NotNullWhen(true)]out TCommand? command);

        bool ICommandParser.TryParse(Update update, [NotNullWhen(true)]out ICommand? command)
        {
            bool parsed = TryParse(update, out TCommand? typedCommand);
            command = typedCommand;
            return parsed;
        }
    }
}
