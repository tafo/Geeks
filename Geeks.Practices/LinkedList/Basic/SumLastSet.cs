using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Find the Sum of Last N nodes of the Linked List"
    /// 
    /// Given a single linked list of size M,
    ///     your task is to complete the function sumOfLastN_Nodes(),
    ///     which should return the sum of last N nodes of the linked list.
    /// 
    /// Input:
    /// The function takes two arguments as input, the reference pointer to the head of the linked list and the an integer N.
    /// There will be T test cases and for each test case the function will be called separately.
    /// 
    /// Output:
    /// For each test case output the sum of last N nodes of the linked list.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=M<=1000
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 6 3
    /// 5 9 6 3 4 10
    /// 2 2
    /// 1 2
    /// 
    /// Output:
    /// 17
    /// 3
    /// 
    /// Explanation:
    /// 
    /// Test case 1:
    /// Sum of last three nodes in the linked list is 3 + 4 + 10 = 17.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SumLastSet
    {
        /// <summary>
        /// The execution time is 0.28
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var elements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var linkedList = new ThatLinkedList<int>();
                for (var i = 0; i < input[0]; i++)
                {
                    linkedList.Append(elements[i]);
                }

                // Make the linked list non-circular
                linkedList.Last.Next = null;

                Console.WriteLine(Sum(linkedList.Head, input[1]));
            }

            static int Sum(Node<int> head, int m)
            {
                var result = 0;
                var counter = 0;
                var first = head;
                while (head != null)
                {
                    if (counter < m)
                    {
                        result += head.Data;
                        counter++;
                    }
                    else
                    {
                        result = result + head.Data - first.Data;
                        first = first.Next;
                    }

                    head = head.Next;
                }

                return result;
            }
        }
    }
}