using System;
using System.Text;
using DataStructures.Trees;
using FluentAssertions;

namespace DataStructures.UnitTests
{
    public static class BinaryTreeHelpers
    {
        public static TTree Build<TTree, T>(T[] values)
            where TTree : IBinaryTree<T>, new()
        {
            var tree = new TTree();

            foreach (var value in values)
            {
                tree.Add(value);
            }

            return tree;
        }

        public static void TestOrderMethod<TTree, T>(
            Func<TTree, Action<Action<T>>> orderMethodSelector,
            T[] values,
            string traversalExpectedString)
            where TTree : IBinaryTree<T>, new()
        {
            var tree = Build<TTree, T>(values);
            var toString = new StringBuilder();

            orderMethodSelector(tree)((item) => toString.Append($" {item}"));

            toString.ToString().Trim().Should().Be(traversalExpectedString);
        }
    }
}