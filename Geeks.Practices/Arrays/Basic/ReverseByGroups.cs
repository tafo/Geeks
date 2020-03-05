using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title of the practice is "Reverse array in groups"
    /// 
    /// Given an array arr[] of positive integers of size N. Reverse every sub-array of K group elements.
    /// 
    /// Input:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of two lines of input.
    ///     The first line of each test case consists of an integer N(size of array) and an integer K separated by a space.
    ///     The second line of each test case contains N space separated integers denoting the array elements.
    /// 
    /// Output:
    /// For each test case, print the modified array.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 200
    /// 1 ≤ N, K ≤ 107
    /// 1 ≤ A[i] ≤ 1018
    /// 
    /// Example:
    /// Input
    /// 2
    /// 5 3
    /// 1 2 3 4 5
    /// 6 2
    /// 10 20 30 40 50 60
    /// 
    /// Output
    /// 3 2 1 5 4
    /// 20 10 40 30 60 50
    /// 
    /// Test case 1:
    /// Reversing groups in size 3,
    ///     The first group consists of elements 1, 2, 3. Reversing this group, we have elements in order as 3, 2, 1.
    ///     The second group consists of elements 4, 5. Reversing this group, we have elements in order as 5,4.
    ///     So, the result will be 3, 2, 1, 5, 4
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class ReverseByGroups
    {
        /// <summary>
        /// This is not the best solution!
        /// The execution time is 0.67
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine().Split(' ')[1];
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var k = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ');
                var resultBuilder = new StringBuilder();

                var n = elements.Length;
                var x = n / k;
                for (var i = 0; i < x; i++)
                {
                    Array.Reverse(elements, i * k, k);
                }

                var position = x * k;

                if (n > position)
                {
                    Array.Reverse(elements, position, n - position);
                }

                foreach (var element in elements)
                {
                    resultBuilder.Append(element);
                    resultBuilder.Append(" ");
                }

                Console.WriteLine(resultBuilder.ToString().TrimEnd());
            }
        }

        /// <summary>
        /// This is not the best solution!
        /// The execution time is 0.69
        /// </summary>
        internal static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine().Split(' ')[1];
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var k = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ');
                var resultBuilder = new StringBuilder();

                var n = elements.Length;
                var x = n / k;

                for (var i = 0; i < x; i++)
                {
                    for (var j = k - 1; j >= 0; j--)
                    {
                        resultBuilder.Append(elements[k * i + j]);
                        resultBuilder.Append(" ");
                    }
                }

                if (n > x * k)
                {
                    for (var i = n - 1; i >= x * k; i--)
                    {
                        resultBuilder.Append(elements[i]);
                        resultBuilder.Append(" ");
                    }
                }

                Console.WriteLine(resultBuilder.ToString().TrimEnd());
            }
        }
    }
}