using System.Reflection;
using Termigram.Commands;

namespace Termigram.SpecialValueProviders
{
    public interface ISpecialValueProvider
    {
        bool CanProvideSpecialValue(ParameterInfo parameter, ICommand command);

        bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, out object? value);
    }
}
