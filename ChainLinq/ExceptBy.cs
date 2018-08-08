using System;
using System.Collections.Generic;

namespace ChainLinq
{
    public static class Enumerable
    {
        public static IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> source, IEnumerable<T> except, Func<T, TKey> keyComparer)
        {
            throw new NotImplementedException();
        }
    }
}
