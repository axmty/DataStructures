using Xunit;
using FluentAssertions;
using System;
using System.Linq;

namespace DataStructures.UnitTests
{
    public class SingleLinkedList_Tests
    {
        [Fact]
        public void EmptyList_ShouldHaveCountOfZero()
        {
            var list = new SingleLinkedList<int>();

            list.Count.Should().Be(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void EmptyList_ShouldThrow_WhenIndexingOutOfRange(int index)
        {
            var list = new SingleLinkedList<int>();

            Func<int> indexing = () => list[index];

            indexing.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Add_ShouldAppendElementAtTheEndOfTheList()
        {
            var list = new SingleLinkedList<int>();

            for (int i = 0; i < 2; i++)
            {
                list.Add(i);
                
                list.Count.Should().Be(i + 1);
                list[i].Should().Be(i);
            }
        }

        [Fact]
        public void Clear_ShouldMakeCountToZero()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.Clear();

            list.Count.Should().Be(0);
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenListContainsTheItem()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.Contains(3).Should().BeTrue();
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenListDoesNotContainTheItem()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.Contains(4).Should().BeFalse();
        }

        [Fact]
        public void CopyTo_ShouldThrow_WhenArrayIsNull()
        {
            var list = new SingleLinkedList<int>();

            Action copyTo = () => list.CopyTo(null, 3);

            copyTo.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CopyTo_ShouldThrow_WhenArrayIndexIsLessThanZero()
        {
            var list = new SingleLinkedList<int>();

            Action copyTo = () => list.CopyTo(new int[3], -1);

            copyTo.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CopyTo_ShouldThrow_WhenArraySpaceFromIndexIsNotLargeEnough()
        {
            var list = new SingleLinkedList<int> { 1, 2 };

            Action copyTo = () => list.CopyTo(new int[1], 0);

            copyTo.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CopyTo_ShouldModifyTheArray_WhenListIsNotEmpty()
        {
            var list = new SingleLinkedList<int> { 1, 2 };
            var array = new int[] { 0, 0, 0, 0 };

            list.CopyTo(array, 1);
            var expected = new int[] { 0, 1, 2, 0 };

            array.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [Fact]
        public void CopyTo_ShouldNotModifyTheArray_WhenListIsEmpty()
        {
            var list = new SingleLinkedList<int>();
            var array = new int[] { 0, 0, 0, 0 };

            list.CopyTo(array, 1);
            var expected = new int[] { 0, 0, 0, 0 };

            array.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [Fact]
        public void IndexOf_ShouldReturnMinusOne_WhenItemIsNotInTheList()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.IndexOf(4).Should().Be(-1);
        }

        [Fact]
        public void IndexOf_ShouldReturnPositiveIndex_WhenItemIsInTheList()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.IndexOf(3).Should().Be(2);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        public void Insert_ShouldThrow_WhenIndexIsOutsideTheListLimits(int index)
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            Action insert = () => list.Insert(index, 0);

            insert.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Insert_ShouldModifyTheList_WhenIndexIsInsideTheListLimits(int index)
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.Insert(index, 0);

            list.Count.Should().Be(4);
            list[index].Should().Be(0);
        }

        [Theory]
        [InlineData(1, 1, 2, 3)]
        [InlineData(1, 1)]
        [InlineData(2, 1, 2, 3)]
        [InlineData(3, 1, 2, 3)]
        public void Remove_ShouldReturnTrueAndModifyTheList_WhenItemIsFound(int itemToFind, params int[] listItems)
        {
            var list = new SingleLinkedList<int>();
            foreach (var item in listItems)
            {
                list.Add(item);
            }

            var result = list.Remove(itemToFind);
            var expected = listItems.Except(new int[] { itemToFind });

            result.Should().BeTrue();
            list.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [Fact]
        public void Remove_ShouldReturnFalseAndNotModifyTheList_WhenItemIsNotFound()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            var result = list.Remove(0);
            var expected = new int[] { 1, 2, 3 };

            result.Should().BeFalse();
            list.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1, 1, 2, 3)]
        [InlineData(3, 1, 2, 3)]
        public void RemoveAt_ShouldThrow_WhenIndexIsOutsideTheListLimits(int indexToRemove, params int[] listItems)
        {
            var list = new SingleLinkedList<int>();
            foreach (var item in listItems)
            {
                list.Add(item);
            }

            Action removeAt = () => list.RemoveAt(indexToRemove);

            removeAt.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 1, 2, 3)]
        [InlineData(1, 1, 2, 3)]
        [InlineData(2, 1, 2, 3)]
        public void RemoveAt_ShouldModifyTheList_WhenIndexIsInsideTheListLimits(int indexToRemove, params int[] listItems)
        {
            var list = new SingleLinkedList<int>();
            foreach (var item in listItems)
            {
                list.Add(item);
            }

            list.RemoveAt(indexToRemove);
            var expected = listItems.ToList();
            expected.RemoveAt(indexToRemove);

            list.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void GetEnumerator_ShouldReturnTraversableEnumerator(int listLength)
        {
            var list = new SingleLinkedList<int>();
            for (int i = 0; i < listLength; i++)
            {
                list.Add(i);
            }

            var enumerator = list.GetEnumerator();

            for (int i = 0; i < listLength; i++)
            {
                enumerator.MoveNext().Should().BeTrue();
                enumerator.Current.Should().Be(i);
            }

            enumerator.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void AddRange_ShouldModifyAnEmptyList_WhenTheEnumerableToAppendIsNotEmpty()
        {
            var toAppend = new int[] { 1, 2, 3 };
            var list = new SingleLinkedList<int>();

            list.AddRange(toAppend);

            list.Count.Should().Be(toAppend.Length);
            list.Should().BeEquivalentTo(toAppend, options => options.WithStrictOrdering());
        }

        [Fact]
        public void AddRange_ShouldModifyANonEmptyList_WhenTheEnumerableToAppendIsNotEmpty()
        {
            var toAppend = new int[] { 4, 5, 6 };
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.AddRange(toAppend);
            var expected = new int[] { 1, 2, 3, 4, 5, 6 };

            list.Count.Should().Be(expected.Length);
            list.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [Fact]
        public void AddRange_ShouldNotModifyList_WhenTheEnumerableToAppendIsEmpty()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.AddRange(new int[0]);

            list.Count.Should().Be(3);
            list.Should().BeEquivalentTo(new int[] { 1, 2, 3 }, options => options.WithStrictOrdering());
        }

        [Fact]
        public void Exists_ShouldReturnTrue_WhenAnItemMatchesThePredicate()
        {
            static bool predicate(int x) => x == 1;
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.Exists(predicate).Should().BeTrue();
        }

        [Fact]
        public void Exists_ShouldReturnFalse_WhenListIsNotEmptyAndNoItemMatchesThePredicate()
        {
            static bool predicate(int x) => x == 1;
            var list = new SingleLinkedList<int> { 2, 3 };

            list.Exists(predicate).Should().BeFalse();
        }
        
        [Fact]
        public void Exists_ShouldReturnFalse_WhenListIsEmpty()
        {
            static bool predicate(int x) => x == 1;
            var list = new SingleLinkedList<int>();

            list.Exists(predicate).Should().BeFalse();
        }

        [Fact]
        public void Find_ShouldReturnDefault_WhenNoItemMatches()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.Find(IsDivisibleByFour).Should().Be(default);
        }

        [Fact]
        public void Find_ShouldReturnTheFirstMatchingItem_WhenAtLeastOneItemMatches()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3, 4, 8 };

            list.Find(IsDivisibleByFour).Should().Be(4);
        }

        [Fact]
        public void FindAll_ShouldReturnMatchingElements_WhenAtLeastOneItemMatches()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3, 4, 8 };

            list.FindAll(IsDivisibleByFour).Should().BeEquivalentTo(new int[] { 4, 8 });
        }

