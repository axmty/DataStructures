using Xunit;
using FluentAssertions;
using System;

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

            copyTo.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CopyTo_ShouldThrow_WhenArraySpaceFromIndexIsNotLargeEnough()
        {
            var list = new SingleLinkedList<int> { 1, 2, 3 };

            Action copyTo = () => list.CopyTo(new int[1], 0);

            copyTo.Should().Throw<ArgumentException>();
        }
    }
}
