using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public partial class Algorithms
    {
        // Returns true if and only if the two strings are anagrams.
        // O(1) space - O(n) time
        public static bool AreAnagrams_WithSingleLookup(string first, string second)
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
        // O(1) space - O(n) time
        public static bool AreAnagrams_WithDictionaryCompare(string first, string second)
        {
            static Dictionary<char, int> MakeDictionary(string str) => str
                .GroupBy(
                    c => c,
                    (charKey, chars) => ((char Char, int CharCount))(charKey, chars.Count()))
                .ToDictionary(x => x.Char, x => x.CharCount);

            var fstDict = MakeDictionary(first);
            var sndDict = MakeDictionary(second);

            return fstDict.Intersect(sndDict).Count() == fstDict.Count();
        }

        // ------------------------------------------------------------------------------------------------------------

        // Returns the number of unique values in the array.
        // With no extra data structure, array needs to be sorted.
        // O(1) space - O(n) time
        public static int CountUniqueValues_NoExtraStructure<T>(T[] arr, IEqualityComparer<T> equalityComparer = null)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            int count = 1;
            equalityComparer ??= EqualityComparer<T>.Default;

            for (int i = 1; i < arr.Length; i++)
            {
                if (!equalityComparer.Equals(arr[i], arr[i - 1]))
                {
                    count++;
                }
            }

            return count;
        }

        // With HashSet, array does not need to be sorted.
        // O(n) space - O(n) time
        public static int CountUniqueValues_WithHashSet<T>(T[] arr, IEqualityComparer<T> equalityComparer = null)
        {
            return new HashSet<T>(arr, equalityComparer ?? EqualityComparer<T>.Default).Count;
        }

        // ------------------------------------------------------------------------------------------------------------

        // Returns true if and and only if the two positive integers have the same frequency of digits.
        // O(1) space - O(n) time
        public static bool HaveSameDigitFrequencies(int x, int y)
        {
            return AreAnagrams_WithSingleLookup(x.ToString(), y.ToString());
        }
    }
}
