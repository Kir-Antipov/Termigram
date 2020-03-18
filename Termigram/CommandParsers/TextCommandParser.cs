using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Telegram.Bot.Types;
using Termigram.Commands;
using Termigram.Extensions;

namespace Termigram.CommandParsers
{
    public class TextCommandParser : CommandParserBase<TextCommand>
    {
        private static readonly Regex NameRegex = new Regex(@"^[\s\/]*([^ ]*)", RegexOptions.Compiled | RegexOptions.Singleline);

        public override bool TryParse(Update update, [NotNullWhen(true)]out TextCommand? command)
        {
            command = default;

            if (!update.TryGetText(out string? text) || string.IsNullOrWhiteSpace(text))
                return false;

            if (!TryParseCommand(text, out string? name, out string[]? parameters))
                return false;

            command = new TextCommand(name, update, parameters);
            return true;
        }

        private static bool TryParseCommand(string commandText, [NotNullWhen(true)]out string? commandName, [NotNullWhen(true)]out string[]? commandParameters)
        {
            Match match = NameRegex.Match(commandText);
            if (match.Success)
            {
                Group group = match.Groups[1];
                commandName = group.Value;
                commandParameters = commandText.Substring(group.Index + group.Length).Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return true;
            }
            else
            {
                commandName = default;
                commandParameters = default;
                return false;
            }
        }
    }
}
