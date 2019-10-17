using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests
{
    public class ArrayList_Tests
    {
        [Fact]
        public void Add_ShouldModifyTheList()
        {
            var list = new ArrayList<int>();

            list.Add(3);

            list.Count.Should().Be(1);
            list[0].Should().Be(3);
        }
    }
}
