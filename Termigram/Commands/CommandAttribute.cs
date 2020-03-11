using System;

namespace Termigram.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CommandAttribute : Attribute
    {
        #region Var
        public string Name { get; }
        #endregion

        #region Init
        public CommandAttribute(string name) => Name = name;
        #endregion

        #region Functions
        public override string ToString() => Name;
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Name);
        public override bool Equals(object? obj) => obj is CommandAttribute attribute && Name == attribute.Name;
        #endregion
    }
}
