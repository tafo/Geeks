using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Number of occurence"
    /// 
    /// Given a sorted array A of size N and a number X, you need to find the number of occurrences of X in A.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains two lines of input:
    ///     The first line contains N and X(element whose occurrence needs to be counted).
    ///     The second line contains the elements of the array separated by spaces.
    /// 
    /// Output:
    /// For each test case, print the count of the occurrences of X in the array, if count is zero then print -1.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 10e5
    /// 1 ≤ A[i] ≤ 10e3
    /// 1 <= X <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 7 2
    /// 1 1 2 2 2 2 3
    /// 7 4
    /// 1 1 2 2 2 2 3
    /// 
    /// Output:
    /// 4
    /// -1
    /// 
    /// Explanation:
    /// Testcase 1: 2 occurs 4 times in 1 1 2 2 2 2 3
    /// Testcase 2: 4 is not present in 1 1 2 2 2 2 3
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class NumberOfOccurence
    {
        /// <summary>
        /// The execution time is 0.13
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
                var split = testCase[0].Split(' ');
                // var n = int.Parse(split[0]); Skip the number of elements
                var key = int.Parse(split[1]);
                var scanner = new StringScanner(testCase[1]);
                var counter = 0;
                while (scanner.HasNext)
                {
                    if (key == scanner.NextPositiveInt())
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counter == 0 ? -1 : counter);
            }
        }
    }
}