using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Identical Linked Lists"
    /// 
    /// Given two Singly Linked List of N and M nodes respectively.
    /// The task is to check whether two linked lists are identical or not. 
    /// Two Linked Lists are identical when they have same data and with same arrangement too.
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// For each test case,
    /// first line of input contains length of linked lists N and M
    /// and next line contains elements of the linked lists.
    /// 
    /// Output:
    /// For each test the output will be 'Identical' if two list are identical else 'Not identical'.
    /// 
    /// User Task:
    /// The task is to complete the function areIdentical() which
    ///     takes head of both linked lists as arguments
    ///     and returns True or False.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6
    /// 1 2 3 4 5 6
    /// 4
    /// 99 59 42 20
    /// 5
    /// 1 2 3 4 5
    /// 5
    /// 1 2 3 4 5
    /// 
    /// Output:
    /// Not identical
    /// Identical
    /// 
    /// Explanation:
    /// Test case 1:
    /// Each element of first linked list is not equal to each elements of second linked list in the same order.
    ///
    /// Test case 2:
    /// Each element of first linked list is equal to each elements of second linked list in the same order.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CheckForBeingIdentical
    {
        /// <summary>
        /// The execution time of equivalent JAVA function is 0.22
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var firstElements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var m = int.Parse(Console.ReadLine());
                var secondElements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var firstLinkedList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    firstLinkedList.Append(firstElements[i]);
                }

                var secondLinkedList = new ThatLinkedList<int>();
                for (var i = 0; i < m; i++)
                {
                    secondLinkedList.Append(secondElements[i]);
                }

                // Make the lists non-circular
                // Ignore ThatLinkedList.Pre to use it as a singly linked list
                firstLinkedList.Last.Next = secondLinkedList.Last.Next = null;

                Console.WriteLine(IsIdentical(firstLinkedList.Head, secondLinkedList.Head) ? "Identical" : "Not Identical");
            }

            // The signature of this method is specified by GfG
            static bool IsIdentical(Node<int> firstHead, Node<int> secondHead)
            {
                var result = true;
                while (firstHead != null && secondHead != null)
                {
                    if (firstHead.Data == secondHead.Data)
                    {
                        firstHead = firstHead.Next;
                        secondHead = secondHead.Next;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }

                return firstHead == null && secondHead == null && result;
            }
        }
    }
}