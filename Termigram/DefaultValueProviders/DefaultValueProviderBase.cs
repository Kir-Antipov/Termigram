using System.Reflection;

namespace Termigram.DefaultValueProviders
{
    public abstract class DefaultValueProviderBase : IDefaultValueProvider
    {
        public abstract bool TryProvideDefaultValue(ParameterInfo parameter, out object? value);
    }
}
