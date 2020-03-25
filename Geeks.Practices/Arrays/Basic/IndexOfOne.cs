using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Index of first 1 in a sorted array of 0’s and 1’s"
    /// 
    /// Given a sorted array consisting 0’s and 1’s.
    /// The task is to find the index of first ‘1’ in the given array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains an Integer N denoting size of array and the second line contains N space separated 0 and 1.
    /// 
    /// Output:
    /// For each test case, in a new line print the index of first 1. If 1 is not present in the array then print “-1”.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 0 <= Ai <= 10e18    (>>> This is wrong!!!)
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 10
    /// 0 0 0 0 0 0 1 1 1 1
    /// 4
    /// 0 0 0 0
    /// 
    /// Output:
    /// 6
    /// -1
    /// 
    /// Explanation:
    /// Test case 1: First index where 1 is presented is 6.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class IndexOfOne
    {
        /// <summary>
        /// The execution time is 0.24
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                tests[i] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var result = test.IndexOf('1');
                Console.WriteLine(result == -1 ? -1 : result / 2);
            }
        }

        /// <summary>
        /// The execution time is 1.05
        /// </summary>
        public static void RunSingleLine()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                tests[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(Array.IndexOf(test.Split(' '), "1"));
            }
        }

        /// <summary>
        /// The execution time is 0.27
        /// </summary>
        public static void RunThis()
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
                var n = int.Parse(test[0]);
                var i = 0;
                var scanner = new StringScanner(test[1]);
                while (scanner.HasNext)
                {
                    if (scanner.NextDigit() == 1)
                    {
                        break;
                    }

                    i++;
                }

                Console.WriteLine(i == n ? -1 : i);
            }
        }
    }
}