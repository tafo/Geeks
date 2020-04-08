using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Delete node in Doubly Linked List"
    /// 
    /// Given a doubly linked list and a position.
    /// The task is to delete a node from given position in a doubly linked list.
    /// 
    /// Input:
    /// First line of input contains number of test cases.
    /// First line of each test case contains number of elements in the linked list.
    /// The next line contains the elements of the linked list.
    /// The last line contains the position from which element is to be deleted.
    /// 
    /// Output:
    /// Delete the node from the given doubly linked list and set *head_ref if required.
    /// 
    /// User Task:
    /// The task is to complete the function deleteNode() which should delete the node at given position.
    /// 
    /// Constraints:
    /// 1 <= T <= 300
    /// 2 <= N <= 1000
    /// 1 <= x <= N
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 3
    /// 1  3 4
    /// 3
    /// 4
    /// 1 5 2 9                    
    /// 1
    /// 
    /// Output:
    /// 1 3           
    /// 5 2 9
    /// 
    /// Explanation:
    /// Test case 1:
    /// After deleting the node at position 3 (position starts from 1), the linked list will be now as 1->3.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class DeleteNode
    {
        /// <summary>
        /// The execution time is 0.88
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- >  0)
            {
                var n = int.Parse(Console.ReadLine());
                var elements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var p = int.Parse(Console.ReadLine());
                var linkedList = new ThatLinkedList<int>();
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                // Convert the list to non-circular. 
                linkedList.Head.Pre = linkedList.Last.Next = null;

                var head = Delete(linkedList.Head, p);

                while (head?.Next != null)
                {
                    Console.Write($"{head.Data} ");
                    head = head.Next;
                }

                Console.WriteLine(head.Data);
            }

            // The signature of this method is specified by GfG
            static Node<int> Delete(Node<int> head, int x)
            {
                var p = 1;
                var headBackup = head;
                while (p < x)
                {
                    head = head.Next;
                    p++;
                }

                if (head.Next != null)
                {
                    if (head.Pre == null)
                    {
                        head.Next.Pre = null;
                        headBackup = head.Next;
                    }
                    else
                    {
                        head.Next.Pre = head.Pre.Next;
                        head.Pre.Next = head.Next;
                    }
                }
                else
                {
                    head.Pre.Next = null;
                }

                return headBackup;
            }
        }
    }
}