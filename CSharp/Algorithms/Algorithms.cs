using System.Collections.Generic;

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
    }
}
