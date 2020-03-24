using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Making elements distinct"
    /// 
    /// Given a sorted integer array.
    /// We need to make array elements distinct by increasing values and keeping array sum minimum possible.
    /// We need to print the minimum possible sum as output.
    /// 
    /// Input:
    /// The first line of the input contains a single integer T denoting the number of test cases.
    /// The first line of each test case contains N.
    /// Followed by N separate integers. 
    /// 
    /// Output:
    /// For each test case print the minimum possible sum.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 2 ≤ N ≤ 10^4
    /// 1 ≤ A[i] ≤ 10^3
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 5
    /// 2 2 3 5 6
    /// 2
    /// 20 20
    ///
    /// Output:
    /// 20
    /// 41
    /// 
    /// Explanation:
    /// 
    /// Test Case 1:
    ///     We make the array as {2, 3, 4, 5, 6}.
    ///     Sum becomes 2 + 3 + 4 + 5 + 6 = 20
    /// 
    /// Test Case2 :
    ///     We make the array as {20, 21 }.
    ///     Sum becomes 41
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MakeElementsConsecutive
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
                Console.WriteLine(numbers.Skip(1).Select((x, i) => x <= numbers[i] ? numbers[i + 1] = numbers[i] + 1 : x).Sum() + numbers[0]);
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
                // var n = int.Parse(test[0]); Skip the number of elements
                var scanner = new StringScanner(test[1]);
                var left = scanner.NextPositiveInt();
                var sum = left;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number <= left)
                    {
                        sum += ++left;
                    }
                    else
                    {
                        sum += left = number;
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}