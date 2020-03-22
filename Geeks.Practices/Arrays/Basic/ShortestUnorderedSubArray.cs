using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Shortest un-ordered sub array"
    /// 
    /// Given an array of n distinct elements.
    /// Find the length of shortest unordered (neither increasing nor decreasing) sub array in given array.
    /// 
    /// Input:
    /// The first line consists of an integer T i.e number of test cases.
    /// The first line of each test case consists of an integer n.
    /// The next line consists of n spaced numbers. 
    /// 
    /// Output:
    /// Print the required output.
    /// 
    /// Constraints: 
    /// 1 <= T <= 100
    /// 1 <= n <= 100
    /// 1 <= a[i] <= 10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 5
    /// 7 9 10 8 11
    /// 4
    /// 1 2 3 5
    /// 5
    /// 1 2 3 4 5
    /// 9
    /// 1 3 5 6 7 9 11 13 15
    /// 29
    /// 70689 97370 67918 69918 66997 43325 87744 59471 12184 98491 95500 89773 6726 85645 55591 17506 68140 2955 69787 7670 38083 8543 88465 10198 39508 59356 28805 76349 78612
    /// 
    /// Output:
    /// 3
    /// 0
    /// 0
    /// 0
    /// 3
    /// 
    /// Explanation:
    /// Testcase 1:
    /// Shortest unsorted subarray is 9, 10, 8 which is of 3 elements.
    ///
    /// Remark:
    /// If there is an unsorted sub-array, we do not have to check its length.
    /// Because the length of the shortest unsorted sub-array will be 3.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ShortestUnorderedSubArray
    {
        /// <summary>
        /// The execution time is 0.08
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
                if (n == 1)
                {
                    Console.WriteLine(0);
                    continue;
                }

                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Console.WriteLine(numbers.Skip(1).Select((x, i) => x.CompareTo(numbers[i - 1])).Distinct().Count() == 1 ? 0 : 3);
            }
        }

        /// <summary>
        /// The execution time is 0.12
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
                if (n == 1)
                {
                    Console.WriteLine(0);
                    continue;
                }
                var scanner = new StringScanner(test[1]);
                var previous = scanner.NextPositiveInt();
                var current = scanner.NextPositiveInt();
                var isAscending = current > previous;
                previous = current;
                var result = 0;
                while (scanner.HasNext)
                {
                    current = scanner.NextPositiveInt();
                    if (isAscending && current < previous || !isAscending && current > previous)
                    {
                        result = 3;
                        break;
                    }

                    previous = current;
                }

                Console.WriteLine(result);
            }
        }
    }
}