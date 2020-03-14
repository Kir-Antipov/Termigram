using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Termigram.Commands;

namespace Termigram.SpecialValueProviders
{
    public interface ISpecialValueProvider<TValue> : ISpecialValueProvider
    {
        bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, [MaybeNull]out TValue value);

        bool ISpecialValueProvider.TryProvideSpecialValue(ParameterInfo parameter, ICommand command, out object? value)
        {
            if (parameter.ParameterType.IsAssignableFrom(typeof(TValue)) && TryProvideSpecialValue(parameter, command, out TValue typedValue))
            {
                value = typedValue;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }
    }
}
