using System;
using System.Text;
using DataStructures.Trees;
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
        where TTree : IBinaryTree<object>, new()
    {
        /*

            Tree (1 2 3 4 5 6 7) :

                      1
                  2       3
                4   5   6   7

        */

        public static TheoryData<object[], string> MemberData_Bfs => new TheoryData<object[], string>
        {
            { new object[] { }, string.Empty },
            { new object[] { 1, 2, 3 }, "1 2 3" },
            { new object[] { 1, 2, 3, 4, 5, 6, 7 }, "1 2 3 4 5 6 7" }
        };

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
        [MemberData(nameof(MemberData_Bfs))]
        public void Bfs_ShouldInvokeActionInABfsTraversal(object[] values, string traversalExpectedString)
        {
            BinaryTreeHelpers.TestOrderMethod<TTree, object>(tree => tree.Bfs, values, traversalExpectedString);
        }

        [Theory]
        [MemberData(nameof(MemberData_InOrderTraversal))]
        public void InOrder_ShouldInvokeActionInAnInOrderTraversal(object[] values, string traversalExpectedString)
        {
            BinaryTreeHelpers.TestOrderMethod<TTree, object>(tree => tree.InOrder, values, traversalExpectedString);
        }

        [Theory]
        [MemberData(nameof(MemberData_PostOrderTraversal))]
        public void PostOrder_ShouldInvokeActionInAPostOrderTraversal(object[] values, string traversalExpectedString)
        {
            BinaryTreeHelpers.TestOrderMethod<TTree, object>(tree => tree.PostOrder, values, traversalExpectedString);
        }

        [Theory]
        [MemberData(nameof(MemberData_PreOrderTraversal))]
        public void PreOrder_ShouldInvokeActionInAPreOrderTraversal(object[] values, string traversalExpectedString)
        {
            BinaryTreeHelpers.TestOrderMethod<TTree, object>(tree => tree.PreOrder, values, traversalExpectedString);
        }
    }
}