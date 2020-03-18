﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Termigram.Bot;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Extensions;

namespace Termigram.CommandExtractors
{
    public class DefaultCommandExtractor : CommandExtractorBase
    {
        public override ICommandInfo[] ExtractCommands(Type botType, out ICommandInfo? defaultCommand)
        {
            defaultCommand = botType
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Select(x => new { Method = x, Attribute = x.GetCustomAttribute<DefaultCommandAttribute>() })
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
                .Select(x => new { Method = x, Attribute = x.GetCustomAttribute<CommandAttribute>() });

            if (bindings.HasFlag(Bindings.MarkedAsCommand))
                methods = methods.Where(x => x.Attribute is { });
          
            return methods
                .Select(x => new DefaultCommandInfo(ExtractNames(x.Method, x.Method.GetCustomAttribute<DefaultCommandAttribute>(), x.Attribute), x.Method))
                .Cast<ICommandInfo>()
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .ToArray();
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
