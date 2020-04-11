using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Delete Alternate Nodes"
    /// 
    /// Given a Singly Linked List of size N, your task is to complete the function deleteAlt(),
    ///     which starting from the second node delete all alternate nodes of the list.
    /// 
    /// Input:
    /// The function takes a single argument as input, the reference pointer to the head of the linked list.
    /// There will be T test cases and for each test case the function will be called separately. 
    /// 
    /// Output:
    /// For each test the output will be space separated values of the linked list.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6
    /// 1 2 3 4 5 6
    /// 4
    /// 99 59 42 20
    /// 
    /// Output:
    /// 1 3 5
    /// 99 42
    /// 
    /// Explanation:
    /// Test case 1:
    /// Deleting alternate nodes results in the linked list with elements 1-&gt;3-&gt;5.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class DeleteAlternateNodes
    {
        /// <summary>
        /// The execution time is 0.24
        /// * This is the equivalent method of given JAVA function.
        /// * Ignore ThatLinkedList.Pre to use it as a singly linked list.
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var elements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var linkedList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                // Make the linked list non-circular
                linkedList.Last.Next = null;
                DeleteAlternate(linkedList.Head);
                Console.WriteLine();
            }

            // The signature of this method is specified by GfG
            static void DeleteAlternate(Node<int> head)
            {
                var headBackup = head;
                while (head?.Next != null)
                {
                    head = head.Next = head.Next.Next;
                }

                while (headBackup != null)
                {
                    Console.Write($"{headBackup.Data} ");
                    headBackup = headBackup.Next;
                }
            }
        }
    }
}