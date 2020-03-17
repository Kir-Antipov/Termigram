using System;
using Termigram.Commands;

namespace Termigram.Bot
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BotAttribute : Attribute
    {
		#region Var
		public Bindings Bindings { get; }
		#endregion

		#region Init
		public BotAttribute(Bindings bindings = Bindings.Default) => Bindings = bindings;
		#endregion
	}
}
