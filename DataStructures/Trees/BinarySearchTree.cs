﻿using System;
using System.Collections.Generic;
using DataStructures.Nodes;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> _root = null;

        public void Add(T value)
        {
            var newNode = new BinaryTreeNode<T>(value);

            if (_root == null)
            {
                _root = newNode;
                return;
            }

            var node = _root;

            while (node != null)
            {
                var compare = node.Value.CompareTo(value);

                if (compare == 0)
                {
                    throw new InvalidOperationException($"Key {value} must be unique.");
                }
                else if (compare < 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        return;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
                else if (compare > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        return;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
            }
        }

        public bool Search(T value)
        {
            var node = _root;

            while (node != null)
            {
                var compare = node.Value.CompareTo(value);

                if (compare == 0)
                {
                    return true;
                }
                else if (compare < 0)
                {
                    node = node.Right;
                }
                else
                {
                    node = node.Left;
                }
            }

            return false;
        }

        /// <summary>
        /// Compares this BST to a binary tree. Returns true if and only if they hold exactly the same tree structure.
        /// </summary>
        public bool IsEquivalentTo(BinaryTree<T> compareTree)
        {
            var thisTreeQueue = new Queue<BinaryTreeNode<T>>();
            var compareTreeQueue = new Queue<BinaryTreeNode<T>>();
            
            if (_root == null)
            {
                return compareTree.Root == null;
            }

            if (compareTree.Root == null)
            {
                return _root == null;
            }
            
            thisTreeQueue.Enqueue(_root);
            compareTreeQueue.Enqueue(compareTree.Root);

            while (thisTreeQueue.TryDequeue(out var thisTreeNode))
            {
                var compareTreeNode = compareTreeQueue.Dequeue();

                if ((compareTreeNode == null && thisTreeNode != null) || 
                    (compareTreeNode != null && thisTreeNode == null) || 
                    (compareTreeNode != null && thisTreeNode != null) && compareTreeNode.Value.CompareTo(thisTreeNode.Value) == 0)
                {
                    return false;
                }

                thisTreeQueue.Enqueue(thisTreeNode.Left);
                thisTreeQueue.Enqueue(thisTreeNode.Right);

                compareTreeQueue.Enqueue(compareTreeNode.Left);
                compareTreeQueue.Enqueue(compareTreeNode.Right);
            }

            return true;
        }
    }
}