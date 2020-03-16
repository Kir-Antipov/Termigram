using Termigram.Options;

namespace Termigram.Bot
{
    public interface IStateBot<out TOptions> : IStateBot, IBot<TOptions> where TOptions : IStateOptions { }
}
