using Termigram.Options;

namespace Termigram.Bot
{
    public interface IBot<out TOptions> : IBot where TOptions : IOptions
    {
        new TOptions Options { get; }
        IOptions IBot.Options => Options;
    }
}
