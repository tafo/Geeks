using System;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Balanced Array"
    /// 
    /// Given an array of even size, task is to find minimum value that can be added to an element so that array become balanced.
    /// An array is balanced if the sum of the left half of the array elements is equal to the sum of right half.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains the number of elements in the array a[] as n and next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Print an integer which is the required answer.
    /// 
    /// Constraints:
    /// 1<=T<=20
    /// 2<=n<=10000
    /// 1<=a[i]<=100000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6
    /// 1 2 1 2 1 3
    /// 2
    /// 20 10
    /// 
    /// Output:
    /// 2
    /// 10
    /// 
    /// Explanation:
    /// Suppose, we have an array 1 2 1 2 1 3.
    /// The Sum of first three elements is 1 + 2 + 1 = 4 and sum of last three elements is 2 + 1 + 3 = 6
    /// So this is unbalanced, to make it balanced the minimum number we can add is 2 to any element in first half.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Balanced
    {
        /// <summary>
        /// The execution time is 0.13
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
                var h = n / 2;
                var leftTotal = 0;
                var rightTotal = 0;
                var i = 0;
                var scanner = new StringScanner(test[1]);
                while (scanner.HasNext && i++ < h)
                {
                    leftTotal += scanner.NextPositiveInt();
                }

                while (scanner.HasNext)
                {
                    rightTotal += scanner.NextPositiveInt();
                }

                Console.WriteLine(Math.Abs(rightTotal - leftTotal));
            }
        }
    }
}