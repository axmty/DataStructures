using DataStructures.Nodes;
using DataStructures.Trees;
using Xunit;

namespace DataStructures.UnitTests
{
    public class BinarySearchTreeTests
    {
        // One entry: int items to add step by step, expected binary tree.
        public static TheoryData<int[], BinaryTree<int>> MemberData_Add_InsertsPerformingComparison = new TheoryData<int[], BinaryTree<int>>
        {
            {
                new int[] { 5, 4 },
                new BinaryTree<int>
                {
                    Root = new BinaryTreeNode<int>(5)
                    {
                        Left = new BinaryTreeNode<int>(4)
                    }
                }
            },
            {
                new int[] { 5, 6 },
                new BinaryTree<int>
                {
                    Root = new BinaryTreeNode<int>(5)
                    {
                        Right = new BinaryTreeNode<int>(6)
                    }
                }
            },
            {
                new int[] { 4, 2, 3 },
                new BinaryTree<int>
                {
                    Root = new BinaryTreeNode<int>(4)
                    {
                        Left = new BinaryTreeNode<int>(2)
                        {
                            Right = new BinaryTreeNode<int>(2)
                        }
                    }
                }
            },
            {
                new int [] { 4, 6, 5 },
                new BinaryTree<int>
                {
                    Root = new BinaryTreeNode<int>(4)
                    {
                        Right = new BinaryTreeNode<int>(6)
                        {
                            Left = new BinaryTreeNode<int>(5)
                        }
                    }
                }
            },

            /* Tree:

                          6
                      4       8
                    2   5   7   9
                  1   3  

             */
            {
                new int[] { 6, 4, 8, 9, 2, 3, 1, 7, 5 },
                new BinaryTree<int>
                {
                    Root = new BinaryTreeNode<int>(6)
                    {
                        Left = new BinaryTreeNode<int>(4)
                        {
                            Left = new BinaryTreeNode<int>(2)
                            {
                                Left = new BinaryTreeNode<int>(1),
                                Right = new BinaryTreeNode<int>(3)
                            },
                            Right = new BinaryTreeNode<int>(5)
                        },
                        Right = new BinaryTreeNode<int>(8)
                        {
                            Left = new BinaryTreeNode<int>(7),
                            Right = new BinaryTreeNode<int>(9)
                        }
                    }
                }
            }
        };
    }
}