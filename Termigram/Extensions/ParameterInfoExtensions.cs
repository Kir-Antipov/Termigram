using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Termigram.Extensions
{
    internal static class ParameterInfoExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CanBeNull(this ParameterInfo parameter) => parameter.CustomAttributes.Any(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.NullableAttribute" && x.ConstructorArguments.Count == 1 && x.ConstructorArguments[0].Value is byte b && b == 2);
    }
}
