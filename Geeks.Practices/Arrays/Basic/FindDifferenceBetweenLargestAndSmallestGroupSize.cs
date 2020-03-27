using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Difference between highest and lowest occurrence"
    /// 
    /// Given an array, the task is to find the difference between highest occurrence and lowest occurrence of any number in an array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains a integer N and the second line contains N space separated array elements.
    /// 
    /// Output:
    /// For each test case, print the difference in new line.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10e5
    /// 1<=A[i]<=10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 3
    /// 1 2 2
    /// 6
    /// 1 2 2 3 3 3
    /// 
    /// Output:
    /// 1
    /// 2
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindDifferenceBetweenLargestAndSmallestGroupSize
    {
        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).GroupBy(x => x).Select(x => x.Count()).ToArray();;
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Max() - test.Min());
            }
        }

        /// <summary>
        /// The execution time is 0.14
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var groups = numbers.GroupBy(x => x).ToArray();
                var max = groups.Max(x => x.Count());
                var min = groups.Min(x => x.Count());
                Console.WriteLine(max - min);
            }
        }

        /// <summary>
        /// The execution time is 0.15
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
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);

                var count = 1;
                var min = n;
                var max = 0;
                for (var i = 1; i < n; i++)
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        count++;
                    }
                    else
                    {
                        min = Math.Min(min, count);
                        max = Math.Max(max, count);

                        count = 1;
                    }

                    if (i < n - 1 || count == 1) continue;

                    min = Math.Min(min, count);
                    max = Math.Max(max, count);
                }

                Console.WriteLine(max == 0 ? 0 : max - min);
            }
        }
    }
}