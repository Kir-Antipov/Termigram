using System.Reflection;
using Telegram.Bot.Types;
using Termigram.Commands;
using Termigram.Extensions;

namespace Termigram.SpecialValueProviders
{
    public class UserValueProvider : SpecialValueProviderBase<User?>
    {
        public override bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, out User? value) =>
            command.Update.TryGetUser(out value) || parameter.CanBeNull();
    }
}
