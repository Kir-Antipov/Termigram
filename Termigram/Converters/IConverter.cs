using System;

namespace Termigram.Converters
{
    public interface IConverter
    {
        bool CanConvert(object? value, Type resultType) => TryConvert(value, resultType, out _);

        bool TryConvert(object? value, Type resultType, out object? result);
    }
}
