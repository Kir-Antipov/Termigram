using Termigram.State;

namespace Termigram.Options
{
    public interface IStateOptions : IOptions
    {
        IState State { get; }
    }
}
