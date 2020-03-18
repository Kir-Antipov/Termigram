using System;
using System.Collections.Generic;

namespace Termigram.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CommandAttribute : Attribute
    {
        #region Var
        public IReadOnlyList<string>? Names { get; }
        #endregion

        #region Init
        public CommandAttribute() => Names = default;

        public CommandAttribute(params string[] names) => Names = names;
        #endregion
    }
}
