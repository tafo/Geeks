using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Node at a given index in linked list"
    /// 
    /// Given a singly linked list with N nodes and a number X.
    /// The task is to find the node at the given index (X)(1 based index) of linked list. 
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// For each test case, first line of input contains space separated two integers, length of linked list and X.
    /// 
    /// Output:
    /// For each test case, there will be single line of output containing data at Xth node.
    /// 
    /// User Task:
    /// The task is to complete the function GetNth()
    ///     which takes head reference and index as arguments and should return the data at Xth position in the linked list.
    /// 
    /// Constraints:
    /// 1 <= T <= 30
    /// 1 <= N <= 100
    /// K <= N
    /// 1 <= value <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6 5
    /// 1 2 3 4 657 76
    /// 10 2
    /// 8 7 10 8 6 1 20 91 21 2
    /// 
    /// Output:
    /// 657
    /// 7
    /// 
    /// Explanation:
    /// Testcase 1:
    /// Element at 5th index in the linked list is 657 (1-based indexing).
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindElementAtGivenPosition
    {
        /// <summary>
        /// The execution time is 0.42
        /// </summary>
        public static void RunAnother()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var n = int.Parse(split[0]);
                var p = int.Parse(split[1]);
                var elements = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var linkedList = new LinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                Console.WriteLine(ElementAt(linkedList.Head, p));
            }

            
            /// <summary>
            /// The signature of this method is specified by GfG
            /// </summary>
            static int ElementAt(Node<int> node, int p)
            {
                for (var i = 1; i < p; i++)
                {
                    node = node.Next;
                }

                return node.Data;
            }
        }

        /// <summary>
        /// The execution time is 0.46
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var n = int.Parse(split[0]);
                var p = int.Parse(split[1]);
                var elements = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var linkedList = new LinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                Console.WriteLine(ElementAt(linkedList.Head, p));
            }

            /// <summary>
            /// The signature of this method is specified by GfG
            /// </summary>
            static int ElementAt(Node<int> node, int p)
            {
                var counter = 1;
                while (counter < p)
                {
                    counter++;
                    node = node.Next;
                }

                return node.Data;
            }
        }
    }
}