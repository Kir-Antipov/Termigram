using System;
using System.Reflection;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public class NameCommandLinker : CommandLinkerBase
    {
        public override bool CanBeLinked(ICommand command, MethodInfo method)
        {
            string? name = method.GetCustomAttribute<CommandAttribute>()?.Name;
            if (string.IsNullOrEmpty(name))
                return false;

            return command.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
