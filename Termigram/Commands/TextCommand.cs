using System.Collections.Generic;
using Telegram.Bot.Types;

namespace Termigram.Commands
{
    public class TextCommand : ParametricCommandBase<string>
    {
        #region Init
        public TextCommand(string name, Update update, params string[] parameters) : this(name, update, (IEnumerable<string>)parameters) { }

        public TextCommand(string name, Update update, IEnumerable<string> parameters) : base(name, update, new List<string>(parameters).AsReadOnly()) { }
        #endregion
    }
}
