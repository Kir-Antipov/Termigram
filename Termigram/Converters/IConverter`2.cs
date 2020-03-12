using System;
using System.Diagnostics.CodeAnalysis;

namespace Termigram.Converters
{
    public interface IConverter<in TInput, TOutput> : IConverter
    {
        bool TryConvert([AllowNull]TInput value, [MaybeNull]out TOutput result);

        bool IConverter.TryConvert(object? value, Type resultType, out object? result)
        {
            if (resultType.IsAssignableFrom(typeof(TOutput)) && value is TInput input && TryConvert(input, out TOutput output))
            {
                result = output;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
    }
}
