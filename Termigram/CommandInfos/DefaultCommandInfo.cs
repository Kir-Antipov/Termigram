using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Termigram.CommandInfos
{
    public class DefaultCommandInfo : CommandInfoBase
    {
        #region Var
        public override IReadOnlyList<string> Names { get; }

        public override string ShortName { get; }

        public override MethodInfo Method { get; }
        #endregion

        #region Init
        public DefaultCommandInfo(IReadOnlyList<string> names, MethodInfo method)
        {
            Names = names;
            ShortName = names.OrderBy(x => x.Length).First();
            Method = method;
        }
        #endregion
    }
}
