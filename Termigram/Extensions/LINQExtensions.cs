using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Termigram.Extensions
{
    internal static class LINQExtensions
    {
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
        {
            int count = 0;
            T[] bucket = new T[size];

            foreach (T item in source)
            {
                bucket[count++] = item;

                if (count != size)
                    continue;

                yield return bucket;

                count = 0;
                bucket = new T[size];
            }

            if (count != 0)
            {
                Array.Resize(ref bucket, count);
                yield return bucket;
            }
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T elementToAppend, Func<T, bool> previousElementPredicate)
        {
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
                if (previousElementPredicate(enumerator.Current))
                {
                    yield return elementToAppend;
                    break;
                }
            }

            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> enumerable, T elementToPrepend, Func<T, bool> nextElementPredicate)
        {
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (nextElementPredicate(enumerator.Current))
                {
                    yield return elementToPrepend;
                    yield return enumerator.Current;
                    break;
                }
                yield return enumerator.Current;
            }

            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public static T[] AsArrayOrEmpty<T>(this IEnumerable<T>? enumerable) => enumerable switch
        {
            T[] array => array,
            null => Array.Empty<T>(),
            _ => enumerable.ToArray()
        };

        [return: NotNullIfNotNull("enumerable")]
        public static IReadOnlyList<T>? AsReadOnlyListOrDefault<T>(this IEnumerable<T>? enumerable) => enumerable switch
        {
            null => null,
            IReadOnlyList<T> list => list,
            _ => enumerable.ToList().AsReadOnly()
        };

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async IAsyncEnumerable<T> AsAsyncEnumerable<T>(this IEnumerable<T> source)
        {
            foreach (T value in source)
                yield return value;
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
