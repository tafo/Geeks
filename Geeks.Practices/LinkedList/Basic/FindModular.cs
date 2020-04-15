using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Modular Node"
    /// 
    /// Given a singly linked list and a number K,
    ///     you are required to complete the function modularNode() which returns the modular node of the linked list.
    /// A modular node is the last node of the linked list whose Index is divisible by the number K, i.e. i%k==0.
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// For each test case, first line of input contains length of Linked list N.
    /// Next line contains elements of the linked list and last line contains K.
    /// 
    /// Output:
    /// For each test case the function must return the modular Node data, if no such node is possible then return "-1".
    /// 
    /// User Task:
    /// The task is to complete the function modularNode() which
    ///     should return the data of the modular node if exists else return -1.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 500
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 7
    /// 1 2 3 4 5 6 7
    /// 3
    /// 5
    /// 19 28 37 46 55
    /// 2
    /// 
    /// Output:
    /// 6
    /// 46
    /// 
    /// Explanation:
    /// Testcase 1:
    /// Node from the last which is divisible by 3 is 6.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindModular
    {
        /// <summary>
        /// The execution time is 0.47
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var elements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var k = int.Parse(Console.ReadLine());
                var linkedList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                // Make the linked list non-circular
                linkedList.Last.Next = null;

                Console.WriteLine(ModularNode(linkedList.Head, k));
            }

            static int ModularNode(Node<int> head, int k)
            {
                var result = -1;
                var counter = 1;
                while (head != null)
                {
                    if (counter == k)
                    {
                        result = head.Data;
                        counter = 0;
                    }

                    head = head.Next;
                    counter++;
                }

                return result;
            }
        }
    }
}