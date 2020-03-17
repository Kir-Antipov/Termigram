using System.Reflection;
using Termigram.Commands;

namespace Termigram.Extensions
{
    public static class BindingsExtensions
    {
        public static BindingFlags ExtractBindingFlags(this Bindings bindings)
        {
            BindingFlags result = 0;

            if (bindings.HasFlag(Bindings.Public))
                result |= BindingFlags.Public;

            if (bindings.HasFlag(Bindings.NonPublic))
                result |= BindingFlags.NonPublic;

            if (bindings.HasFlag(Bindings.Instance))
                result |= BindingFlags.Instance;

            if (bindings.HasFlag(Bindings.Static))
                result |= BindingFlags.Static;

            if (!bindings.HasFlag(Bindings.Inherited))
                result |= BindingFlags.DeclaredOnly;

            return result;
        }
    }
}
