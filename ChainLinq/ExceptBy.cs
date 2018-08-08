using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainLinq
{
    public static class Enumerable
    {
        /// <summary>
        /// This function returns the absolute complement of two sets of
        /// identical object types, i.e. it returns all of the items in
        /// "source" except for any items that also appear in "except."
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="except"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> source, IEnumerable<T> except, Func<T, TKey> keySelector)
        {
            var keysToCompare = except.Select(keySelector).ToHashSet();
            return source.Where(i => !keysToCompare.Contains(keySelector(i)));
        }

        /// <summary>
        /// This function returns the absolute complement of two sets of
        /// different object types, i.e. it returns all of the items in
        /// "source" except for any items that also appear in "except."
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="sourceKeyComparer"></param>
        /// <param name="except"></param>
        /// <param name="exceptKeyComparer"></param>
        /// <returns></returns>
        public static IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> sourceKeyComparer,
            IEnumerable<T> except, Func<T, TKey> exceptKeyComparer)
        {
            throw new NotImplementedException();
        }

    }
}
