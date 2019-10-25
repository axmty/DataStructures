using System.Text;
using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests
{
    /// <summary>
    /// Base class to share the unit tests of the <see cref="Interfaces.IBinaryTree{T}"/> implementations.
    /// </summary>
    /// <typeparam name="TTree">
    /// The implementation of <see cref="Interfaces.IBinaryTree{T}"/> to unit test.
    /// </typeparam>
    public abstract class BaseIBinaryTree_Tests<TTree>
        where TTree : Interfaces.IBinaryTree<object>, new()
    {
        public static TheoryData<object[], string> MemberData_Traversal => new TheoryData<object[], string>
        {
            { new object[] { }, string.Empty },
            { new object[] { 1, 2, 3 }, "2 1 3" },
            { new object[] { 1, 2, 3, 4, 5, 6, 7 }, "4 2 5 1 6 3 7" }
        };

        [Theory]
        [MemberData(nameof(MemberData_Traversal))]
        public void InOrder_ShouldInvokeActionInAnInOrderTraversal(object[] values, string traversalExpectedString)
        {
            var tree = this.Build(values);
            var toString = new StringBuilder();

            tree.InOrder((item) => toString.Append($" {item}"));

            toString.ToString().Trim().Should().Be(traversalExpectedString);
        }

        private TTree Build(object[] values)
        {
            var tree = new TTree();

            foreach (var value in values)
            {
                tree.Add(value);
            }

            return tree;
        }
    }
}