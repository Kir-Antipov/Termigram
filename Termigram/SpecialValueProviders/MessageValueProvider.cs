using System.Reflection;
using Telegram.Bot.Types;
using Termigram.Commands;
using Termigram.Extensions;

namespace Termigram.SpecialValueProviders
{
    public class MessageValueProvider : SpecialValueProviderBase<Message?>
    {
        public override bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, out Message? value) =>
            command.Update.TryGetMessage(out value) || parameter.CanBeNull();
    }
}
