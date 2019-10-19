using FluentAssertions;
using System;
using Xunit;

namespace DataStructures.UnitTests
{
    public class ArrayList_Tests
    {
        [Fact]
        public void Add_ShouldModifyTheList()
        {
            var list = new ArrayList<int> { 3, 4, 5 };

            list.Count.Should().Be(3);
            list[0].Should().Be(3);
            list[1].Should().Be(4);
            list[2].Should().Be(5);
        }

        [Fact]
        public void Clear_ShouldModifyANonEmptyListToAnEmptyOne()
        {
            var list = new ArrayList<int> { 1, 2, 3 };

            list.Clear();

            list.Count.Should().Be(0);
            GetAndSetAt(list, 0).Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenListHoldsTheItem()
        {
            var list = new ArrayList<int> { 1, 2, 3 };

            list.Contains(3).Should().BeTrue();
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenListDoesNotHoldTheItem()
        {
            var list = new ArrayList<int> { 1, 2, 3 };

            list.Contains(4).Should().BeTrue();
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenListIsEmpty()
        {
            var list = new ArrayList<int>();

            list.Contains(0).Should().BeFalse();
        }

        private static Action GetAndSetAt<T>(ArrayList<T> list, int index)
        {
            return () =>
            {
                var x = list[index];
                list[index] = default;
            };
        }
    }
}
