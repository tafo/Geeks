using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Find n/k th node in Linked list"
    /// 
    /// Given a singly linked list and a number k.
    /// Write a function to find the (N/k)th element, where N is the number of elements in the list.
    /// We need to consider ceil value in case of decimals.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// The first line of each test case consists of an integer N.
    /// The second line consists of N spaced integers.
    /// The last line consists of an integer k.
    /// 
    /// Output:
    /// Print the data value of (N/k)th node in the Linked List.
    /// 
    /// User Task:
    /// The task is to complete the function fractional_node() which
    ///     should find the n/kth node in the linked list and return its data value.
    /// 
    /// Constraints: 
    /// 1 <= T <= 100
    /// 1 <= N <= 100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6
    /// 1 2 3 4 5 6
    /// 2
    /// 5
    /// 2 7 9 3 5
    /// 3
    /// 
    /// Output:
    /// 3
    /// 7
    /// 
    /// Explanation:
    /// Testcase 1:
    /// 6/2th element is the 3rd(1-based indexing) element which is 3.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindNode
    {
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

                Console.WriteLine(FindNode(linkedList.Head, k));
            }

            static int FindNode(Node<int> head, int k)
            {
                var node = head;
                var counter = 0;
                while (head != null)
                {
                    if (counter == k)
                    {
                        node = node.Next;
                        counter = 0;
                    }

                    head = head.Next;
                    counter++;
                }

                return node.Data;
            }
        }
    }
}