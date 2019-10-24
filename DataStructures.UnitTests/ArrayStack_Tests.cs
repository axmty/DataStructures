using DataStructures.Interfaces;
using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests
{
    public class ArrayStack_Tests
    {
        [Fact]
        public void TestStack()
        {
            var stack = new ArrayStack<object>(2);

            stack.IsEmpty().Should().BeTrue();
            stack.Push(1);
            stack.Peek().Should().Be(1);
            stack.Push(2);
            stack.Peek().Should().Be(2);
            stack.Pop().Should().Be(2);
            stack.Pop().Should().Be(1);
            stack.IsEmpty().Should().BeTrue();
        }
    }
}