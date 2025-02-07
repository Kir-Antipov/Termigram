﻿using System.Reflection;
using Telegram.Bot.Types;
using Termigram.Commands;
using Termigram.Extensions;

namespace Termigram.SpecialValueProviders
{
    public class ChatIdValueProvider : SpecialValueProviderBase<ChatId?>
    {
        public override bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, out ChatId? value) =>
            command.Update.TryGetChatIdOrUserId(out value) || parameter.CanBeNull();
    }
}
