using System;
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
        public static TheoryData<object[], string> MemberData_InOrderTraversal => new TheoryData<object[], string>
        {
            { new object[] { }, string.Empty },
            { new object[] { 1, 2, 3 }, "2 1 3" },
            { new object[] { 1, 2, 3, 4, 5, 6, 7 }, "4 2 5 1 6 3 7" }
        };

        public static TheoryData<object[], string> MemberData_PostOrderTraversal => new TheoryData<object[], string>
        {
            { new object[] { }, string.Empty },
            { new object[] { 1, 2, 3 }, "2 3 1" },
            { new object[] { 1, 2, 3, 4, 5, 6, 7 }, "4 5 2 6 7 3 1" }
        };

        public static TheoryData<object[], string> MemberData_PreOrderTraversal => new TheoryData<object[], string>
        {
            { new object[] { }, string.Empty },
            { new object[] { 1, 2, 3 }, "1 2 3" },
            { new object[] { 1, 2, 3, 4, 5, 6, 7 }, "1 2 4 5 3 6 7" }
        };

        [Theory]
        [MemberData(nameof(MemberData_InOrderTraversal))]
        public void InOrder_ShouldInvokeActionInAnInOrderTraversal(object[] values, string traversalExpectedString)
        {
            this.TestOrderMethod(tree => tree.InOrder, values, traversalExpectedString);
        }

        [Theory]
        [MemberData(nameof(MemberData_PostOrderTraversal))]
        public void PostOrder_ShouldInvokeActionInAPostOrderTraversal(object[] values, string traversalExpectedString)
        {
            this.TestOrderMethod(tree => tree.PostOrder, values, traversalExpectedString);
        }

        [Theory]
        [MemberData(nameof(MemberData_PreOrderTraversal))]
        public void PreOrder_ShouldInvokeActionInAPreOrderTraversal(object[] values, string traversalExpectedString)
        {
            this.TestOrderMethod(tree => tree.PreOrder, values, traversalExpectedString);
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

        private void TestOrderMethod(Func<TTree, Action<Action<object>>> orderMethodSelector, object[] values, string traversalExpectedString)
        {
            var tree = this.Build(values);
            var toString = new StringBuilder();

            orderMethodSelector(tree)((item) => toString.Append($" {item}"));

            toString.ToString().Trim().Should().Be(traversalExpectedString);
        }
    }
}