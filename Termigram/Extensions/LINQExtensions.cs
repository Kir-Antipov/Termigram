using System;
using System.Collections.Generic;

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
    }
}
