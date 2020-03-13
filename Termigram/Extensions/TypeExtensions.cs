using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Termigram.Extensions
{
    internal static class TypeExtensions
    {
        public static IEnumerable<T> LoadAllImplementations<T>() => Assembly.GetExecutingAssembly().ExportedTypes
            .Where(typeof(T).IsAssignableFrom)
            .Where(x => !x.IsAbstract && !x.IsInterface)
            .Select(x =>
            {
                ConstructorInfo constructor = x.GetConstructor(Type.EmptyTypes);
                return constructor is null ? default : (T)constructor.Invoke(Array.Empty<object>());
            })
            .Where(x => x is { })
            .ToArray();

        public static T[] LoadAllImplementationsAsArray<T>() => LoadAllImplementations<T>().ToArray();

        public static IReadOnlyList<T> LoadAllImplementationsAsReadOnlyList<T>() => LoadAllImplementations<T>().ToList().AsReadOnly();
    }
}
