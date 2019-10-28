using System;
using System.Collections.Generic;
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

        [Fact]
        public void Add_ShouldAddItemsInKeyOrder()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(7);
            tree.Add(6);
            tree.Add(5);

            var root = tree.Root;

            root.Value.Should().Be(4);
            root.Left.Value.Should().Be(2);
            root.Left.Left.Value.Should().Be(1);
            root.Left.Right.Value.Should().Be(3);
            root.Right.Value.Should().Be(7);
            root.Right.Left.Value.Should().Be(6);
            root.Right.Left.Left.Value.Should().Be(5);
        }

        [Fact]
        public void Add_ShouldThrowInvalidOperationException_WhenKeyIsNotUnique()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(1);

            FluentActions.Invoking(() => tree.Add(1)).Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [MemberData(nameof(MemberData_Bfs))]
        public void Bfs_ShouldInvokeActionInABfsTraversal(int[] values, string traversalExpectedString)
        {
            var tree = BinaryTreeHelpers.Build<BinarySearchTree<int>, int>(values);

            BinaryTreeHelpers.TestOrderMethod<BinarySearchTree<int>, int>(tree => tree.Bfs, values, traversalExpectedString);
        }

        [Fact]
        public void Remove_ShouldRemoveItemFromTheTree()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(7);
            tree.Add(6);
            tree.Add(5);
            tree.Remove(2);

            var root = tree.Root;

            root.Value.Should().Be(4);
            root.Left.Value.Should().Be(1);
            root.Left.Right.Value.Should().Be(3);
            root.Right.Value.Should().Be(7);
            root.Right.Left.Value.Should().Be(6);
            root.Right.Left.Left.Value.Should().Be(5);
        }

        [Fact]
        public void Remove_ShouldThrowKeyNotFoundException()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(4);

            FluentActions.Invoking(() => tree.Remove(2)).Should().Throw<KeyNotFoundException>();
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