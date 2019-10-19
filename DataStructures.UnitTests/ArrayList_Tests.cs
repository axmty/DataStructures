using FluentAssertions;
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
        }
    }
}
