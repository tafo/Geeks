using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.LinkedList.Infrastructure;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Check If Circular Linked List"
    /// 
    /// Given a singly linked list, find if the linked list is circular or not.
    /// A linked list is called circular if it not NULL terminated and all nodes are connected in the form of a cycle.
    /// An empty linked list is considered as circular.
    /// 
    /// Input:
    /// First line of input contains number of test cases T.
    /// For each test case,
    ///     first line consists of number of nodes in the linked list and an integer representing if the list is circular list.
    /// 
    /// Output:
    /// The function should return true if the given linked list is circular, else false.
    /// 
    /// User Task:
    /// The task is to complete the function isCircular() which checks if the given linked list is circular or not.
    /// It should return true or false accordingly.
    /// 
    /// Constraints:
    /// 1 <=T<= 50
    /// 1 <=N<= 100
    /// 1 <=value<= 1000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5 1      
    /// 1 2 3 4 5
    /// 6 0
    /// 2 4 6 7 5 1
    /// 
    /// Output:
    /// 1
    /// 0
    /// 
    /// Explanation:
    /// Test case 1:
    /// k is 1, therefore output is 1.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CheckWhetherCircularOrNot
    {
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var elements = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var linkedList = new LinkedList<int>(k == 1);
                for (var i = 0; i < n; i++)
                {
                    linkedList.Append(elements[i]);
                }

                Console.WriteLine(IsCircular(linkedList.Head));
            }

            // The signature of this method is specified by GfG
            static bool IsCircular(Node<int> head)
            {
                var result = false;
                var headBackup = head;
                while (head.Next != null)
                {
                    head = head.Next;
                    if (head != headBackup) continue;
                    result = true;
                    break;
                }

                return result;
            }
        }
    }
}