using System;
using System.Collections.Generic;

namespace Termigram.Models
{
    internal class EqualityChecker<T> : IEqualityComparer<T>
    {
        #region Var
        private readonly Func<T, T, bool> EqualityPredicate;

        private readonly Func<T, int> HashExtractor;
        #endregion

        #region Init
        private EqualityChecker(Func<T, T, bool> equalityPredicate, Func<T, int> hashExtractor)
        {
            EqualityPredicate = equalityPredicate ?? throw new ArgumentNullException(nameof(equalityPredicate));
            HashExtractor = hashExtractor ?? throw new ArgumentNullException(nameof(hashExtractor));
        }

        public static IEqualityComparer<T> Create(Func<T, T, bool> equalityPredicate)
        {
            Type t = typeof(T);

            Func<T, int> hashExtractor;
            if (t.IsValueType || t.GetMethod(nameof(GetHashCode), Type.EmptyTypes) is { } hashCodeMethod && hashCodeMethod.DeclaringType != typeof(object))
                hashExtractor = x => x?.GetHashCode() ?? 0;
            else
                hashExtractor = x => 0;

            return new EqualityChecker<T>(equalityPredicate, hashExtractor);
        }

        public static IEqualityComparer<T> Create(Func<T, T, bool> equalityPredicate, Func<T, int> hashExtractor) => new EqualityChecker<T>(equalityPredicate, hashExtractor);
        #endregion

        #region Functions
        public bool Equals(T x, T y) => EqualityPredicate(x, y);

        public int GetHashCode(T obj) => HashExtractor(obj);
        #endregion
    }
}
