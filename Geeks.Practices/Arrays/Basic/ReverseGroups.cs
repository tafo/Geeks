using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Reverse array in groups"
    /// 
    /// Given an array arr[] of positive integers of size N.
    /// Reverse every sub-array of K group elements.
    /// 
    /// Input Format:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of two lines of input.
    /// The first line of each test case consists of an integer N(size of array) and an integer K separated by a space.
    /// The second line of each test case contains N space separated integers denoting the array elements.
    /// 
    /// Output Format:
    /// For each test case, in a new line, print the modified array.
    /// 
    /// User Task:
    /// The task is to complete the function reverseInGroups() which reverses elements of the array in groups and returns the array.
    /// The printing of array is done by driver code.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 200
    /// 1 ≤ N, K ≤ 10e7
    /// 1 ≤ A[i] ≤ 10e18
    /// 
    /// Example:
    /// 
    /// Input
    /// 4
    /// 5 3
    /// 1 2 3 4 5
    /// 4 3
    /// 5 6 8 9
    /// 4 7
    /// 5 6 8 9
    /// 8 3
    /// 1 2 3 4 5 6 7 8
    /// 
    /// Output
    /// 3 2 1 5 4
    /// 8 6 5 9
    /// 9 8 6 5
    /// 3 2 1 6 5 4 8 7
    /// 
    /// Explanation:
    /// Test case 1:
    ///     Reversing groups in size k = 3, first group consists of elements 1, 2, 3.
    ///     Reversing this group, we have elements in order as 3, 2, 1.
    /// Test case 2:
    ///     Our array is 5 6 8 9.
    ///     The value of k is 3.
    ///     So we reverse it in groups of 3.
    ///     After reversing, it becomes 8 6 5 9.
    /// Test case 3:
    ///     Our array is 5 6 8 9.
    ///     The value of k is 7.
    ///     After reversing, it becomes 9 8 6 5.
    /// Test case 4:
    ///     Our array is 1 2 3 4 5 6 7 8.
    ///     The value of k is 3.
    ///     After reversing, it becomes 3 2 1 6 5 4 8 7.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ReverseGroups
    {
        /// <summary>
        /// The execution time of the equivalent JAVA solution is 1.31. But, ... Anyway!
        /// </summary>
        public static void RunThis()
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);

                Console.WriteLine(string.Join(' ', ReverseInGroups(numbers, n, k)));
            }
        }

        /// <summary>
        /// The signature of this method is given by GfG
        /// </summary>
        public static int[] ReverseInGroups(int[] mv, int n, int k)
        {
            var result = new int[n];
            var groupCount = n / k;
            var i = 0;
            for (var a = 0; a < groupCount; a++)
            {
                for (var b = k - 1; b >= 0; b--)
                {
                    result[a * k + b] = mv[i++];
                }
            }

            var m = n;
            while (i < n)
            {
                result[--m] = mv[i++];
            }

            return result;
        }
        
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var scanner = new StringScanner(test[1]);
                var groupCount = n / k;
                var result = new long[n];

                for (var a = 0; a < groupCount; a++)
                {
                    for (var b = k - 1; b >= 0; b--)
                    {
                        result[a * k + b] = scanner.NextPositiveLong();
                    }
                }

                while (scanner.HasNext)
                {
                    result[--n] = scanner.NextPositiveLong();
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}