using System.Collections.Generic;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandLinkers
{
    public abstract class CommandLinkerBase<TCommand, TCommandInfo> : ICommandLinker<TCommand, TCommandInfo> where TCommand : ICommand where TCommandInfo : ICommandInfo
    {
        public abstract double GetCompatibility(TCommand command, TCommandInfo commandInfo, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null);
    }
}
