using System.Reflection;
using Termigram.Commands;

namespace Termigram.SpecialValueProviders
{
    public class CommandValueProvider : SpecialValueProviderBase<ICommand>
    {
        protected override ICommand ProvideSpecialValue(ParameterInfo parameter, ICommand command) => command;
    }
}
