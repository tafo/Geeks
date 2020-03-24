using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find duplicates under given constraints"
    /// 
    /// Given a sorted array having 10 elements which contains 6 different numbers in which only 1 number is repeated five times.
    /// Your task is to find the duplicate number using two comparisons only.
    /// 
    /// Examples:
    /// 
    /// Input: A[] = {1, 1, 1, 1, 1, 5, 7, 10, 20, 30}
    /// Output: 1
    /// 
    /// Input: A[] = {1, 2, 3, 3, 3, 3, 3, 5, 9, 10}
    /// Output: 3
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the no of test cases.
    /// Then T test cases follow.
    /// Each test case contains 10 space separated values of the array A[].
    /// 
    /// Output:
    /// For each test case in a new line print the required duplicate element.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=A[i]<=10^5+5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 1 2 4 5 6 9 9 9 9 9
    /// 1 2 3 3 3 3 3 5 9 10
    /// 
    /// Output:
    /// 9
    /// 3
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindDuplicateElement
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).ToArray();
            }

            foreach (var test in tests)
            {
                if (test[4] < test[5] && test[5] < test[6])
                {
                    Console.WriteLine(test[4]);
                }
                else
                {
                    Console.WriteLine(test[5]);
                }
            }
        }
    }
}