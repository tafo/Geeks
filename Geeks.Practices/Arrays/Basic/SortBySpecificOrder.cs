using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Soft in specific order"
    /// 
    /// Given an array A of positive integers.
    /// Sort them in such a way that the first part of the array contains odd numbers sorted in descending order,
    ///     rest portion contains even numbers sorted in ascending order.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains an integer N denoting the size of the array.
    /// The next line contains N space separated values of the array.
    /// 
    /// Output:
    /// For each test case in a new line print the space separated values of the modified array.
    /// 
    /// Constraints:
    /// 1 <= T <= 10e3
    /// 1 <= N <= 10e7
    /// 0 <= A[i] <= 10e18
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 7
    /// 1 2 3 5 4 7 10
    /// 7
    /// 0 4 5 3 7 2 1
    /// 
    /// Output:
    /// 7 5 3 1 2 4 10
    /// 7 5 3 1 0 2 4
    /// 
    /// Explanation:
    /// Testcase1: Array elements 7 5 3 1 are odd and sorted in descending order, whereas 2 4 10 are even numbers and sorted in ascending order.
    ///
    /// Remark:
    /// I started to use Linq
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SortBySpecificOrder
    {
        /// <summary>
        /// The execution time is 0.8
        /// ToDo : Implement a better solution
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
                var oddElements = new long[n];
                var evenElements = new long[n];
                var oddIndex = 0;
                var evenIndex = 0;
                
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt64();
                    if ((number & 1) == 1)
                    {
                        oddElements[oddIndex++] = number;
                    }
                    else
                    {
                        evenElements[evenIndex++] = number;
                    }
                }

                var elements = oddElements.Take(oddIndex).OrderByDescending(x => x).Concat(evenElements.Take(evenIndex).OrderBy(x => x));

                Console.WriteLine(string.Join(' ', elements));
            }
        }
    }
}