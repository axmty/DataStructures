using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests
{
    public abstract class BaseIlist_Tests<TList>
        where TList : Interfaces.IList<int>, new()
    {
        [Fact]
        public void Add_ShouldModifyTheList()
        {
            var list = new TList();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Count.Should().Be(3);
            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list[2].Should().Be(3);
        }
    }
}