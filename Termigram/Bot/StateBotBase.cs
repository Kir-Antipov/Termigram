using Termigram.Options;
using Termigram.State;

namespace Termigram.Bot
{
    public abstract class StateBotBase : BotBase, IStateBot
    {
        public new IStateOptions Options { get; }
        public IState State { get; }

        public StateBotBase(IStateOptions options) : base(options)
        {
            Options = options;
            State = options.StateFactory();
        }
    }
}
