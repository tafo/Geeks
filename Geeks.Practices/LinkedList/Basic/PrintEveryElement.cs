using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Print Linked List elements"
    /// 
    /// You are given the pointer to the head node of a linked list.
    /// You have to print all of its elements in order in a single line.
    /// 
    /// Input:
    /// You have to complete a method which takes one argument: the head of the linked list.
    /// You should not read any input from std in/console.
    /// The Node has a data part which stores the data and a next pointer which points to the next element of the linked list.
    /// There are multiple test cases. For each test case, this method will be called individually.
    /// 
    /// Output:
    /// Print the elements of the linked list in a single line separated by a single space.
    /// 
    /// User Task:
    /// The task is to complete the function display() which prints the elements of the linked list.
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 2
    /// 1 2
    /// 1
    /// 4
    /// 
    /// Output:
    /// 1 2
    /// 4
    /// 
    /// Explanation:
    /// Test case 1:
    /// Here the first line denotes an integer 'T' the no of test cases
    /// And the next line denotes 'N' the no of nodes of linked list.
    /// Then the line after that contains N space separated integers denoting the values of the nodes of the linked list.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class PrintEveryElement
    {
        /// <summary>
        /// The execution time is 0.27
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

                Print(linkedList.Head);
            }
        }

        /// <summary>
        /// The signature of this method is specified by Gfg
        /// </summary>
        public static void Print(Node<int> head)
        {
            while (head.Next != null)
            {
                Console.Write($"{head.Data} ");
                head = head.Next;
            }

            Console.WriteLine(head.Data);
        }
    }
}