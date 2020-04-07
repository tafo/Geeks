using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Finding middle element in a linked list"
    /// 
    /// Given a singly linked list of N nodes.
    /// The task is to find middle of the linked list.
    /// For example, if given linked list is 1->2->3->4->5 then output should be 3.
    /// If there are even nodes, then there would be two middle nodes, we need to print second middle element.
    /// For example, if given linked list is 1->2->3->4->5->6 then output should be 4.
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// For each test case,
    ///     First line of input contains length of linked list and next line contains data of nodes of linked list.
    /// 
    /// Output:
    /// For each test case,
    ///     There will be a single line of output containing data of middle element of linked list.
    /// 
    /// User Task:
    /// The task is to complete the function getMiddle() which takes head reference as the only argument
    /// And should return the data at the middle node of linked list.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 2 3 4 5
    /// 6
    /// 2 4 6 7 5 1
    /// 
    /// Output:
    /// 3
    /// 7
    /// 
    /// Explanation:
    /// Test case 1:
    /// Since, there are 5 elements, therefore 3 is the middle element at index 2 (0-based indexing).
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindMiddle
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount -- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var elements = Array.ConvertAll(input.Split(' '), int.Parse);
                var linkedList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                Console.WriteLine(GetMiddle(linkedList.Head));
            }
        }

        /// <summary>
        /// The signature of this method is specified by GfG
        /// </summary>
        public static int GetMiddle(Node<int> head)
        {
            var flag = true;
            var middle = head;
            while (head.Next != null)
            {
                if (flag)
                {
                    middle = middle.Next;
                }
                head = head.Next;
                flag = !flag;
            }

            return middle.Data;
        }
    }
}