        [Fact]
        public void FindAll_ShouldReturnEmptyList_WhenNoItemMatches()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.FindAll(IsDivisibleByFour).Should().BeEquivalentTo(new int[0]);
        }

        [Fact]
        public void FindIndex_ShouldReturnFirstMatchingItemIndex_WhenAtLeastOneItemMatches()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3, 4, 8 };

            list.FindIndex(IsDivisibleByFour).Should().Be(3);
        }

        [Fact]
        public void FindIndex_ShouldReturnMinusOne_WhenNoItemMatches()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            list.FindIndex(IsDivisibleByFour).Should().Be(-1);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(3)]
        public void FindIndexWithStartIndex_ShouldThrow_WhenIndexIsOutsideTheListLimits(int startIndex)
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            Func<int> findIndex = () => list.FindIndex(startIndex, IsDivisibleByFour);

            findIndex.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void FindIndexWithStartIndex_ShouldReturnFirstMatchingItemIndexFromStartIndex_WhenAtLeastOneItemMatchesFromStartIndex()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3, 4, 5, 8, 16 };

            list.FindIndex(4, IsDivisibleByFour).Should().Be(5);
        }

        [Fact]
        public void FindIndexWithStartIndex_ShouldReturnMinusOne_WhenNoItemMatchesFromStartIndex()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3, 4, 5, 7 };

            list.FindIndex(4, IsDivisibleByFour).Should().Be(-1);
        }

        private static bool IsDivisibleByFour(int x) => x % 4 == 0;
    }
}
