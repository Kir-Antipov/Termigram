using System.Collections.Generic;
using System.Reflection;

namespace Termigram.CommandInfos
{
    public interface ICommandInfo
    {
        IReadOnlyList<string> Names { get; }
        string Name => Names[0];

        MethodInfo Method { get; }
    }
}
