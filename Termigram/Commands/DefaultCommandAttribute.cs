using System;

namespace Termigram.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DefaultCommandAttribute : Attribute
    {
        #region Var
        public string? Name { get; }
        #endregion

        #region Init
        public DefaultCommandAttribute() => Name = default;

        public DefaultCommandAttribute(string name) => Name = name;
        #endregion
    }
}
