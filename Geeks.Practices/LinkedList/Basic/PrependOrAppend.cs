using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Linked List Insertion"
    /// 
    /// Given a key (or data) to be inserted into the linked list of size N.
    /// The task is to insert the element at head or tail of the linked list depending on the input just before it p.
    /// If p is 0, then insert the element at beginning else insert at end.
    /// Hint : When inserting at the end, make sure that you handle NULL explicitly.
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// For each test case,
    ///     First line of input contains length of linked list N
    ///     And next line contains 2*N integers,
    ///         each element to be inserted into the list is preceded by a 0 or 1 which decide the place to be inserted.
    /// 
    /// Output:
    /// For each test case, there will be a single line of output which contains the linked list elements.
    /// 
    /// Your Task:
    /// This is a function problem.
    /// You only need to complete the functions insertAtBeginning and insertAtEnd that returns head after successful insertion.
    /// The printing is done automatically by the driver code.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 5
    /// 9 0 5 1 6 1 2 0 5 0
    /// 3
    /// 5 1 6 1 9 1
    /// 4
    /// 15 0 36 0 95 0 14 0
    /// 
    /// Output:
    /// 5 2 9 5 6
    /// 5 6 9
    /// 14 95 36 15
    /// 
    /// Explanation:
    /// Testcase 1: After inserting the elements at required position, we have linked list as 5, 2, 9, 5, 6.
    /// Testcase 2: After inserting the elements on the basis of value of p , we have linked list as 5,6,9.
    /// Testcase 3: After inserting the elements on the basis of value of p , we have linked list as  14,95,36,15.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class PrependOrAppend
    {
        /// <summary>
        /// The body of this method is given by GfG
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine(); // Skip the number of elements
                var scanner = new StringScanner(Console.ReadLine().TrimEnd());
                var list = new LinkedList();
                while (scanner.HasNext)
                {
                    var data = scanner.NextPositiveInt();
                    var p = scanner.NextDigit();
                    if (p == 0)
                    {
                        list.InsertAtBeginning(data);
                    }
                    else
                    {
                        list.InsertAtEnd(data);
                    }
                }

                list.Print();
            }
        }

        /// <summary>
        /// This class is given by GfG
        /// </summary>
        private class Node
        {
            public readonly int Data;
            public Node Next;

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        /// <summary>
        /// This class is given by GfG except the bodies of InsertAtEnd and InsertAtBeginning methods
        /// </summary>
        private class LinkedList
        {
            private Node _head; // Please do not remove this

            // Should insert a node at the beginning
            public void InsertAtBeginning(int x)
            {
                var node = new Node(x) {Next = _head};
                _head = node;
            }

            // Should insert a node at the end
            public void InsertAtEnd(int x)
            {
                if (_head == null)
                {
                    _head = new Node(x);
                }
                else
                {
                    var temp = _head;
                    while (temp.Next != null)
                    {
                        temp = temp.Next;
                    }

                    temp.Next = new Node(x);
                }
            }

            // Please do not delete this
            public void Print()
            {
                var temp = _head;
                while (temp != null)
                {
                    Console.Write(temp.Data + " ");
                    temp = temp.Next;
                }

                Console.WriteLine();
            }
        }
    }
}