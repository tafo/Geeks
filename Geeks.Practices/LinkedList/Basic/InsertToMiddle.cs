using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Insert in Middle of Linked List"
    /// 
    /// Given a linked list of size N and a key.
    /// The task is to insert the key in the middle of the linked list.
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// 
    /// For each test case,
    /// first line contains length of linked list N
    /// and next line contains N elements to be inserted into the linked list
    /// and the last line contains the element to be inserted to the middle.
    /// 
    /// Output:
    /// For each test case, there will be a single line of output containing the element of modified linked list.
    /// 
    /// User Task:
    /// The task is to complete the function insertInMiddle() which takes head reference and element to be inserted as the arguments.
    /// The printing is done automatically by the driver code.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 3
    /// 1 2 4
    /// 3
    /// 4
    /// 10 20 40 50
    /// 30
    /// 
    /// Output:
    /// 1 2 3 4
    /// 10 20 30 40 50
    /// 
    /// Explanation:
    /// Test case 1:
    /// The new element is inserted after the current middle element in the linked list.
    ///
    /// Test case 2:
    /// The new element is inserted after the current middle element in the linked list and Hence, the output is 10 20 30 40 50.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class InsertToMiddle
    {
        /// <summary>
        /// The execution time is 0.66
        /// This is the equivalent method of given JAVA function. 
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var elements = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var data = int.Parse(Console.ReadLine());
                var linkedList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                // Make the list non-circular
                linkedList.Last.Next = null;

                var head = Insert(linkedList.Head, data);

                while (head?.Next != null)
                {
                    Console.Write($"{head.Data} ");
                    head = head.Next;
                }

                Console.WriteLine(head.Data);
            }

            // The signature of this method is specified by GfG
            static Node<int> Insert(Node<int> head, int data)
            {
                var flag = false;
                var headBackup = head;
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

                var node = new Node<int>(data) { Next = middle.Next };
                middle.Next = node;
                return headBackup;
            }
        }
    }
}