using System;
using System.Reflection;

namespace Termigram.Converters
{
    public class DefaultConverter : ConverterBase
    {
        public override bool TryConvert(object? value, Type resultType, out object? result)
        {
            result = default;
            try
            {
                if (resultType.IsAssignableFrom(value?.GetType()))
                {
                    result = value;
                    return true;
                }
                else if (Nullable.GetUnderlyingType(resultType) is { } underlyingType)
                {
                    if (!TryConvert(value, underlyingType, out object? underlyingResult))
                        return false;

                    ConstructorInfo constructor = resultType.GetConstructor(new[] { underlyingType });
                    if (constructor is null)
                        return false;

                    result = constructor.Invoke(new[] { underlyingResult });
                    return true;
                }
                else
                {
                    result = Convert.ChangeType(value, resultType);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
