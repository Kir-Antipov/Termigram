using System.Reflection;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public abstract class CommandLinkerBase : ICommandLinker
    {
        public abstract bool CanBeLinked(ICommand command, MethodInfo method);
    }
}
