using System;

namespace Termigram.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CommandAttribute : Attribute
    {
        #region Var
        public string? Name { get; }
        #endregion

        #region Init
        public CommandAttribute() => Name = default;

        public CommandAttribute(string name) => Name = name;
        #endregion
    }
}
