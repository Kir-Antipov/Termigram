using Telegram.Bot.Types;
using Termigram.Commands;
using System.Diagnostics.CodeAnalysis;

namespace Termigram.CommandParsers
{
    public interface ICommandParser
    {
        bool TryParse(Update update, [NotNullWhen(true)]out ICommand? command);
    }
}
