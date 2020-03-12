using System;

namespace Termigram.Converters
{
    public class DefaultConverter : ConverterBase
    {
        public override bool TryConvert(object? value, Type resultType, out object? result)
        {
            try
            {
                if (resultType.IsAssignableFrom(value?.GetType()))
                {
                    result = value;
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
                result = default;
                return false;
            }
        }
    }
}
