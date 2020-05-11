using System;
using System.Linq;
using DataStructures.Stacks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests.Stacks
{
    public class ArrayStackTests
    {
        public static TheoryData<object[], bool> MemberData_IsEmpty_ReturnsTrueIfAndOnlyIfTheStackIsEmpty => new TheoryData<object[], bool>
        {
            { new object[] { }, true },
            { new object[] { 1 }, false }
        };

        public static TheoryData<object[]> MemberData_Peek_ReturnsTheTopObjectOfTheStack_WhenNotEmpty => new TheoryData<object[]>
        {
            { new object[] { 1 } },
            { new object[] { 1, 2 } }
        };

        public static TheoryData<object[], object> MemberData_Push_AddsAPeekableObjectOnTopOfTheStack => new TheoryData<object[], object>
        {
            { new object[] { }, 1 },
            { new object[] { 1 }, 2 }
        };

        [Theory]
        [MemberData(nameof(MemberData_IsEmpty_ReturnsTrueIfAndOnlyIfTheStackIsEmpty))]
        public void IsEmpty_ReturnsTrueIfAndOnlyIfTheStackIsEmpty(object[] initial, bool expected)
        {
            var stack = this.Build(initial, 10);

            stack.IsEmpty().Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(MemberData_Peek_ReturnsTheTopObjectOfTheStack_WhenNotEmpty))]
        public void Peek_ReturnsTheTopObjectOfTheStack_WhenNotEmpty(object[] initial)
        {
            var stack = this.Build(initial, 10);

            stack.Peek().Should().Be(initial.Last());
        }

        [Fact]
        public void Peek_ThrowsInvalidOperationException_WhenStackIsEmpty()
        {
            var stack = new ArrayStack<object>(1);

            FluentActions.Invoking(() => stack.Peek()).Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [MemberData(nameof(MemberData_Push_AddsAPeekableObjectOnTopOfTheStack))]
        public void Push_AddsAPeekableObjectOnTopOfTheStack(object[] initial, object toPush)
        {
            var stack = this.Build(initial, 10);

            stack.Push(toPush);

            stack.Peek().Should().Be(toPush);
        }

        [Fact]
        public void Push_ThrowsInvalidOperationException_WhenStackIsFull()
        {
            var stack = this.Build(new object[] { 1, 2 }, 2);

            FluentActions.Invoking(() => stack.Push(1)).Should().Throw<InvalidOperationException>();
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