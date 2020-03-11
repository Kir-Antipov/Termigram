using System.Collections.Generic;

namespace Termigram.Commands
{
    public interface IParametricCommand<out TParameter> : IParametricCommand where TParameter : class
    {
        new IReadOnlyList<TParameter?> Parameters { get; }

        IReadOnlyList<object?> IParametricCommand.Parameters => Parameters;
    }
}
