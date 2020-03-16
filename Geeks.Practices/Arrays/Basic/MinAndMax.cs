using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find minimum and maximum element in an array"
    /// 
    /// Given an array A of size N of integers.
    /// Your task is to find the minimum and maximum elements in the array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains 2 lines of input.
    /// The first line of each test case contains the size of array N.
    /// The following line contains elements of the array separated by spaces.
    /// 
    /// Output:
    /// For each test case, print the minimum and maximum element of the array.
    /// 
    /// Constraints:
    /// 1 <= T  <= 100
    /// 1 <= N  <= 1000
    /// 1 <= Ai <= 10e12
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6
    /// 3 2 1 56 10000 167
    /// 5
    /// 1 345 234 21 56789
    /// Output:
    /// 1 10000
    /// 1 56789
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinAndMax
    {
        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void Run()
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
                var scanner = new StringScanner(test[1]);
                var numbers = scanner.GetAllPositiveInt64(n);
                Array.Sort(numbers);

                Console.WriteLine("{0} {1}", numbers[0], numbers[n - 1]);
            }
        }

        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunThis()
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
                var scanner = new StringScanner(test);
                var min = long.MaxValue;
                long max = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt64();
                    if (number < min)
                    {
                        min = number;
                    }

                    if (number > max)
                    {
                        max = number;
                    }
                }

                Console.WriteLine("{0} {1}", min, max);
            }
        }
    }
}