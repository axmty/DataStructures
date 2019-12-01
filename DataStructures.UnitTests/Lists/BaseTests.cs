using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests.Lists
{
    /// <summary>
    /// Base class to share the unit test logic of the <see cref="Interfaces.IList{T}"/> implementations.
    /// </summary>
    /// <typeparam name="TList">
    /// The implementation of <see cref="Interfaces.IList{T}"/> to unit test.
    /// </typeparam>
    public abstract class BaseTests<TList>
        where TList : DataStructures.Lists.IList<object>, new()
    {
        public static TheoryData<object[], object, object[]> MemberData_Add_ModifiesTheList => new TheoryData<object[], object, object[]>
        {
            { new object[] { }, 1, new object[] { 1 } },
            { new object[] { 1, 2 }, 3, new object[] { 1, 2, 3 } }
        };

        public static TheoryData<object[], object[]> MemberData_Clear_EmptiesTheList => new TheoryData<object[], object[]>
        {
            { new object[] { }, new object[] { } },
            { new object[] { 1, 2 }, new object[] { } }
        };

        public static TheoryData<object[], object, bool> MemberData_Contains_ReturnsTrue_WhenTheListHoldsTheItem => new TheoryData<object[], object, bool>
        {
            { new object[] { }, 1, false },
            { new object[] { 1, 2, 3 }, 1, true },
            { new object[] { 1, 2, 3 }, 4, false },
            { new object[] { 1, 2, 3 }, null, false },
            { new object[] { 1, 2, null }, null, true },
            { new object[] { 1, 2, null }, 4, false }
        };

        public static TheoryData<object[], object[], int, object[]> MemberData_CopyTo_ModifiesDestinationArray => new TheoryData<object[], object[], int, object[]>
        {
            { new object[] { }, new object[] { 1, 2, 3 }, 2, new object[] { 1, 2, 3 } },
            { new object[] { 4, 5, 6 }, new object[] { 1, 2, 3, 4, 5, 6 }, 0, new object[] { 4, 5, 6, 4, 5, 6 } },
            { new object[] { 1, 2, 3 }, new object[] { 1, 2, 3, 4, 5, 6 }, 3, new object[] { 1, 2, 3, 1, 2, 3 } }
        };

        public static TheoryData<object[], object[], int, Type> MemberData_CopyTo_Throws_WhenArgumentsAreNotValid => new TheoryData<object[], object[], int, Type>
        {
            { new object[] { }, null, 4, typeof(ArgumentNullException) },
            { new object[] { }, new object[4], -1, typeof(ArgumentOutOfRangeException) },
            { new object[] { }, new object[4], 4, typeof(ArgumentOutOfRangeException) },
            { new object[] { 1, 2, 3 }, new object[] { 1, 2, 3, 4, 5, 6 }, 4, typeof(ArgumentOutOfRangeException) }
        };

        public static TheoryData<object[], Predicate<object>, bool> MemberData_Exists_ReturnsTrue_WhenAnItemMatches => new TheoryData<object[], Predicate<object>, bool>
        {
            { new object[] { }, item => (int)item % 2 == 0, false },
            { new object[] { 1, 2, 3 }, item => (int)item % 2 == 0, true },
            { new object[] { 1, 3, 5 }, item => (int)item % 2 == 0, false },
            { new object[] { 1, null, 5 }, item => EqualityComparer<object>.Default.Equals(item, null), true }
        };

        public static TheoryData<object[], Predicate<object>, object> MemberData_Find_ReturnsTheFirstMatchingItemOrDefault => new TheoryData<object[], Predicate<object>, object>
        {
            { new object[] { }, item => (int)item % 2 == 0, null },
            { new object[] { 1, 2, 3 }, item => (int)item % 2 == 0, 2 },
            { new object[] { 1, 3, 5 }, item => (int)item % 2 == 0, null },
            { new object[] { 1, null, 5 }, item => EqualityComparer<object>.Default.Equals(item, null), null }
        };

        public static TheoryData<object[], Predicate<object>, object> MemberData_FindAll_ReturnsAllMatchingItems => new TheoryData<object[], Predicate<object>, object>
        {
            { new object[] { }, item => (int)item % 2 == 0, new object[] { } },
            { new object[] { 1, 2, 3, 4 }, item => (int)item % 2 == 0, new object[] { 2, 4 } },
            { new object[] { 1, 3, 5, 7 }, item => (int)item % 2 == 0, new object[] { } },
            { new object[] { 1, null, 5, null }, item => EqualityComparer<object>.Default.Equals(item, null), new object[] { null, null } }
        };

        public static TheoryData<object[], Action<object>> MemberData_ForEach_InvokesActionForAllTheItems => new TheoryData<object[], Action<object>>
        {
            { new object[] { }, item => item = (int)item + 1 },
            { new object[] { 0, 1, 2 }, item => item = (int)item + 1 }
        };

        public static TheoryData<object[], int, object> MemberData_Indexer_ReturnsIndexAtTheSpecifiedIndex_WhenInValidRange => new TheoryData<object[], int, object>
        {
            { new object[] { 1, 2, 3 }, 0, 1 },
            { new object[] { 1, 2, 3 }, 1, 2 },
            { new object[] { 1, 2, 3 }, 2, 3 }
        };

        public static TheoryData<object[], int, bool> MemberData_Indexer_ThrowsIndexOutOfRange_WhenIndexIsNotInAValidRange => new TheoryData<object[], int, bool>
        {
            { new object[] { }, 0, true },
            { new object[] { 1, 2 }, -1, true },
            { new object[] { 1, 2 }, 2, true },
            { new object[] { 1, 2 }, 0, false },
            { new object[] { 1, 2 }, 1, false }
        };

        public static TheoryData<object[], object, int> MemberData_IndexOf_ReturnsIndexOfSearchedElementOrMinusOne => new TheoryData<object[], object, int>
        {
            { new object[] { }, 1, -1 },
            { new object[] { 1, 2, 3 }, null, -1 },
            { new object[] { null, 2, 3 }, 2, 1 }
        };

        [Theory]
        [MemberData(nameof(MemberData_Add_ModifiesTheList))]
        public void Add_ModifiesTheList(object[] initial, object toAdd, object[] expected)
        {
            var list = this.Build(initial);

            list.Add(toAdd);

            this.Compare(list, expected);
        }

        [Theory]
        [MemberData(nameof(MemberData_Clear_EmptiesTheList))]
        public void Clear_EmptiesTheList(object[] initial, object[] expected)
        {
            var list = this.Build(initial);

            list.Clear();

            this.Compare(list, expected);
        }

        [Theory]
        [MemberData(nameof(MemberData_Contains_ReturnsTrue_WhenTheListHoldsTheItem))]
        public void Contains_ReturnsTrue_WhenTheListHoldsTheItem(object[] initial, object seek, bool expected)
        {
            var list = this.Build(initial);

            list.Contains(seek).Should().Be(expected);
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_CopyTo_ModifiesDestinationArray))]
        public void CopyTo_ModifiesDestinationArray(object[] initial, object[] destinationArray, int arrayIndex, object[] expectedArray)
        {
            var list = this.Build(initial);

            list.CopyTo(destinationArray, arrayIndex);

            destinationArray.Should().BeEquivalentTo(expectedArray, options => options.WithStrictOrdering());
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_CopyTo_Throws_WhenArgumentsAreNotValid))]
        public void CopyTo_Throws_WhenArgumentsAreNotValid(object[] initial, object[] destinationArray, int arrayIndex, Type exceptionType)
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
        [MemberData(nameof(MemberData_Exists_ReturnsTrue_WhenAnItemMatches))]
        public void Exists_ReturnsTrue_WhenAnItemMatches(object[] initial, Predicate<object> match, bool expected)
        {
            var list = this.Build(initial);

            list.Exists(match).Should().Be(expected);
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_Find_ReturnsTheFirstMatchingItemOrDefault))]
        public void Find_ReturnsTheFirstMatchingItemOrDefault(object[] initial, Predicate<object> match, object expected)
        {
            var list = this.Build(initial);

            list.Find(match).Should().Be(expected);
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_FindAll_ReturnsAllMatchingItems))]
        public void FindAll_ReturnsAllMatchingItems(object[] initial, Predicate<object> match, object[] expected)
        {
            var list = this.Build(initial);

            list.FindAll(match).Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_ForEach_InvokesActionForAllTheItems))]
        public void ForEach_InvokesActionForAllTheItems(object[] initial, Action<object> action)
        {
            var list = this.Build(initial);

            list.ForEach(action);
            this.Compare(list, initial);
        }

        [Theory]
        [MemberData(nameof(MemberData_Indexer_ReturnsIndexAtTheSpecifiedIndex_WhenInValidRange))]
        public void Indexer_ReturnsIndexAtTheSpecifiedIndex_WhenInValidRange(object[] initial, int index, object expected)
        {
            var list = this.Build(initial);

            list[index].Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(MemberData_Indexer_ThrowsIndexOutOfRange_WhenIndexIsNotInAValidRange))]
        public void Indexer_ThrowsIndexOutOfRange_WhenIndexIsNotInAValidRange(object[] initial, int index, bool shouldThrow)
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

        [Theory]
        [MemberData(nameof(MemberData_IndexOf_ReturnsIndexOfSearchedElementOrMinusOne))]
        public void IndexOf_ReturnsIndexOfSearchedElementOrMinusOne(object[] initial, object toFind, int index)
        {
            var list = this.Build(initial);

            list.IndexOf(toFind).Should().Be(index);
            this.Compare(list, initial);
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