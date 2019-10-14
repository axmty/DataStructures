using Xunit;
using FluentAssertions;

namespace DataStructures.UnitTests
{
    public class SingleLinkedList_Tests
    {
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
    }
}
