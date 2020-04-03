using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Distinct Adjacent Element"
    /// 
    /// Given an array whether it is possible to obtain an array having distinct neighboring elements by swapping two neighboring array elements.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// First line of every test case consists of an integer N, denoting number of elements in array.
    /// Second line of every test case consists of elements of array.
    /// 
    /// Output:
    /// Single line output, print YES if possible else NO.
    /// 
    /// Constraints:
    /// 1<=T<=200
    /// 1<=N<=10^4
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 4
    /// 7 7 7 7
    /// 3
    /// 1 1 2
    /// 
    /// Output:
    /// NO
    /// YES
    ///
    /// Remarks:
    /// 1:
    /// The problem statement is not clear!
    /// It says "by swapping two neighboring array elements". But, swapping "not adjacent" elements is allowed !!!
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class DistinctAdjacent
    {
        /// <summary>
        /// The execution time is 0.17
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var max = input.Split(' ').Select(int.Parse).GroupBy(x => x).Max(x => x.Count());
                Console.WriteLine((n & 1) == 1 && max <= (n + 1) / 2 || (n & 1) == 0 && max <= n / 2 ? "YES" : "NO");
            }
        }

        /// <summary>
        /// The execution time is 0.18
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var numbers = new int[n];
                while (scanner.HasNext)
                {
                    numbers[scanner.NextPositiveInt()]++;
                }

                Array.Sort(numbers);
                var max = numbers[10000];
                Console.WriteLine((n & 1) == 1 && max <= (n + 1) / 2 || (n & 1) == 0 && max <= n / 2 ? "YES" : "NO");
            }
        }
    }
}