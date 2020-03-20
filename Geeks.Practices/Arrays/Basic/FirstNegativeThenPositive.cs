using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Arranging the array"
    /// 
    /// You are given an array of size N.
    /// Rearrange the given array in-place such that all the negative numbers occur before positive numbers.
    ///     (Maintain the order of all -ve and +ve numbers as given in the original array).
    /// 
    /// Input:
    /// The first line consists of an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains two lines of input.
    /// The first line contains the size of the array denoted by N.
    /// Then in the next line are N space separated elements of the array.
    /// 
    /// Output:
    /// For each test case, print the array after rearranging with spaces between the elements of the array.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// -10e18 <= Elements of array <= 10e18
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 4
    /// -3 3 -2 2
    /// 5
    /// 2 -4 7 -3 4
    ///
    /// Output:
    /// -3 -2 3 2
    /// -4 -3 2 7 4
    /// 
    /// Explanation:
    /// Testcase 1:
    /// In the given array, negative numbers are -3, -2 and positive numbers are 3, 2.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FirstNegativeThenPositive
    {
        /// <summary>
        /// The execution time is 0.52
        /// </summary>
        public static void RunSingleLineLinq()
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
                Console.WriteLine(string.Join(' ', StringScanner.GetLong(test[1], int.Parse(test[0])).OrderBy(x => x >= 0)));
            }
        }

        /// <summary>
        /// The execution time is 0.40
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
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetLong(test[1], n);
                var negatives = numbers.Where(x => x < 0);
                var positives = numbers.Where(x => x >= 0);
                Console.WriteLine(string.Join(' ', negatives.Concat(positives)));
            }
        }

        /// <summary>
        /// The execution time is 0.39
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
                var i = 0;
                var k = n - 1;
                var numbers = new long[n];
                while (scanner.HasNext)
                {
                    var number = scanner.NextLong();
                    if (number < 0)
                    {
                        numbers[i++] = number;
                    }
                    else
                    {
                        numbers[k--] = number;
                    }
                }
                Array.Reverse(numbers, i, n - i);
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}