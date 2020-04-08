using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Doubly linked list Insertion at given position"
    /// 
    /// Given a doubly linked list, a position p and an integer x.
    /// The task  is to add a new node with value x at position just after pth node in the doubly linked list.
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// For each test case,
    /// first line of input contains number of nodes in the linked list,
    /// and next line contains two integers p and x.
    /// 
    /// Output:
    /// For each test case, there will be a single line of output which prints the modified linked list.
    /// 
    /// User Task:
    /// The task is to complete the function InsertNode() which head reference, position and data to be inserted as the arguments.
    /// 
    /// Constraints:
    /// 1 <= T <= 200
    /// 1 <= N <= 10e3
    /// 0 <= p <= N - 1
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 3
    /// 2 4 5
    /// 2 6
    /// 4
    /// 1 2 3 4
    /// 0 44
    /// 
    /// Output:
    /// 2 4 5 6
    /// 1 44 2 3 4
    /// 
    /// Explanation:
    ///
    /// Test case 1:
    /// p = 2, and x = 6. So, 6 is inserted after p, i.e, at position 3 (0-based indexing).
    ///
    /// Test case 2:
    /// p = 0, and x = 44 . So, 44 is inserted after p, i.e, at position 1 (0-based indexing).
    ///
    /// Remark:
    /// 1:
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class InsertNode
    {
        /// <summary>
        /// The execution time is 0.31
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var elements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var arguments = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var thatList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    thatList.Append(elements[i]);
                }

                InsertNode(thatList.Head, arguments[0], arguments[1]);

                var node = thatList.Head;
                if (node == null)
                {
                    Console.WriteLine();
                }
                else
                {
                    while (node.Next != null)
                    {
                        Console.Write($"{node.Data} ");
                        node = node.Next;
                    }

                    Console.WriteLine(node.Data);
                }
            }

            static void InsertNode(Node<int> head, int i, int data)
            {
                var counter = 0;
                while (counter++ < i)
                {
                    head = head.Next;
                }

                var node = new Node<int>(data);
                head.Next.Pre = node;
                node.Next = head.Next;
                node.Pre = head;
                head.Next = node;
            }
        }
    }
}