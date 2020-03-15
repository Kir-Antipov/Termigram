using System;
using System.Linq;
using System.Reflection;
using Termigram.Commands;

namespace Termigram.CommandExtractors
{
    public class DefaultCommandExtractor : CommandExtractorBase
    {
        public override MethodInfo[] ExtractCommands(Type botType) => botType
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
            .Select(x => new { Method = x, CommandName = x.GetCustomAttribute<CommandAttribute>()?.Name })
            .Where(x => !string.IsNullOrWhiteSpace(x.CommandName))
            .GroupBy(x => x.CommandName)
            .Select(x => x.First().Method)
            .ToArray();
    }
}
