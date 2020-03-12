using System;

namespace Termigram.Converters
{
    public interface IConverter
    {
        bool TryConvert(object? value, Type resultType, out object? result);
    }
}
