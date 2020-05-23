using System.Collections.Generic;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandLinkers
{
    public interface ICommandLinker<in TCommand, in TCommandInfo> : ICommandLinker<TCommand> where TCommand : ICommand where TCommandInfo : ICommandInfo
    {
        double GetCompatibility(TCommand command, TCommandInfo commandInfo, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null);

        double ICommandLinker<TCommand>.GetCompatibility(TCommand command, ICommandInfo commandInfo, IEnumerable<IConverter>? converters, IEnumerable<IDefaultValueProvider>? defaultValueProviders, IEnumerable<ISpecialValueProvider>? specialValueProviders) =>
            commandInfo is TCommandInfo typedCommandInfo ?
            GetCompatibility(command, typedCommandInfo, converters, defaultValueProviders, specialValueProviders) :
            0.0;
    }
}
