using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Maximum triplet sum in array"
    /// 
    /// Given an array, the task is to find maximum triplet sum in the array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains an Integer N denoting size of array and the second line contains N space separated elements.
    /// 
    /// Output:
    /// For each test case, print the maximum triplet sum in new line.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 3<=N<=10e6
    /// -10e5<=A[i]<=10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 6
    /// 1 0 8 6 4 2
    /// 7
    /// 1 2 3 0 -1 8 10
    ///
    /// Output:
    /// 18
    /// 21
    ///
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaxTripletSum
    {
        /// <summary>
        /// The execution time is 0.35
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
                var numbers = StringScanner.GetInt(test[1], n);
                Array.Sort(numbers, (a, b) => b.CompareTo(a));
                Console.WriteLine(numbers[0] + numbers[1] + numbers[2]);
            }
        }
    }
}