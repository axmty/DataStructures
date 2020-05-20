using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public partial class Algorithms
    {
        // Returns true if and only if the two strings are anagrams.
        // O(1) space - O(n) time
        public static bool AreAnagrams(string first, string second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }

            var lookup = new Dictionary<char, int>();

            foreach (var letter in first)
            {
                lookup[letter] = lookup.ContainsKey(letter) ? lookup[letter] + 1 : 1;
            }

            foreach (var letter in second)
            {
                if (!lookup.TryGetValue(letter, out var count) || count == 0)
                {
                    return false;
                }

                lookup[letter] = count - 1;
            }

            return true;
        }

        // Using Linq to create a dictionary for each string, then calculate the intersection of both.
        public static bool AreAnagrams_WithDictionaryCompare(string first, string second)
        {
            static Dictionary<char, int> MakeDictionary(string str) => str
                .GroupBy(c => c, (key, group) => new Tuple<char, int>(key, group.Count()))
                .ToDictionary(x => x.Item1, x => x.Item2);

            var fstDict = MakeDictionary(first);
            var sndDict = MakeDictionary(second);

            return fstDict.Intersect(sndDict).Count() == fstDict.Count();
        }
    }
}
