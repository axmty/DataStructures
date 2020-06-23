using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Algorithms
{
    public partial class Algorithms
    {
        #region AreAnagrams

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

        #endregion

        #region CountUniqueValues

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

        #endregion

        #region HaveSameDigitFrequencies

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, false)]
        [InlineData(123, 321, true)]
        [InlineData(12, 32, false)]
        [InlineData(11, 1, false)]
        public void Test_HaveSameDigitFrequencies(int x, int y, bool expected)
        {
            HaveSameDigitFrequencies(x, y).Should().Be(expected);
        }

        #endregion

        #region AreThereDuplicates

        public static IEnumerable<object[]> TestCases_AreThereDuplicates = new[]
        {
            new object[] { new object[] { }, false },
            new object[] { new object[] { 1 }, false },
            new object[] { new object[] { 1, 1, 2 }, true },
            new object[] { new object[] { 1, 2, 3 }, false },
            new object[] { new object[] { 'a', 'b', 'c' }, false },
            new object[] { new object[] { 'a', 'b', 'c', 'a' }, true }
        };

        [Theory]
        [MemberData(nameof(TestCases_AreThereDuplicates))]
        public void Test_AreThereDuplicates_WithHashSet(object[] values, bool expected)
        {
            AreThereDuplicates_WithHashSet(values).Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestCases_AreThereDuplicates))]
        public void Test_AreThereDuplicates_WithSorting(object[] values, bool expected)
        {
            AreThereDuplicates_WithSorting(values).Should().Be(expected);
        }

        private class ModuloThreeEqualityComparer : IEqualityComparer<int>, IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return Comparer<int>.Default.Compare(x % 3, y % 3);
            }

            public bool Equals(int x, int y)
            {
                return this.Compare(x, y) == 0;
            }

            public int GetHashCode(int obj)
            {
                return EqualityComparer<int>.Default.GetHashCode(obj);
            }
        }

        #endregion
    }
}
