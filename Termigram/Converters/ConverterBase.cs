using System;

namespace Termigram.Converters
{
    public abstract class ConverterBase : IConverter
    {
        public abstract bool TryConvert(object? value, Type resultType, out object? result);
    }
}
