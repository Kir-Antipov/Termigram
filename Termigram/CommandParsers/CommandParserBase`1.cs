using System;
using System.Diagnostics.CodeAnalysis;
using Telegram.Bot.Types;
using Termigram.Commands;

namespace Termigram.CommandParsers
{
    public abstract class CommandParserBase<TCommand> : ICommandParser<TCommand> where TCommand : class, ICommand
    {
        public abstract bool TryParse(Update update, [NotNullWhen(true)]out TCommand? command);
    }
}
