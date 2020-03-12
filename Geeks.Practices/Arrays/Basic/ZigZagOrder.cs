using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Convert array into Zig-Zag fashion"
    /// 
    /// Given an array A (distinct elements) of size N.
    /// Rearrange the elements of array in zig-zag fashion.
    /// The converted array should be in form "a < b > c < d > e < f"
    /// The relative order of elements is same in the output i.e you have to iterate on the original array only.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T testcases follow.
    /// Each testcase contains two lines of input.
    /// The first line contains a single integer N denoting the size of array.
    /// The second line contains N space-separated integers denoting the elements of the array.
    /// 
    /// Output:
    /// For each testcase, print the array in Zig-Zag fashion.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 100
    /// 0 <= Ai <= 10000
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 7
    /// 4 3 7 8 6 2 1
    /// 4
    /// 1 4 3 2
    /// 33
    /// 6202 4625 5469 2038 5916 3405 5533 7004 2469 9853 4992 361 9819 3294 7195 4036 9404 8767 5404 1711 3214 3100 3751 2139 5437 4993 1759 9572 6270 3789 9623 2472 9493
    /// 3
    /// 5469 2038 5916
    /// 
    /// Output:
    /// 3 7 4 8 2 6 1
    /// 1 4 2 3
    /// 4625 6202 2038 5916 3405 5533 5469 7004 2469 9853 361 9819 3294 7195 4036 9404 4992 8767 1711 5404 3100 3751 2139 5437 3214 4993 1759 9572 3789 9623 2472 9493 6270
    /// 5469 5916 2038
    ///
    /// Remark:
    /// Actually, this practice is faulty!!!
    ///     If the elements are "3, 2, 1", there is not a greater element than 3 at an index that is greater than the index of 3.
    ///     So, do not mind the relative order. 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ZigZagOrder
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run()
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
                var n = int.Parse(testCase[0]);
                var scanner = new StringScanner(testCase[1]);
                var elements = new int[n];
                var i = 0;

                var flag = true;
                var left = scanner.NextUInt();
                while (scanner.HasNext)
                {
                    var right = scanner.NextUInt();
                    if (flag && left < right || !flag && left > right)
                    {
                        elements[i++] = left;
                        left = right;
                    }
                    else
                    {
                        elements[i++] = right;
                    }

                    flag = !flag;
                }

                elements[i] = left;
                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run1()
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
                var n = int.Parse(testCase[0]);
                var scanner = new StringScanner(testCase[1]);
                var elements = new int[n];
                var i = 0;

                while (scanner.HasNext)
                {
                    elements[i++] = scanner.NextUInt();
                }

                var flag = true;
                for (var k = 0; k < n - 1; k++)
                {
                    if (flag && elements[k] > elements[k + 1] || !flag && elements[k] < elements[k + 1])
                    {
                        var backup = elements[k];
                        elements[k] = elements[k + 1];
                        elements[k + 1] = backup;
                    }

                    flag = !flag;
                }

                Console.WriteLine(string.Join(' ', elements));
            }
        }
    }
}