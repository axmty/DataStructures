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

        [Theory]
        [MemberData(nameof(MemberData_Push_AddsAPeekableObjectOnTopOfTheStack))]
        public void Push_AddsAPeekableObjectOnTopOfTheStack(object[] initial, object toPush)
        {
            var stack = this.Build(initial, 10);

            stack.Push(toPush);

            stack.Peek().Should().Be(toPush);
        }

        //stack.IsEmpty().Should().BeTrue();
        //FluentActions.Invoking(() => stack.Peek()).Should().Throw<InvalidOperationException>();
        //    FluentActions.Invoking(() => stack.Pop()).Should().Throw<InvalidOperationException>();
        //    stack.Push(1);
        //    stack.Peek().Should().Be(1);
        //stack.Push(2);
        //    FluentActions.Invoking(() => stack.Push(3)).Should().Throw<InvalidOperationException>();
        //    stack.Peek().Should().Be(2);
        //stack.Pop().Should().Be(2);
        //stack.Pop().Should().Be(1);
        //stack.IsEmpty().Should().BeTrue();

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