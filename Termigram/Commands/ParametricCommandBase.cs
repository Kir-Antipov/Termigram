using System.Collections.Generic;
using Telegram.Bot.Types;

namespace Termigram.Commands
{
    public class ParametricCommandBase : CommandBase, IParametricCommand
    {
        #region Var
        public IReadOnlyList<object?> Parameters { get; }
        #endregion

        #region Init
        public ParametricCommandBase(string name, Update update, IReadOnlyList<object?> parameters) : base(name, update) => Parameters = parameters;
        #endregion
    }
}
