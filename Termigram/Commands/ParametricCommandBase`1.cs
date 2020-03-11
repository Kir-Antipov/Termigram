using System.Collections.Generic;
using Telegram.Bot.Types;

namespace Termigram.Commands
{
    public class ParametricCommandBase<TParameter> : ParametricCommandBase, IParametricCommand<TParameter> where TParameter : class
    {
        #region Var
        public new IReadOnlyList<TParameter?> Parameters { get; }
        #endregion

        #region Init
        public ParametricCommandBase(string name, Update update, IReadOnlyList<TParameter?> parameters) : base(name, update, parameters) => Parameters = parameters;
        #endregion
    }
}
