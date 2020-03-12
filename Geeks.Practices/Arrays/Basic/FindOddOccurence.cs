using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find the Odd Occurence"
    /// 
    /// Given an array of positive integers where all numbers occur even number of times except one number which occurs odd number of times.
    /// Find the number.
    /// 
    /// Input:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of two lines.
    ///     The first line of each test case consists of an integer N, where N is the size of array.
    ///     The second line of each test case contains N space separated integers denoting array elements.
    ///
    /// Output:
    /// Corresponding to each test case, print the number which occur odd number of times. If no such element exists, print 0.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 10e7
    /// 1 ≤ A[i] ≤ 10e6
    /// 
    /// Example:
    /// 2
    /// 5
    /// 8 4 4 8 23
    /// 13
    /// 2 3 5 4 5 2 4 3 5 2 4 4 2
    /// Output:
    /// 23
    /// 5
    /// 
    /// Explanation:
    /// Test case 1: 23 is the element which occurs odd number of times.
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class FindOddOccurence
    {
        /// <summary>
        /// Using XOR
        /// The execution time is 0.29
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var scanner = new StringScanner(testCase[1]);
                var number = scanner.NextUInt();
                while (scanner.HasNext)
                {
                    number ^= scanner.NextUInt();
                }

                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// The execution time is 0.46
        /// </summary>
        internal static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var output = 0;
                var n = int.Parse(testCase[0]);
                if ((n & 1) == 1)
                {
                    var elements = new int[n];
                    var scanner = new StringScanner(testCase[1]);

                    var i = 0;
                    while (scanner.HasNext)
                    {
                        elements[i++] = scanner.NextUInt();
                    }

                    var sortedElements = elements.OrderBy(x => x).ToArray();
                    for (var k = 0; k < n; k += 2)
                    {
                        if (k != n - 1 && sortedElements[k] == sortedElements[k + 1]) continue;
                        output = sortedElements[k];
                        break;
                    }
                }
                Console.WriteLine(output);
            }
        }
    }
}