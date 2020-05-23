using System.Collections.Generic;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandLinkers
{
    public interface ICommandLinker<in TCommand> : ICommandLinker where TCommand : ICommand
    {
        double GetCompatibility(TCommand command, ICommandInfo commandInfo, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null);

        double ICommandLinker.GetCompatibility(ICommand command, ICommandInfo commandInfo, IEnumerable<IConverter>? converters, IEnumerable<IDefaultValueProvider>? defaultValueProviders, IEnumerable<ISpecialValueProvider>? specialValueProviders) =>
            command is TCommand typedCommand ?
            GetCompatibility(typedCommand, commandInfo, converters, defaultValueProviders, specialValueProviders) :
            0.0;
    }
}
