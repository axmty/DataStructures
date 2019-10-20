using System;
using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests
{
    /// <summary>
    /// Base class to share the unit tests of the <see cref="Interfaces.IList{T}"/> implementations.
    /// </summary>
    /// <typeparam name="TList">
    /// The implementation of <see cref="Interfaces.IList{T}"/> to unit test.
    /// </typeparam>
    public abstract class BaseIlist_Tests<TList>
        where TList : Interfaces.IList<int>, new()
    {
        [Fact]
        public void Add_ShouldModifyTheList()
        {
            var list = new TList();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Count.Should().Be(3);
            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list[2].Should().Be(3);
        }

        [Fact]
        public void Clear_ShouldEmptyTheList()
        {
            var list = new TList { 1, 2, 3 };

            list.Clear();

            list.Count.Should().Be(0);
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(3, true)]
        public void Indexer_ShouldThrowIndexOutOfRange_WhenIndexIsNotInAValidRange(int index, bool shouldThrow)
        {
            var list = new TList { 1, 2, 3 };

            Action indexing = () =>
            {
                var x = list[index];
                list[index] = 0;
            };

            if (shouldThrow)
                indexing.Should().ThrowExactly<IndexOutOfRangeException>();
            else
                indexing.Should().NotThrow();
        }
    }
}