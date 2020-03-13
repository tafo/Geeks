using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimize the sum of product"
    /// 
    /// You are given two arrays, A and B, of equal size N.
    /// The task is to find the minimum value of A[0] * B[0] + A[1] * B[1] +…+ A[N-1] * B[N-1],
    ///     where shuffling of elements of arrays A and B is allowed.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the no of test cases.
    /// Then T test cases follow. Each test case contains three lines.
    /// The first line contains an integer N denoting the size of the arrays.
    /// In the second line are N space separated values of the array A[], and in the last line are N space separated values of the array B[].
    /// 
    /// Output:
    /// For each test case, print the minimum sum.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= A[] <= 10e18
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 3 
    /// 3 1 1
    /// 6 5 4
    /// 5
    /// 6 1 9 5 4
    /// 3 4 8 2 4
    /// Output:
    /// 23 
    /// 80
    /// 
    /// Explanation:
    /// For testcase1: 1*6+1*5+3*4 = 6+5+12 = 23 is the minimum sum
    /// For testcase2: 2*9+3*6+4*5+4*4+8*1 =18+18+20+16+8 = 80 is the minimum sum
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinimizeSumOfProduct
    {
        /// <summary>
        /// The execution time is 1.21
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
                tests[i][2] = Console.ReadLine().Trim();
            }

            for (var i = 0; i < tests.GetLength(0); i++)
            {
                var n = int.Parse(tests[i][0]);
                var leftNumbers = tests[i][1].Split(' ').Select(long.Parse).OrderBy(x => x);
                var rightNumbers = tests[i][2].Split(' ').Select(long.Parse).OrderByDescending(x => x).ToArray();
                Console.WriteLine(leftNumbers.Select((x, k) => x * rightNumbers[k]).Sum());
            }
        }
    }
}