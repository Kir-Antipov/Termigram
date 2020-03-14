using System.Reflection;
using Telegram.Bot.Types;
using Termigram.Commands;

namespace Termigram.SpecialValueProviders
{
    public class UpdateValueProvider : SpecialValueProviderBase<Update>
    {
        protected override Update ProvideSpecialValue(ParameterInfo parameter, ICommand command) => command.Update;
    }
}
