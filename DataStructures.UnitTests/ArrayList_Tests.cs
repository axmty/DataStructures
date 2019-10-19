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
    }
}
