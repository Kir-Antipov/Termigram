using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Termigram.Commands;

namespace Termigram.SpecialValueProviders
{
    public abstract class SpecialValueProviderBase<TValue> : ISpecialValueProvider<TValue>
    {
        public virtual bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, [MaybeNull]out TValue value)
        {
            try
            {
                value = ProvideSpecialValue(parameter, command);
                return true;
            }
            catch
            {
                value = default!;
                return false;
            }
        }

        [return: MaybeNull]
        protected virtual TValue ProvideSpecialValue(ParameterInfo parameter, ICommand command) => default!;
    }
}
