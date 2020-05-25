using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Termigram.Bot;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Models;

namespace Termigram.CommandExtractors
{
    public class DefaultCommandExtractor : CommandExtractorBase
    {
        public override ICommandInfo[] ExtractCommands(Type botType, out ICommandInfo? defaultCommand)
        {
            defaultCommand = botType
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Select(x => (Method: x, Attribute: x.GetCustomAttribute<DefaultCommandAttribute>()))
                .Where(x => x.Attribute is { })
                .Select(x => new DefaultCommandInfo(ExtractNames(x.Method, x.Method.GetCustomAttribute<DefaultCommandAttribute>(), x.Attribute), x.Method))
                .FirstOrDefault();

            Bindings bindings = botType.GetCustomAttribute<BotAttribute>()?.Bindings ?? Bindings.Default;
            if (bindings == Bindings.None)
                return Array.Empty<ICommandInfo>();

            var methods = botType
                .GetMethods(bindings.ExtractBindingFlags())
                .Where(x => x.DeclaringType.Assembly != typeof(BotBase).Assembly && x.DeclaringType != typeof(object))
                .Where(x => x.GetCustomAttribute<IgnoreCommandAttribute>() is null)
                .Select(x => (Method: x, Attribute: x.GetCustomAttribute<CommandAttribute>()));

            if (bindings.HasFlag(Bindings.MarkedAsCommand))
                methods = methods.Where(x => x.Attribute is { });
          
            ICommandInfo[] commands = methods
                .Select(x => new DefaultCommandInfo(ExtractNames(x.Method, x.Method.GetCustomAttribute<DefaultCommandAttribute>(), x.Attribute), x.Method))
                .ToArray();

            var groupedCommands = commands
                .Select((x, i) => (Command: x, Index: i))
                .GroupBy(x => x.Command.Names, EqualityChecker<IEnumerable<string>>.Create((a, b) => a.Any(aElement => b.Contains(aElement))))
                .Where(x => x.Count() > 1)
                .Select(group => (Group: group, Names: group.SelectMany(x => x.Command.Names).Distinct().OrderBy(x => x == group.First().Command.Method.Name).ThenByDescending(x => x.Length).ToArray()));

            foreach (var (group, names) in groupedCommands)
                foreach (var (command, i) in group)
                    commands[i] = new DefaultCommandInfo(names, command.Method);

            return commands;
        }

        private static IReadOnlyList<string> ExtractNames(MethodInfo method, DefaultCommandAttribute? defaultAttribute, CommandAttribute? commandAttribute)
        {
            IReadOnlyList<string>? names = defaultAttribute?.Names;
            if (names is null || names.Count == 0)
                names = commandAttribute?.Names;
            if (names is null || names.Count == 0)
                names = new[] { method.Name };
            return names;
        }
    }
}
