using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Tree.Basic
{
    /// <summary>
    /// The title is "Height of Binary Tree"
    /// 
    /// Given a binary tree, find height of it.
    /// 
    ///       1
    ///     /   \
    ///   10     39
    ///  /
    /// 5
    /// 
    /// The above tree has a height of 3.
    /// Note: Height of empty tree is considered 0.
    /// 
    /// Input:
    /// First line of input contains the number of test cases T.
    /// For each test case, there will be only a single line of input which is a string representing the tree as described below: 
    /// 
    /// The values in the string are in the order of level order traversal of the tree where,
    ///     numbers denote node values, and a character "N" denotes NULL child.
    /// 
    /// Output:
    /// For each test case, in a new line, print the height of tree.
    /// 
    /// Your Task:
    /// You don't have to take input.
    /// Complete the function Height() that takes node as parameter and returns the height.
    /// The printing is done by the driver code.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= Number of nodes <= 10e5
    /// 1 <= Data of a node <= 10e5
    /// Sum of N over all testcases doesn't exceed 10e5
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 1 2 3
    /// 2 N 1 3 N
    /// 10 20 30 40 60 N N
    /// 
    /// Output:
    /// 2
    /// 3
    /// 3
    /// 
    /// Explanation:
    /// Testcase1:
    /// The tree is
    /// 
    ///    1
    ///  /   \
    /// 2     3
    /// 
    /// So, the height would be 2.
    /// 
    /// Testcase2:
    /// The tree is
    /// 
    ///   2
    ///     \
    ///      1 
    ///     /    
    ///    3
    ///
    /// So, height would be 3.
    /// 
    /// Testcase3:
    /// The tree is
    /// 
    ///       10
    ///      /  \
    ///    20    30
    ///   /  \
    /// 40    60
    /// 
    /// So, height would be 3.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindHeight
    {
        /// <summary>
        /// 2 N 1 3 N
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var elements = Console.ReadLine().TrimEnd().Split(' ');
                var nodes = new Queue<BinaryTreeNode>(elements.Length);
                var root = new BinaryTreeNode() { Data = int.Parse(elements[0]) };
                nodes.Enqueue(root);
                var index = 0;
                while (++index < elements.Length)
                {
                    var current = nodes.Dequeue();
                    if (elements[index] != "N")
                    {
                        current.Left = new BinaryTreeNode { Data = int.Parse(elements[index]) };
                        nodes.Enqueue(current.Left);
                    }

                    if (++index == elements.Length)
                    {
                        continue;
                    }

                    if (elements[index] == "N") continue;

                    current.Right = new BinaryTreeNode { Data = int.Parse(elements[index]) };
                    nodes.Enqueue(current.Right);
                }

                Console.WriteLine(Height(root));
            }
        }

        private static int Height(BinaryTreeNode rootNode)
        {
            return GetHeight(rootNode, 1);
        }

        private static int GetHeight(BinaryTreeNode node, int height)
        {
            if (node.Left == null && node.Right == null) return height;

            var leftHeight = height;
            var rightHeight = height;

            if (node.Left != null)
            {
                leftHeight = GetHeight(node.Left, height + 1);
            }

            if (node.Right != null)
            {
                rightHeight = GetHeight(node.Right, height + 1);
            }

            return Math.Max(leftHeight, rightHeight);
        }
    }

    public class BinaryTreeNode
    {
        public int Data { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
    }
}