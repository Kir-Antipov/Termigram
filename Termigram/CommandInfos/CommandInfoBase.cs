using System.Collections.Generic;
using System.Reflection;

namespace Termigram.CommandInfos
{
    public abstract class CommandInfoBase : ICommandInfo
    {
		#region Var
        public abstract IReadOnlyList<string> Names { get; }
        
        public abstract string ShortName { get; }
        string ICommandInfo.ShortName => ShortName;

        public abstract MethodInfo Method { get; }
        #endregion

        #region Functions
        public override string ToString() => Names[0];
        public override int GetHashCode() => Names[0].GetHashCode();
        public override bool Equals(object? obj) => obj is ICommandInfo command && Names[0] == command.Name;
        #endregion
    }
}
