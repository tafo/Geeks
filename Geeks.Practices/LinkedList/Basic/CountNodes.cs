using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Count nodes of linked list"
    ///  
    /// Given a singly linked list.
    /// The task is to find the length of linked list, where length is defined as number of nodes in the linked list.
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// For each test case,
    ///     First line of input contains number of nodes N, to be inserted into the linked list
    ///     And next line contains data of N nodes.
    /// 
    /// Output:
    /// There will be a single line of output for each test case, which contains length of the linked list.
    /// 
    /// User Task:
    /// Your task is to complete the given function getCount(),
    ///     which takes head reference as argument and should return the length of linked list.
    /// 
    /// Constraints:
    /// 1 <= T <= 30
    /// 1 <= N <= 100
    /// 1 <= value <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 2 3 4 5
    /// 7
    /// 2 4 6 7 5 1 0
    /// 
    /// Output:
    /// 5
    /// 7
    /// 
    /// Explanation:
    /// Test case 1:
    /// Count of nodes in the linked list is 5, which is its length.
    ///
    /// Test case 2:
    /// Count of nodes in the linked list is 7 . Hence, the output is 7.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountNodes
    {
        /// <summary>
        /// The execution time is 0.28
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var elements = Array.ConvertAll(input.Split(' '), int.Parse);
                var linkedList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                Console.WriteLine(GetCount(linkedList.Head));
            }
        }

        /// <summary>
        /// The signature of this method is specified by Gfg
        /// </summary>
        public static int GetCount(Node<int> head)
        {
            var counter = 0;
            while (head != null)
            {
                counter++;
                head = head.Next;
            }

            return counter;
        }
    }
}