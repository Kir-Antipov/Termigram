using System;
using System.Reflection;
using Termigram.Extensions;

namespace Termigram.DefaultValueProviders
{
    public class DefaultDefaultValueProvider : DefaultValueProviderBase
    {
        public override bool TryProvideDefaultValue(ParameterInfo parameter, out object? value)
        {
            if (parameter.HasDefaultValue)
            {
                value = parameter.DefaultValue;
                return true;
            }

            Type resultType = parameter.ParameterType;
            if (resultType.IsValueType)
            {
                try
                {
                    value = Activator.CreateInstance(resultType);
                    return true;
                }
                catch
                {
                    value = default;
                    return false;
                }
            }
            else
            {
                if (parameter.CanBeNull())
                {
                    value = default;
                    return true;
                }

                if (resultType == typeof(string))
                {
                    value = string.Empty;
                    return true;
                }

                try
                {
                    value = Activator.CreateInstance(resultType);
                    return true;
                }
                catch
                {
                    value = default;
                    return false;
                }
            }
        }
    }
}
