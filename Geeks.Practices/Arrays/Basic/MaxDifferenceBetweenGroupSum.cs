using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Maximum weight difference"
    /// 
    /// Given an array.
    /// The task is to choose K numbers from the array
    ///     such that the absolute difference between the sum of chosen numbers and the sum of remaining numbers is maximum.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains two integers N and K and the second line contains N space separated array elements.
    /// 
    /// Output:
    /// For each test case, print the maximum absolute difference in new line.
    /// 
    /// Constraints:
    /// 1<=T<=200
    /// 1<=K<=N<=10e5
    /// 1<=A[i]<=10e6
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 5 2
    /// 8 4 5  2 10
    /// 8 3
    /// 1 1 1 1 1 1 1 1
    /// 5 5
    /// 5 3 4 2 1
    /// 4 2
    /// 3 3 3 3
    /// 
    /// Output:
    /// 17
    /// 2
    /// 15
    /// 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaxDifferenceBetweenGroupSum
    {
        /// <summary>
        /// The execution time is 0.29
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n).OrderBy(x => x).ToArray();
                if (2 * k < n)
                {
                    Console.WriteLine(numbers.Skip(k).Sum() - numbers.Take(k).Sum());
                }
                else
                {
                    Console.WriteLine(numbers.TakeLast(k).Sum() - numbers.SkipLast(k).Sum());
                }
            }
        }

        /// <summary>
        /// The execution time is 0.19
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var left = 0;
                var right = 0;
                if (2 * k < n)
                {
                    Array.Sort(numbers);
                }
                else
                {
                    Array.Sort(numbers, (x,y) => y.CompareTo(x));
                }
                for (var i = 0; i < k; i++)
                {
                    left += numbers[i];
                }

                for (var i = k; i < n; i++)
                {
                    right += numbers[i];
                }

                Console.WriteLine(Math.Abs(left - right));
            }
        }
    }
}