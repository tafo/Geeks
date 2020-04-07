using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Linked List Length Even or Odd?"
    /// 
    /// Given a linked list of size N, your task is to complete the function isLengthEvenOrOdd() which
    ///     contains head of the linked list and check whether the length of linked list is even or odd.
    /// 
    /// Input:
    /// The input line contains T, denoting the number of test cases.
    /// Each test case contains two lines.
    /// The first line contains N(size of the linked list).
    /// The second line contains N elements of the linked list separated by space.
    /// 
    /// Output:
    /// For each test case in new line,
    ///     print "even"(without quotes) if the length is even else "odd"(without quotes) if the length is odd.
    /// 
    /// User Task:
    /// Since this is a functional problem you don't have to worry about input,
    ///     you just have to  complete the function CheckSize().
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e3
    /// 1 <= A[i] <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 3
    /// 9 4 3
    /// 6
    /// 12 52 10 47 95 0
    /// 
    /// Output:
    /// Odd
    /// Even
    /// 
    /// Explanation:
    ///
    /// Testcase 1:
    /// The length of linked list is 3 which is odd.
    ///
    /// Testcase 2:
    /// The length of linked list is 6 which is even.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CheckSizeEvenOrOdd
    {
        /// <summary>
        /// The execution time is 0.21
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var elements = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var linkedList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                Console.WriteLine(CheckSize(linkedList.Head) == 0 ? "Even" : "Odd");
            }

            static int CheckSize(Node<int> head)
            {
                var size = 0;
                while (head != null)
                {
                    size++;
                    head = head.Next;
                }

                return size & 1;
            }
        }
    }
}