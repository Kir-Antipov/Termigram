using Termigram.Options;
using Termigram.State;

namespace Termigram.Bot
{
    public interface IStateBot : IBot
    {
        new IStateOptions Options { get; }
        IOptions IBot.Options => Options;

        IState State { get; }
    }
}
