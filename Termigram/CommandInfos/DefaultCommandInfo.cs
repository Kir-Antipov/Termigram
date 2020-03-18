using System.Collections.Generic;
using System.Reflection;

namespace Termigram.CommandInfos
{
    public class DefaultCommandInfo : CommandInfoBase
    {
        #region Var
        public override IReadOnlyList<string> Names { get; }

        public override MethodInfo Method { get; }
        #endregion

        #region Init
        public DefaultCommandInfo(IReadOnlyList<string> names, MethodInfo method)
        {
            Names = names;
            Method = method;
        }
        #endregion
    }
}
