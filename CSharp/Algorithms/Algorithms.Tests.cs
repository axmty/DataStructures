using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Algorithms
{
    public partial class Algorithms
    {
        public static IEnumerable<object[]> TestCases_AreAnagrams = new[]
        {
            new object[] { "", "", true },
            new object[] { "a", "", false },
            new object[] { "a", "a", true },
            new object[] { "a", "b", false },
            new object[] { "ab", "c", false },
            new object[] { "aa", "a", false },
            new object[] { "abc", "cba", true },
            new object[] { "abc", "abd", false }
        };

        [Theory]
        [MemberData(nameof(TestCases_AreAnagrams))]
        public void Test_AreAnagrams_WithSingleLookup(string first, string second, bool expected)
        {
            AreAnagrams_WithSingleLookup(first, second).Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestCases_AreAnagrams))]
        public void Test_AreAnagrams_WithDictionaryCompare(string first, string second, bool expected)
        {
            AreAnagrams_WithDictionaryCompare(first, second).Should().Be(expected);
        }
    }
}
