using System.Collections.Generic;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandInvokers
{
    public interface ICommandInvoker
    {
        object? Invoke(ICommand command, ICommandInfo commandInfo, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null);

        object? Invoke(ICommand command, ICommandInfo commandInfo, object target, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null);
    }
}
