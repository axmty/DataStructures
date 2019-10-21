using System;
using System.Collections.Generic;
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
        where TList : Interfaces.IList<object>, new()
    {
        public static TheoryData<object[], object, object[]> MemberData_Add => new TheoryData<object[], object, object[]>
        {
            { new object[] { }, 1, new object[] { 1 } },
            { new object[] { 1, 2 }, 3, new object[] { 1, 2, 3 } }
        };

        public static TheoryData<object[], object[]> MemberData_Clear => new TheoryData<object[], object[]>
        {
            { new object[] { }, new object[] { } },
            { new object[] { 1, 2 }, new object[] { } }
        };

        public static TheoryData<object[], object, bool> MemberData_Contains => new TheoryData<object[], object, bool>
        {
            { new object[] { }, 1, false },
            { new object[] { 1, 2, 3 }, 1, true },
            { new object[] { 1, 2, 3 }, 4, false },
            { new object[] { 1, 2, 3 }, null, false },
            { new object[] { 1, 2, null }, null, true },
            { new object[] { 1, 2, null }, 4, false }
        };

        public static TheoryData<object[], object[], int, Type> MemberData_CopyTo_NotValid => new TheoryData<object[], object[], int, Type>
        {
            { new object[] { }, null, 4, typeof(ArgumentNullException) },
            { new object[] { }, new object[4], -1, typeof(ArgumentOutOfRangeException) },
            { new object[] { }, new object[4], 4, typeof(ArgumentOutOfRangeException) },
            { new object[] { 1, 2, 3 }, new object[] { 1, 2, 3, 4, 5, 6 }, 4, typeof(ArgumentOutOfRangeException) }
        };

        public static TheoryData<object[], object[], int, object[]> MemberData_CopyTo_Valid => new TheoryData<object[], object[], int, object[]>
        {
            { new object[] { }, new object[] { 1, 2, 3 }, 2, new object[] { 1, 2, 3 } },
            { new object[] { 4, 5, 6 }, new object[] { 1, 2, 3, 4, 5, 6 }, 0, new object[] { 4, 5, 6, 4, 5, 6 } },
            { new object[] { 1, 2, 3 }, new object[] { 1, 2, 3, 4, 5, 6 }, 3, new object[] { 1, 2, 3, 1, 2, 3 } }
        };

        public static TheoryData<object[], Predicate<object>, bool> MemberData_Exists => new TheoryData<object[], Predicate<object>, bool>
        {
            { new object[] { }, item => (int)item % 2 == 0, false },
            { new object[] { 1, 2, 3 }, item => (int)item % 2 == 0, true },
            { new object[] { 1, 3, 5 }, item => (int)item % 2 == 0, false },
            { new object[] { 1, null, 5 }, item => EqualityComparer<object>.Default.Equals(item, null), true }
        };

        public static TheoryData<object[], int, bool> MemberData_Indexer => new TheoryData<object[], int, bool>
        {
            { new object[] { }, 0, true },
            { new object[] { 1, 2 }, -1, true },
            { new object[] { 1, 2 }, 2, true },
            { new object[] { 1, 2 }, 0, false },
            { new object[] { 1, 2 }, 1, false }
        };

        [Theory]
        [MemberData(nameof(MemberData_Add))]
        public void Add_ShouldModifyTheList(object[] initial, object toAdd, object[] expected)
        {
            var list = this.Build(initial);

            list.Add(toAdd);

            this.Compare(list, expected);
        }

        [Theory]
        [MemberData(nameof(MemberData_Clear))]
        public void Clear_ShouldEmptyTheList(object[] initial, object[] expected)
        {
            var list = this.Build(initial);

            list.Clear();

            this.Compare(list, expected);
        }

        [Theory]
        [MemberData(nameof(MemberData_Contains))]
        public void Contains_ShouldReturnTrue_WhenTheListHoldsTheItem(object[] initial, object seek, bool expected)
        {
            var list = this.Build(initial);

            list.Contains(seek).Should().Be(expected);
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_CopyTo_Valid))]
        public void CopyTo_ShouldModifyDestinationArray(object[] initial, object[] destinationArray, int arrayIndex, object[] expectedArray)
        {
            var list = this.Build(initial);

            list.CopyTo(destinationArray, arrayIndex);

            destinationArray.Should().BeEquivalentTo(expectedArray, options => options.WithStrictOrdering());
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_CopyTo_NotValid))]
        public void CopyTo_ShouldThrow_WhenArgumentsAreNotValid(object[] initial, object[] destinationArray, int arrayIndex, Type exceptionType)
        {
            var list = this.Build(initial);

            FluentActions
                .Invoking(() => list.CopyTo(destinationArray, arrayIndex))
                .Should()
                .Throw<Exception>()
                .Which
                .Should()
                .BeOfType(exceptionType);
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_Exists))]
        public void Exists_ShouldReturnTrue_WhenAnItemMatches(object[] initial, Predicate<object> match, bool expected)
        {
            var list = this.Build(initial);

            list.Exists(match).Should().Be(expected);
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_Indexer))]
        public void Indexer_ShouldThrowIndexOutOfRange_WhenIndexIsNotInAValidRange(object[] initial, int index, bool shouldThrow)
        {
            var list = this.Build(initial);

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

        private void Compare(TList list, object[] expected)
        {
            list.Count.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                list[i].Should().Be(expected[i]);
            }
        }
    }
}