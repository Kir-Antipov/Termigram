using System;
using System.Reflection;

namespace Termigram.CommandExtractors
{
    public interface ICommandExtractor
    {
        MethodInfo[] ExtractCommands(Type botType);
    }
}
