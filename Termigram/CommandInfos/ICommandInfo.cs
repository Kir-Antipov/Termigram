using System.Reflection;

namespace Termigram.CommandInfos
{
    public interface ICommandInfo
    {
        string Name { get; }

        MethodInfo Method { get; }
    }
}
