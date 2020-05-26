using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Extensions;

namespace Termigram.ReplyMarkupBuilders
{
    public class ReplyKeyboardMarkupBuilder
    {
        private int _columns = 1;
        private bool _resizeKeyboard = true;
        private bool _oneTimeKeyboard = false;
        private IEnumerable<IEnumerable<KeyboardButton>>? _set = null;
        private IEnumerable<KeyboardButton>? _buttons = null;

        public ReplyKeyboardMarkupBuilder Columns(int columns)
        {
            if (columns < 1)
                throw new ArgumentOutOfRangeException(nameof(columns));

            _columns = columns;
            return this;
        }

        public ReplyKeyboardMarkupBuilder ResizeKeyboard(bool resizeKeyboard)
        {
            _resizeKeyboard = resizeKeyboard;
            return this;
        }

        public ReplyKeyboardMarkupBuilder OneTimeKeyboard(bool oneTimeKeyboard)
        {
            _oneTimeKeyboard = oneTimeKeyboard;
            return this;
        }

        public ReplyKeyboardMarkupBuilder Set(KeyboardButton button)
        {
            _ = button ?? throw new ArgumentNullException(nameof(button));

            _set = new[] { new[] { button } };
            _buttons = null;
            return this;
        }

        public ReplyKeyboardMarkupBuilder Set(IEnumerable<IEnumerable<KeyboardButton>> buttons)
        {
            _ = buttons ?? throw new ArgumentNullException(nameof(buttons));

            _set = buttons;
            _buttons = null;
            return this;
        }

        public ReplyKeyboardMarkupBuilder Set(IEnumerable<KeyboardButton> buttons)
        {
            _ = buttons ?? throw new ArgumentNullException(nameof(buttons));

            _buttons = buttons;
            _set = null;
            return this;
        }

        public ReplyKeyboardMarkup Build(KeyboardButton button)
        {
            Set(button);
            return Build();
        }

        public ReplyKeyboardMarkup Build(IEnumerable<IEnumerable<KeyboardButton>> buttons)
        {
            Set(buttons);
            return Build();
        }

        public ReplyKeyboardMarkup Build(IEnumerable<KeyboardButton> buttons)
        {
            Set(buttons);
            return Build();
        }

        public ReplyKeyboardMarkup Build() => new ReplyKeyboardMarkup(_set ?? _buttons?.Batch(_columns) ?? throw new ArgumentNullException("keyboard"), _resizeKeyboard, _oneTimeKeyboard);
    }
}
