using System;
using System.Collections.Generic;

namespace ChainLinq
{
    public static class Enumerable
    {
        /// <summary>
        /// This function returns the absolute complement of two sets, i.e. it
        /// returns all of the items in "source" except for any items that
        /// also appear in "except."
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="except"></param>
        /// <param name="keyComparer"></param>
        /// <returns></returns>
        public static IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> source, IEnumerable<T> except, Func<T, TKey> keyComparer)
        {
            throw new NotImplementedException();
        }

    }
}
