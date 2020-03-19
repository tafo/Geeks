using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sum of distinct elements"
    /// 
    /// You are given an array of size N.
    /// Find the sum of distinct elements in an array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains two lines of input:
    /// The first line is N, the size of array.
    /// The second line contains N elements separated by spaces.
    /// 
    /// Output:
    /// For each test case, print the sum of all distinct elements.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 200
    /// 1 ≤ N ≤ 10e7
    /// 0 ≤ A[i] ≤ 10e3
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 5
    /// 1 2 3 4 5
    /// 5
    /// 5 5 5 5 5
    /// 4
    /// 22 33 22 33
    /// Output:
    /// 15
    /// 5
    /// 55
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SumOfDistinctNumbers
    {
        /// <summary>
        /// The execution time is 0.42
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var pre = numbers[0];
                var sum = pre;
                for (var i = 1; i < n; i++)
                {
                    var current = numbers[i];
                    if (current == pre) continue;
                    sum += pre = current;
                }

                Console.WriteLine(sum);
            }
        }
    }
}