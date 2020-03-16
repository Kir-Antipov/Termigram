using System.Reflection;
using Termigram.Commands;

namespace Termigram.CommandLinkers
{
    public interface ICommandLinker
    {
        bool CanBeLinked(ICommand command, MethodInfo method);
    }
}
