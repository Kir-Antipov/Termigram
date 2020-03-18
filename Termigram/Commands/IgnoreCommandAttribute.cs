using System;

namespace Termigram.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class IgnoreCommandAttribute : Attribute { }
}
