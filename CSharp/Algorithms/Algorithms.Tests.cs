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


        public static IEnumerable<object[]> TestCases_CountUniqueValues = new[]
        {
            new object[] { new object[] { 1, 1, 1, 1, 2 }, 2 },
            new object[] { new object[] { 1, 2, 3, 4, 4, 4, 5, 5, 12, 13 }, 7 },
            new object[] { new object[] { }, 0 },
            new object[] { new object[] { 3 }, 1 },
            new object[] { new object[] { -2, -1, -1, 0, 1 }, 4 },
            new object[] { new object[] { "aa", "aa", "ab", "ba" }, 3 }
        };

        [Theory]
        [MemberData(nameof(TestCases_CountUniqueValues))]
        public void Test_CountUniqueValues_NoExtraStructure(object[] values, int expected)
        {
            CountUniqueValues_NoExtraStructure(values).Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestCases_CountUniqueValues))]
        public void Test_CountUniqueValues_WithSet(object[] values, int expected)
        {
            CountUniqueValues_WithHashSet(values).Should().Be(expected);
        }
    }
}
