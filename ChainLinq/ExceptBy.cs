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
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> source, IEnumerable<TSource> except, Func<TSource, TKey> keySelector)
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
        /// <param name="sourceKeySelector"></param>
        /// <param name="except"></param>
        /// <param name="exceptKeySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> sourceKeySelector,
            IEnumerable<TSource> except, Func<TSource, TKey> exceptKeySelector)
        {
            var keysToCompare = except.Select(exceptKeySelector).ToHashSet();
            return source.Where(i => !keysToCompare.Contains(sourceKeySelector(i)));
        }

    }
}
