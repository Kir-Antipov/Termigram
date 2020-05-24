using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.Extensions;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandLinkers
{
    public class DefaultCommandLinker : CommandLinkerBase
    {
        public override double GetCompatibility(ICommand command, ICommandInfo commandInfo, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null)
        {
            if (!HasCompatibleName(command, commandInfo))
                return 0;

            return (1 + GetParametersCompatibility(command, commandInfo, converters.AsArrayOrEmpty(), defaultValueProviders.AsArrayOrEmpty(), specialValueProviders.AsArrayOrEmpty())) / 2;
        }

        protected virtual bool HasCompatibleName(ICommand command, ICommandInfo commandInfo)
        {
            for (int i = 0; i < commandInfo.Names.Count; ++i)
                if (command.Name.Equals(commandInfo.Names[i], StringComparison.InvariantCultureIgnoreCase))
                    return true;

            return false;
        }

        protected virtual double GetParametersCompatibility(ICommand command, ICommandInfo commandInfo, IConverter[] converters, IDefaultValueProvider[] defaultValueProviders, ISpecialValueProvider[] specialValueProviders)
        {
            ParameterInfo[] notSpecialParameters = commandInfo.Method.GetParameters().Where(parameter => Array.TrueForAll(specialValueProviders, provider => !provider.CanProvideSpecialValue(parameter, command))).ToArray();

            if (command is IParametricCommand { Parameters: { } parameters })
            {
                int maxParameters = Math.Max(parameters.Count, notSpecialParameters.Length);
                int minParameters = Math.Min(parameters.Count, notSpecialParameters.Length);

                if (maxParameters == minParameters && maxParameters == 0)
                    return 1;

                double score = notSpecialParameters.Zip(parameters, (info, arg) => 
                        converters.Any(converter => converter.CanConvert(arg, info.ParameterType)) ? 1d : 0d)
                    .Sum();

                return (score + minParameters) / maxParameters / 2;
            }

            return notSpecialParameters.Length == 0 ? 1 : 0;
        }
    }
}
