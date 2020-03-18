using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Total count"
    /// 
    /// Given an array of positive integers and a number K
    ///     where K is used as threshold value to divide each element of the array into sum of different numbers.
    /// Find the sum of count of the numbers in which array elements are divided.
    /// 
    /// Input:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of two lines.
    /// The first line of each test case consists of an integer N and K, where N is the size of array and K is the threshold value.
    /// The second line of each test case contains N space separated integers denoting array elements.
    /// 
    /// Output:
    /// Corresponding to each test case, print the total count.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 10e7
    /// 0 ≤ Ai ≤ 10e7
    /// 1 ≤ K ≤ 10e7
    /// 
    /// Example
    /// Input:
    /// 4
    /// 4 3
    /// 5 8 10 13
    /// 42 8
    /// 335 501 170 725 479 359 963 465 706 146 282 828 962 492 996 943 828 437 392 605 903 154 293 383 422 717 719 896 448 727 772 539 870 913 668 300 36 895 704 812 323 334
    /// 24 8
    /// 315 504 449 201 459 619 581 797 799 282 590 799 10 158 473 623 539 293 39 180 191 658 959 192 
    /// 7 14
    /// 75 193 808 920 275 687 918
    /// Output:
    /// 14
    /// 3072
    /// 1349
    /// 280
    /// 
    /// Explanation of test case 1:
    /// Each number can be expressed as sum of different numbers less than or equal to K(=3) as
    ///     5 (3 + 2),
    ///     8 (3 + 3 + 2),
    ///     10 (3 + 3 + 3 + 1),
    ///     13 (3 + 3 + 3 + 3 + 1).
    /// So, the sum of count of each element is 14.
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class TotalCount
    {
        /// <summary>
        /// The execution time is "0.31"
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
                var split = test[0].Split(' ');
                // var n = int.Parse(split[0]); skip the number of elements
                var k = double.Parse(split[1]);
                double total = 0;
                var scanner = new StringScanner(test[1]);
                while (scanner.HasNext)
                {
                    total += Math.Ceiling(scanner.NextPositiveDouble() / k);
                }

                Console.WriteLine(total);
            }
        }
    }
}