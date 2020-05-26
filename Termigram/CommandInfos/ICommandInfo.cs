using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Termigram.CommandInfos
{
    public interface ICommandInfo
    {
        IReadOnlyList<string> Names { get; }

        string Name => Names[0];

        string ShortName => Names.OrderBy(x => x.Length).First();

        MethodInfo Method { get; }
    }
}
