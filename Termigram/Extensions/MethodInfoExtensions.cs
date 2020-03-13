using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Termigram.Extensions
{
    internal static class MethodInfoExtensions
    {
        public static Delegate CreateDelegate(this MethodInfo method) => CreateDelegate(method, null);

        public static Delegate CreateDelegate(this MethodInfo method, object? target)
        {
            IEnumerable<Type> parameters = method.GetParameters().Select(x => x.ParameterType);
            Type delegateType = method.ReturnType == typeof(void)
                ? Expression.GetActionType(parameters.ToArray())
                : Expression.GetFuncType(parameters.Append(method.ReturnType).ToArray());

            return method.IsStatic ? method.CreateDelegate(delegateType) : method.CreateDelegate(delegateType, target);
        }
    }
}
