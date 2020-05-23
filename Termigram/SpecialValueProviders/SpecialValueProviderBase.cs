using System.Reflection;
using Termigram.Commands;

namespace Termigram.SpecialValueProviders
{
    public abstract class SpecialValueProviderBase : ISpecialValueProvider
    {
        public virtual bool CanProvideSpecialValue(ParameterInfo parameter, ICommand command) => TryProvideSpecialValue(parameter, command, out _);

        public virtual bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, out object? value)
        {
            try
            {
                value = ProvideSpecialValue(parameter, command);
                return true;
            }
            catch
            {
                value = default;
                return false;
            }
        }

        protected virtual object? ProvideSpecialValue(ParameterInfo parameter, ICommand command) => default;
    }
}
