using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Stack.Basic
{
    /// <summary>
    /// The title is "Queue Reversal"
    /// 
    /// Given a Queue Q containing N elements.
    /// The task is to reverse the Queue.
    /// Your task is to complete the function rev(), that reverses the N elements of the queue.
    /// 
    /// Input: 
    /// The first line of input contains an integer T denoting the Test cases.
    /// Then T test cases follow.
    /// The first line contains N which is the number of elements which will be reversed.
    /// Second line contains N space separated elements.
    /// 
    /// Output:
    /// For each test case, in a new line, print the reversed queue.
    /// 
    /// Your Task:
    /// This is a function problem.
    /// You only need to complete the function rev that takes a queue as parameter and returns the reversed queue.
    /// The printing is done automatically by the driver code.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 10e5
    /// 1 ≤ e ≤ 10e5
    /// 
    /// Example:
    /// Input : 
    /// 2
    /// 6
    /// 4 3 1 10 2 6
    /// 4
    /// 4 3 2 1
    /// 
    /// Output : 
    /// 6 2 10 1 3 4
    /// 1 2 3 4
    /// 
    /// Explanation :
    /// Test case 1:
    /// After reversing the given elements of the queue , the resultant queue will be 6 2 10 1 3 4.
    /// Test case 2:
    /// After reversing the given elements of the queue , the resultant queue will be 1 2 3 4.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Reverse
    {
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount -- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var elements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var queue = new Queue<int>();
                for (var i = 0; i < n; i++)
                {
                    queue.Enqueue(elements[i]);
                }

                var reversedQueue = GetReversed(queue);
                while (reversedQueue.TryDequeue(out var item))
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine();
            }

            static Queue<int> GetReversed(Queue<int> q)
            {
                var stack = new Stack<int>();
                while (q.Count > 0)
                {
                    stack.Push(q.Dequeue());
                }

                while (stack.Count > 0)
                {
                    q.Enqueue(stack.Pop());
                }

                return q;
            }
        }
    }
}