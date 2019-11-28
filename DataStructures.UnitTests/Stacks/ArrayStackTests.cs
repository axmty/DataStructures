using System;
using DataStructures.Stacks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests.Stacks
{
    public class ArrayStackTests
    {
        [Theory]
        [MemberData(nameof(MemberData_IndexOf_ReturnsIndexOfSearchedElementOrMinusOne))]
        public void IndexOf_ReturnsIndexOfSearchedElementOrMinusOne(object[] initial, object toFind, int index)
        {
            var list = this.Build(initial);

            list.IndexOf(toFind).Should().Be(index);
            this.Compare(list, initial);
        }

        public static TheoryData<object[], object, object[]> MemberData_IsEmpty_ReturnsTrueIfAndOnlyIfTheStackIsEmpty => new TheoryData<object[], object, object[]>
        {
            { new object[] { }, 1, new object[] { 1 } },
            { new object[] { 1, 2 }, 3, new object[] { 1, 2, 3 } }
        };

        [Theory]
        [MemberData(nameof(MemberData_IsEmpty_ReturnsTrueIfAndOnlyIfTheStackIsEmpty))]
        public void IsEmpty_ReturnsTrueIfAndOnlyIfTheStackIsEmpty(object[] initial, int length)
        {
            var stack = this.Build(;

            stack.IsEmpty().Should().BeTrue();
            FluentActions.Invoking(() => stack.Peek()).Should().Throw<InvalidOperationException>();
            FluentActions.Invoking(() => stack.Pop()).Should().Throw<InvalidOperationException>();
            stack.Push(1);
            stack.Peek().Should().Be(1);
            stack.Push(2);
            FluentActions.Invoking(() => stack.Push(3)).Should().Throw<InvalidOperationException>();
            stack.Peek().Should().Be(2);
            stack.Pop().Should().Be(2);
            stack.Pop().Should().Be(1);
            stack.IsEmpty().Should().BeTrue();
        }

        private ArrayStack<object> Build(object[] items, int length)
        {
            var stack = new ArrayStack<object>(length);

            foreach (var item in items)
            {
                stack.Push(item);
            }

            return stack;
        }
    }
}