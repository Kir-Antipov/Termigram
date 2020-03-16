using Termigram.Options;

namespace Termigram.Bot
{
    public abstract class StateBotBase<TOptions> : StateBotBase, IStateBot<TOptions> where TOptions : IStateOptions
    {
        public new TOptions Options { get; }

        public StateBotBase(TOptions options) : base(options) => Options = options;
    }
}
