using System.Reflection;

namespace Termigram.DefaultValueProviders
{
    public interface IDefaultValueProvider
    {
        bool TryProvideDefaultValue(ParameterInfo parameter, out object? value);
    }
}
