using System;
using System.Reflection;

namespace Termigram.CommandExtractors
{
    public abstract class CommandExtractorBase : ICommandExtractor
    {
        public abstract MethodInfo[] ExtractCommands(Type botType);
    }
}
