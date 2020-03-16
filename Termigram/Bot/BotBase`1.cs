using Termigram.Options;

namespace Termigram.Bot
{
    public abstract class BotBase<TOptions> : BotBase, IBot<TOptions> where TOptions : IOptions 
    {
        public new TOptions Options { get; }

        public BotBase(TOptions options) : base(options) => Options = options;
    }
}
