using System.Reflection;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandInvokers
{
    public class DefaultCommandInvoker : CommandInvokerBase
    {
        protected override object? InvokeImpl(ICommand command, ICommandInfo commandInfo, object? target, IConverter[] converters, IDefaultValueProvider[] defaultValueProviders, ISpecialValueProvider[] specialValueProviders)
        {
            ParameterInfo[] infos = commandInfo.Method.GetParameters();
            object?[] args = new object?[infos.Length];
            int i = 0;

            if (command is IParametricCommand { Parameters: { } parameters })
            {
                for (int j = 0; j < parameters.Count && i < args.Length; ++i)
                {
                    args[i] = 
                        TryProvideSpecialValue(infos[i], command, specialValueProviders, out object? result) ? result :
                        TryConvert(parameters[j++], infos[i], converters, out result) ? result : ProvideDefaultValue(infos[i], defaultValueProviders);
                }
            }

            for (; i < args.Length; ++i)
                args[i] = TryProvideSpecialValue(infos[i], command, specialValueProviders, out object? result) ? result : ProvideDefaultValue(infos[i], defaultValueProviders);

            return commandInfo.Method.Invoke(target, args);
        }

        protected virtual bool TryProvideSpecialValue(ParameterInfo parameter, ICommand command, ISpecialValueProvider[] specialValueProviders, out object? result)
        {
            for (int i = 0; i < specialValueProviders.Length; ++i)
                if (specialValueProviders[i].TryProvideSpecialValue(parameter, command, out result))
                    return true;

            result = default;
            return false;
        }

        protected virtual bool TryConvert(object? value, ParameterInfo parameter, IConverter[] converters, out object? result)
        {
            for (int i = 0; i < converters.Length; ++i)
                if (converters[i].TryConvert(value, parameter.ParameterType, out result))
                    return true;

            result = default;
            return false;
        }

        protected virtual object? ProvideDefaultValue(ParameterInfo parameter, IDefaultValueProvider[] defaultValueProviders)
        {
            for (int i = 0; i < defaultValueProviders.Length; ++i)
                if (defaultValueProviders[i].TryProvideDefaultValue(parameter, out object? result))
                    return result;

            return null;
        }
    }
}
