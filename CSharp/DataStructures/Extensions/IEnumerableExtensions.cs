using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Extensions
{
    public static class IEnumerableExtensions
    {


        public static int FindIndex<T>(this IEnumerable<T> enumerable, Predicate<T> match)
        {
            var index = 0;

            foreach (var item in enumerable)
            {
                if (match(item))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }
    }
}