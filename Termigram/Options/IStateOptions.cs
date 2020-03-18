using System;
using Termigram.State;

namespace Termigram.Options
{
    public interface IStateOptions : IOptions
    {
        Func<IState> StateFactory { get; }
    }
}
