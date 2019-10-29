using System;
using System.Text;
using DataStructures.Nodes;
using DataStructures.Trees;
using FluentAssertions;
using Xunit;

namespace DataStructures.UnitTests
{
    public class BinaryTree_Tests
    {
        [Fact]
        public void Bfs_ShouldInvokeActionInABfsTraversal()
        {
            this.TestTraversalMethod(this.BuildSampleTree(), tree => tree.Bfs, "1 2 3 4 6 7 5");
        }

        [Fact]
        public void InOrder_ShouldInvokeActionInAnInOrderTraversal()
        {
            this.TestTraversalMethod(this.BuildSampleTree(), tree => tree.InOrder, "4 5 2 1 6 3 7");
        }

        [Fact]
        public void PostOrder_ShouldInvokeActionInAPostOrderTraversal()
        {
            this.TestTraversalMethod(this.BuildSampleTree(), tree => tree.PostOrder, "5 4 2 6 7 3 1");
        }

        [Fact]
        public void PreOrder_ShouldInvokeActionInAPreOrderTraversal()
        {
            this.TestTraversalMethod(this.BuildSampleTree(), tree => tree.PreOrder, "1 2 4 5 3 6 7");
        }

        private BinaryTree<int> BuildSampleTree()
        {
            /* Build tree:

                          1
                      2       3
                    4       6   7
                      5

             */

            var tree = new BinaryTree<int>
            {
                Root = new BinaryTreeNode<int>(1)
                {
                    Left = new BinaryTreeNode<int>(2)
                    {
                        Left = new BinaryTreeNode<int>(4)
                        {
                            Right = new BinaryTreeNode<int>(5)
                        }
                    },
                    Right = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(6),
                        Right = new BinaryTreeNode<int>(7)
                    }
                }
            };

            return tree;
        }

        private void TestTraversalMethod(
            BinaryTree<int> tree,
            Func<BinaryTree<int>, Action<Action<int>>> orderMethodSelector,
            string traversalExpectedString)
        {
            var toString = new StringBuilder();

            orderMethodSelector(tree)((item) => toString.Append($" {item}"));

            toString.ToString().Trim().Should().Be(traversalExpectedString);
        }
    }
}