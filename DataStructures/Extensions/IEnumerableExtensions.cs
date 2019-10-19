using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool Exists<T>(this IEnumerable<T> enumerable, Predicate<T> match)
        {
            return enumerable.Any(item => match(item));
        }
        
        public static T Find<T>(this IEnumerable<T> enumerable, Predicate<T> match)
        {
            return enumerable.FirstOrDefault(item => match(item));
        }

        public static IEnumerable<T> FindAll<T>(this IEnumerable<T> enumerable, Predicate<T> match)
        {
            return enumerable.Where(item => match(item));
        }
    }
}
