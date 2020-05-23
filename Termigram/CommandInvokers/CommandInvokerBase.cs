using System.Collections.Generic;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.Extensions;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandInvokers
{
    public abstract class CommandInvokerBase : ICommandInvoker
    {
        public object? Invoke(ICommand command, ICommandInfo commandInfo, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null) => InvokeImpl(command, commandInfo, null, converters.AsArrayOrEmpty(), defaultValueProviders.AsArrayOrEmpty(), specialValueProviders.AsArrayOrEmpty());
        public object? Invoke(ICommand command, ICommandInfo commandInfo, object target, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null) => InvokeImpl(command, commandInfo, target, converters.AsArrayOrEmpty(), defaultValueProviders.AsArrayOrEmpty(), specialValueProviders.AsArrayOrEmpty());

        protected abstract object? InvokeImpl(ICommand command, ICommandInfo commandInfo, object? target, IConverter[] converters, IDefaultValueProvider[] defaultValueProviders, ISpecialValueProvider[] specialValueProviders);
    }
}
