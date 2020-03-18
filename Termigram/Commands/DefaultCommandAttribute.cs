using System;

namespace Termigram.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DefaultCommandAttribute : CommandAttribute
    {
        public DefaultCommandAttribute() : base() { }

        public DefaultCommandAttribute(params string[] names) : base(names) { }
    }
}
