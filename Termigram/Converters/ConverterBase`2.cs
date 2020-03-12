using System.Diagnostics.CodeAnalysis;

namespace Termigram.Converters
{
    public abstract class ConverterBase<TInput, TOutput> : IConverter<TInput, TOutput>
    {
        public abstract bool TryConvert([AllowNull]TInput value, [MaybeNull]out TOutput result);
    }
}
