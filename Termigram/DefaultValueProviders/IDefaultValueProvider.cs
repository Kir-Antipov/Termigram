using System.Reflection;

namespace Termigram.DefaultValueProviders
{
    public interface IDefaultValueProvider
    {
        bool CanProvideDefaultValue(ParameterInfo parameter) => TryProvideDefaultValue(parameter, out _);

        bool TryProvideDefaultValue(ParameterInfo parameter, out object? value);
    }
}
