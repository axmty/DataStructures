using DataStructures.Interfaces;
using Xunit;

namespace DataStructures.UnitTests
{
    public abstract class ArrayStack_Tests
    {
        public static TheoryData<object[], object, object[]> MemberData_Push => new TheoryData<object[], object, object[]>
        {
            { new object[] { }, 1, new object[] { 1 } },
            { new object[] { 1, 2 }, 3, new object[] { 1, 2, 3 } }
        };

        //[Theory]
        //[MemberData(nameof(MemberData_Add))]
        //public void Add_ShouldModifyTheList(object[] initial, object toAdd, object[] expected)
        //{
        //    var list = this.Build(initial);
        //}

        private ArrayStack<object> Build(object[] items)
        {
            var stack = new ArrayStack<object>();

            foreach (var item in items)
            {
                stack.Push(item);
            }

            return stack;
        }
    }
}