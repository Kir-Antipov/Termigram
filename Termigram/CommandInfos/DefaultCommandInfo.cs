using System.Reflection;

namespace Termigram.CommandInfos
{
    public class DefaultCommandInfo : CommandInfoBase
    {
        #region Var
        public override string Name { get; }

        public override MethodInfo Method { get; }
        #endregion

        #region Init
        public DefaultCommandInfo(string name, MethodInfo method)
        {
            Name = name;
            Method = method;
        }
        #endregion
    }
}
