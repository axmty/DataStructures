using System;
using DataStructures.Interfaces;
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
    public abstract class BaseIList_Tests<TList>
        where TList : IList<object>, new()
    {
        public static TheoryData<object[], object, object[]> Add => new TheoryData<object[], object, object[]>
        {
            { new object[] { }, 1, new object[] { 1 } },
            { new object[] { 1, 2 }, 3, new object[] { 1, 2, 3 } }
        };

        public static TheoryData<object[], object[]> Clear => new TheoryData<object[], object[]>
        {
            { new object[] { }, new object[] { } },
            { new object[] { 1, 2 }, new object[] { } }
        };

        public static TheoryData<object[], object, bool> Contains => new TheoryData<object[], object, bool>
        {
            { new object[] { }, 1, false },
            { new object[] { 1, 2, 3 }, 1, true },
            { new object[] { 1, 2, 3 }, 4, false },
            { new object[] { 1, 2, 3 }, null, false },
            { new object[] { 1, 2, null }, null, true },
            { new object[] { 1, 2, null }, 4, false }
        };

        [Theory]
        [MemberData(nameof(Add))]
        public void Add_ShouldModifyTheList(object[] initial, object toAdd, object[] expected)
        {
            var list = this.Build(initial);

            list.Add(toAdd);

            this.Compare(list, expected);
        }

        [Theory]
        [MemberData(nameof(Clear))]
        public void Clear_ShouldEmptyTheList(object[] initial, object[] expected)
        {
            var list = this.Build(initial);

            list.Clear();

            this.Compare(list, expected);
        }

        [Theory]
        [MemberData(nameof(Contains))]
        public void Contains_ShouldReturnTrue_WhenTheListHoldsTheItem(object[] initial, object seek, bool expected)
        {
            var list = this.Build(initial);

            list.Contains(seek).Should().Be(expected);
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
            {
                indexing.Should().ThrowExactly<IndexOutOfRangeException>();
            }
            else
            {
                indexing.Should().NotThrow();
            }
        }

        private TList Build(object[] items)
        {
            var list = new TList();

            foreach (var item in items)
            {
                list.Add(item);
            }

            return list;
        }

        private void Compare(IList<object> list, object[] expected)
        {
            list.Count.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                list[i].Should().Be(expected[i]);
            }
        }
    }
}