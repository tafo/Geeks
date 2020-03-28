using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Longest increasing sub array"
    /// 
    /// Given an array containing n numbers.
    /// The problem is to find the length of the longest contiguous sub array
    ///     such that every element in the sub array is strictly greater than its previous element in the same sub array.
    /// Time Complexity should be O(n).
    /// 
    /// Input:
    /// The first line consists of an integer T i.e number of test cases.
    /// The first line of each test case consists of an integer n.
    /// The next line contains n spaced integers.
    /// 
    /// Output:
    /// Print the required output.
    /// 
    /// Constraints: 
    /// 1<=T<=100
    /// 1<=n<=100
    /// 1<=a[i]<=10e4
    /// 
    /// Example:
    /// 
    /// Input:
    /// 5
    /// 9
    /// 5 6 3 5 7 8 9 1 2
    /// 10
    /// 12 13 1 5 4 7 8 10 10 11
    /// 15
    /// 6988 5857 3744 6492 2228 8366 9860 1937 1433 2552 6438 9229 3276 5408 1475 
    /// 15
    /// 3922 461 6305 29 8028 8051 6749 7557 8903 4795 7698 8700 1044 1040 2003
    /// 4
    /// 4336 1258 3516 5057
    /// 
    /// Output:
    /// 5
    /// 4
    /// 4
    /// 3
    /// 3
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindLongestIncreasingSubArrayLength
    {
        /// <summary>
        /// The execution time is 0.13
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
                var counter = 1;
                var result = numbers.Skip(1).Select((x, i) => x > numbers[i] ? ++counter : counter = 1).DefaultIfEmpty(1).Max();
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.13
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
                // Skip the number of elements
                //var n = int.Parse(test[0]);

                var scanner = new StringScanner(test[1]);
                var left = scanner.NextPositiveInt();
                var counter = 1;
                var result = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number > left)
                    {
                        counter++;
                    }
                    else
                    {
                        result = Math.Max(result, counter);
                        counter = 1;
                    }

                    left = number;
                }

                Console.WriteLine(Math.Max(result, counter));
            }
        }
    }
}