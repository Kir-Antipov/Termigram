using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.ReplyMarkupBuilders
{
    public class InlineKeyboardMarkupBuilder
    {
        private int _columns = 1;
        private IEnumerable<IEnumerable<InlineKeyboardButton>>? _set = null;
        private IEnumerable<InlineKeyboardButton>? _buttons = null;

        public InlineKeyboardMarkupBuilder Columns(int columns)
        {
            if (columns < 1)
                throw new ArgumentOutOfRangeException(nameof(columns));

            _columns = columns;
            return this;
        }

        public InlineKeyboardMarkupBuilder Set(InlineKeyboardButton button)
        {
            _ = button ?? throw new ArgumentNullException(nameof(button));

            _set = new[] { new[] { button } };
            _buttons = null;
            return this;
        }

        public InlineKeyboardMarkupBuilder Set(IEnumerable<IEnumerable<InlineKeyboardButton>> buttons)
        {
            _ = buttons ?? throw new ArgumentNullException(nameof(buttons));

            _set = buttons;
            _buttons = null;
            return this;
        }

        public InlineKeyboardMarkupBuilder Set(IEnumerable<InlineKeyboardButton> buttons)
        {
            _ = buttons ?? throw new ArgumentNullException(nameof(buttons));

            _buttons = buttons;
            _set = null;
            return this;
        }

        public InlineKeyboardMarkup Build(InlineKeyboardButton button)
        {
            Set(button);
            return Build();
        }

        public InlineKeyboardMarkup Build(IEnumerable<IEnumerable<InlineKeyboardButton>> buttons)
        {
            Set(buttons);
            return Build();
        }

        public InlineKeyboardMarkup Build(IEnumerable<InlineKeyboardButton> buttons)
        {
            Set(buttons);
            return Build();
        }

        public InlineKeyboardMarkup Build() => new InlineKeyboardMarkup(_set ?? _buttons?.Batch(_columns) ?? throw new ArgumentNullException("keyboard"));
    }
}
