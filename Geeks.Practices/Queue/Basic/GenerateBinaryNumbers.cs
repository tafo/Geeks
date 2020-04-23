using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Queue.Basic
{
    /// <summary>
    /// The title is "Generate Binary Numbers"
    /// 
    /// Given a number N.
    /// The task is to generate and print all binary numbers with decimal values from 1 to N.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// There will be a single line for each test case which contains N.
    /// 
    /// Output:
    /// Print all binary numbers with decimal values from 1 to N in a single line.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 10e6
    /// 1 ≤ N ≤ 10e6
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 2
    /// 5
    /// 
    /// Output:
    /// 1 10
    /// 1 10 11 100 101
    /// 
    /// Explanation:
    /// Test case 1:
    /// Binary numbers from 1 to 2 are 1 and 10.
    ///
    /// Remark:
    /// Use Queue Data Structure
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class GenerateBinaryNumbers
    {
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var queue = new Queue<string>();
                queue.Enqueue("1");
                var k = (n & 1) == 1 ? n : n - 1;
                while (k > 1)
                {
                    var binaryNumber = queue.Dequeue();
                    Console.Write($"{binaryNumber} ");
                    queue.Enqueue($"{binaryNumber}0");
                    queue.Enqueue($"{binaryNumber}1");
                    k -= 2;
                }

                if ((n & 1) == 0)
                {
                    var binaryNumber = queue.Dequeue();
                    Console.Write($"{binaryNumber} ");
                    queue.Enqueue($"{binaryNumber}0");
                }

                while (queue.Count > 0)
                {
                    Console.Write($"{queue.Dequeue()} ");
                }

                Console.WriteLine();
            }
        }
    }
}