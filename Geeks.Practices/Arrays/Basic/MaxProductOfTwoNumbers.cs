using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Maximum product of two numbers"
    /// 
    /// Given an array with all elements greater than or equal to zero.
    /// Return the maximum product of two numbers possible.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// The first line of each test case is N, size of array. The second line of each test case contains array elements.
    /// 
    /// Output:
    /// Print the maximum product of two numbers possible.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 2 ≤ N ≤ 10e7
    /// 0 ≤ A[i] ≤ 10e4
    /// 
    /// Example:
    /// Input:
    /// 1
    /// 5
    /// 1 100 42 4 23
    /// 
    /// Output:
    /// 4200
    /// 
    /// Explanation:
    /// Test case 1: Two maximum numbers are 100 and 42 and their product is 4200.
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaxProductOfTwoNumbers
    {
        /// <summary>
        /// The execution time is 0.27
        /// </summary>
        public static void RunThis()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                tests[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var max = 0;
                var second = 0;
                var scanner = new StringScanner(test);
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number <= second) continue;
                    
                    if (number > max)
                    {
                        second = max;
                        max = number;
                    }
                    else
                    {
                        second = number;
                    }
                }
                Console.WriteLine(max * second);
            }
        }
    }
}