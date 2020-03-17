using System.Reflection;

namespace Termigram.CommandInfos
{
    public abstract class CommandInfoBase : ICommandInfo
    {
		#region Var
        public abstract string Name { get; }

        public abstract MethodInfo Method { get; }
        #endregion

        #region Functions
        public override string ToString() => Name;
        public override int GetHashCode() => Name.GetHashCode();
        public override bool Equals(object? obj) => obj is ICommandInfo command && Name == command.Name;
        #endregion
    }
}
