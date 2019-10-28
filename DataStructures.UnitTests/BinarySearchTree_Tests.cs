using DataStructures.Trees;
using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests
{
    public class BinarySearchTree_Tests
    {
        /*

            Tree (4 2 1 3 7 6 5) :

                      4
                2           7
              1   3       6
                        5
        */

        public static TheoryData<object[], string> MemberData_Bfs => new TheoryData<object[], string>
        {
            { new object[] { }, string.Empty },
            { new object[] { 4, 2, 1, 3, 7, 6, 5 }, "4 2 7 1 3 6 5" }
        };

        public static TheoryData<int[], int, bool> MemberData_Search => new TheoryData<int[], int, bool>
        {
            { new int[] { }, 2, false },
            { new int[] { 4, 2, 1, 6, 3, 5, 7 }, 2, true },
            { new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8, false }
        };

        [Theory]
        [MemberData(nameof(MemberData_Bfs))]
        public void Bfs_ShouldInvokeActionInABfsTraversal(int[] values, string traversalExpectedString)
        {
            var tree = BinaryTreeHelpers.Build<BinarySearchTree<int>, int>(values);

            BinaryTreeHelpers.TestOrderMethod<BinarySearchTree<int>, int>(tree => tree.Bfs, values, traversalExpectedString);
        }

        [Theory]
        [MemberData(nameof(MemberData_Search))]
        public void Search_ShouldReturnTrueIfTheTreeContainsTheValue(int[] values, int search, bool expected)
        {
            var tree = BinaryTreeHelpers.Build<BinarySearchTree<int>, int>(values);

            tree.Search(search).Should().Be(expected);
        }
    }
}