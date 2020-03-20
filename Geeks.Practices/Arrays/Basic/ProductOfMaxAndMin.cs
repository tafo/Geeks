using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Product of maximum in first array and minimum in second"
    /// 
    /// Given two arrays of A and B respectively of sizes N1 and N2,
    ///     the task is to calculate the product of maximum element of first array and minimum element of second array.
    /// 
    /// Input:
    /// The first line of the input contains a single integer T, denoting the number of test cases.
    /// Then T test case follows.
    /// Each test case contains 4 lines.
    /// First line contains size of the first array N1,
    ///     next line contains elements of the first array separated by spaces.
    ///         Third line contains size of the second array N2
    ///             and next line contains elements of the second array separated by spaces.
    /// 
    /// Output:
    /// For each test case, output the product of the max element of the first array and the minimum element of the second array.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N1, N2 <= 10e6
    /// -10e8 <= Ai <= 10e8
    /// 
    /// Example:
    /// 
    /// Input:
    /// 4
    /// 6
    /// 5 7 9 3 6 2
    /// 6
    /// 1 2 6 -1 0 9
    /// 6
    /// 1 4 2 3 10 2
    /// 6
    /// 4 2 6 5 2 9
    /// 5
    /// 0 0 0 0 0
    /// 1
    /// 999
    /// 6
    /// -1 -2 -3 -4 -5 -6
    /// 6
    /// 1 2 3 4 5 6
    /// 
    /// Output:
    /// -9
    /// 20
    /// 0
    /// -1
    /// 
    /// Explanation:
    /// Testcase 1:
    ///     The first array is 5 7 9 3 6 2.
    ///     The max element among these elements is 9.
    ///     The second array is 1 2 6 -1 0 9.
    ///     The min element among these elements is -1.
    /// The product of 9 and -1 is 9*-1=-9.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ProductOfMaxAndMin
    {
        /// <summary>
        /// The execution time is 0.30
        /// </summary>
        public static void RunCompareTo()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[4];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
                tests[i][3] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var max = StringScanner.GetInt(test[1], int.Parse(test[0])).Max();
                var min = StringScanner.GetInt(test[3], int.Parse(test[2])).Min();
                Console.WriteLine(max * min);
            }
        }

        /// <summary>
        /// The execution time is 0.30
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                Console.ReadLine();
                tests[i][0] = Console.ReadLine().TrimEnd();
                Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var scanner = new StringScanner(test[0]);
                var max = -100000000;
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt();
                    if (number > max)
                    {
                        max = number;
                    }
                }
                scanner.Reset(0, test[1]);
                var min = 100000000;
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt();
                    if (number < min)
                    {
                        min = number;
                    }
                }

                Console.WriteLine(max * min);
            }
        }
    }
}