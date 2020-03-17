using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.Extensions;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandInvokers
{
    public class DefaultCommandInvoker : CommandInvokerBase
    {
        #region Var
        private static readonly IConverter[] DefaultConverters = TypeExtensions.LoadAllImplementationsAsArray<IConverter>();
        private static readonly IDefaultValueProvider[] DefaultDefaultValueProviders = TypeExtensions.LoadAllImplementationsAsArray<IDefaultValueProvider>();
        private static readonly ISpecialValueProvider[] DefaultSpecialValueProviders = TypeExtensions.LoadAllImplementationsAsArray<ISpecialValueProvider>();

        private readonly IConverter[] Converters;
        private readonly IDefaultValueProvider[] DefaultValueProviders;
        private readonly ISpecialValueProvider[] SpecialValueProviders;
        #endregion

        #region Init
        public DefaultCommandInvoker(IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null)
        {
            Converters = converters is null ? DefaultConverters : converters.ToArray();
            DefaultValueProviders = defaultValueProviders is null ? DefaultDefaultValueProviders : defaultValueProviders.ToArray();
            SpecialValueProviders = specialValueProviders is null ? DefaultSpecialValueProviders : specialValueProviders.ToArray();
        }
        #endregion

        #region Functions
        protected override object? InvokeImpl(ICommand command, ICommandInfo commandInfo, object? target)
        {
            ParameterInfo[] infos = commandInfo.Method.GetParameters();
            object?[] args = new object?[infos.Length];
            int i = 0;

            if (command is IParametricCommand { Parameters: { } parameters })
            {
                for (int j = 0; j < parameters.Count && i < args.Length; ++i)
                {
                    args[i] = 
                        TryProvideSpecialValue(infos[i], command, out object? result) ? result :
                        TryConvert(parameters[j++], infos[i], out result) ? result : ProvideDefaultValue(infos[i]);
                }
            }

            for (; i < args.Length; ++i)
                args[i] = TryProvideSpecialValue(infos[i], command, out object? result) ? result : ProvideDefaultValue(infos[i]);

            return commandInfo.Method.Invoke(target, args);
        }

        protected virtual bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, out object? result)
        {
            for (int i = 0; i < SpecialValueProviders.Length; ++i)
                if (SpecialValueProviders[i].TryProvideSpecialValue(parameter, command, out result))
                    return true;

            result = default;
            return false;
        }

        protected virtual bool TryConvert(object? value, ParameterInfo parameter, out object? result)
        {
            for (int i = 0; i < Converters.Length; ++i)
                if (Converters[i].TryConvert(value, parameter.ParameterType, out result))
                    return true;

            result = default;
            return false;
        }

        protected virtual object? ProvideDefaultValue(ParameterInfo parameter)
        {
            for (int i = 0; i < DefaultValueProviders.Length; ++i)
                if (DefaultValueProviders[i].TryProvideDefaultValue(parameter, out object? result))
                    return result;

            return null;
        }
        #endregion
    }
}
