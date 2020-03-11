using System.Collections.Generic;

namespace Termigram.Commands
{
    public interface IParametricCommand : ICommand
    {
        IReadOnlyList<object?> Parameters { get; }
    }
}
