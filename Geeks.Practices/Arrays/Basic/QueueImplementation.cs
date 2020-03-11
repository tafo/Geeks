using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// Implement a Queue using Array. Your task is only to complete the functions push and pop.
    /// Note: If at any point the queue is empty and you are asked to perform pop() operation, print -1.
    /// 
    /// Input Format:
    /// The first line of the input contains an integer 'T' denoting the number of test cases. Then T test cases follow.
    /// First line of each test case contains an integer Q denoting the number of queries . 
    /// A Query Q is of 2 Types:
    /// (T1) 1 x (a query of this type means  pushing 'x' into the queue)
    /// (T2) 2   (a query of this type means to pop element from queue and print the popped element)
    /// The second line of each test case contains Q queries separated by space.
    /// 
    /// Output Format:
    /// The output for each test case will  be space separated integers having -1 if the queue is empty else the element popped out from the queue.
    /// 
    /// Your Task :
    /// Complete the two methods
    ///     "push" which take one argument an integer 'x' to be pushed into the queue
    ///     "pop" which returns a integer popped out from the queue.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= Q <= 10e5
    /// 1 <= x <= 10e5
    /// 
    /// Example:
    /// Input
    /// 2
    /// 5
    /// 1 2 1 3 2 1 4 2
    /// 4
    /// 1 3 2 2 1 4  
    /// 
    /// Output
    /// 2 3
    /// 3 -1
    /// 
    /// Explanation:
    /// In the first test case for query 
    /// 1 2    the quee will be {2}
    /// 1 3    the queue will be {2 3}
    /// 2       poped element will be 2 the queue will be {3}
    /// 1 4    the queue will be {3 4}
    /// 2       poped element will be 3
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class QueueImplementation
    {
        /// <summary>
        ///  The execution time is 3.91
        /// </summary>
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                // var n = int.Parse(testCase[0]); Skip the number of elements
                var scanner = new StringScanner(testCase[1]);
                var queue = new ThatQueue();
                
                while (scanner.HasNext)
                {
                    switch (scanner.NextPositiveInt())
                    {
                        case 1:
                            queue.Push(scanner.NextPositiveInt());
                            break;
                        case 2:
                            Console.Write("{0} ", queue.Pop());
                            break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Method signatures and fields were specified by GG
    /// * The equivalent C# class of the specified JAVA class. 
    /// </summary>
    public class ThatQueue
    {
        private int _front, _rear;

        private readonly int[] _array = new int[100005];

        public ThatQueue()
        {
            _front = 0;
            _rear = 0;
        }

        public void Push(int a)
        {
            _array[_rear++] = a;
        }

        public int Pop()
        {
            if (_rear > _front)
            {
                return _array[_front++];
            }

            // Actually, this statement is not necessary. Because the array size(100005) is greater than the number of elements(100000) 
            // The execution time is 3.58 without this statement.
            _front = _rear = 0; 

            return -1;
        }
    }
}