using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sum of f(a[i], a[j]) over all pairs in an array of n integers"
    /// 
    /// Given an array A of n integers, find the sum of f(a[i], a[j]) of all pairs (i, j) such that (1 <= i < j <= n).
    /// 
    /// f(a[i], a[j]):
    ///     If | a[j]-a[i] | > 1
    ///         f(a[i], a[j]) = a[j] - a[i]
    ///     Else  if | a[j]-a[i] | <= 1
    ///         f(a[i], a[j]) = 0
    /// 
    /// Input:
    /// The first line of the input contains T denoting the number of test cases.
    /// For each test case, the first line contains integer n denoting the size of the array A,
    ///     followed by n space separated integers denoting the element of array A.
    /// 
    /// Output:
    /// For each test case, the output is an integer denoting the sumof f(a[i],a[j]) of all pairs. 
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=50
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 4
    /// 6 6 4 4
    /// 5
    /// 1 2 3 1 3
    /// Output:
    /// -8
    /// 4
    /// 
    /// Explanation:
    /// 1. All pairs are: (6 - 6) + (4 - 6) + (4 - 6) + (4 - 6) + (4 - 6) + (4 - 4) = -8
    /// 2. The pairs that add up are: (3, 1), (3, 1) to give 4, rest all pairs according to condition gives 0.
    ///
    /// Remarks:
    /// 1) The explanation of the 2nd test case is not clear!
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class StrangeFunction
    {
        /// <summary>
        /// The execution time is 0.15
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
                var result = 0;
                for (var i = 0; i < n - 1; i++)
                {
                    for (var j = i; j < n; j++)
                    {
                        var dif = numbers[j] - numbers[i];
                        if (Math.Abs(dif) > 1)
                        {
                            result += dif;
                        }
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}