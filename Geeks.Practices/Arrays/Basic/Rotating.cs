using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Rotating an Array"
    /// !!! Duplicate of "Rotate(Rotate Array)"
    ///
    /// Given an array of N size. The task is to rotate array by d elements where d is less than or equal to N.
    /// 
    /// Input:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow. Each test case consist of three lines.
    /// The first line of each test case consists of an integer N, where N is the size of array.
    /// The second line of each test case contains N space separated integers denoting array elements.
    /// The third line of each test case contains "d" .
    /// 
    /// Output:
    /// Corresponding to each test case, in a new line, print the modified array.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 200
    /// 1 ≤ N ≤ 200
    /// 1 ≤ A[i] ≤ 1000
    /// 
    /// Example:
    /// Input
    /// 1
    /// 5
    /// 1 2 3 4 5
    /// 2
    /// 
    /// Output
    /// 3 4 5 1 2
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class Rotating
    {
        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
                input[i][2] = Console.ReadLine();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = new int[n];
                var d = int.Parse(testCase[2]);
                
                var scanner = new StringScanner(testCase[1]);

                while (d > 0)
                {
                    elements[n - d--] = scanner.NextPositiveInt();
                }

                while (scanner.HasNext)
                {
                    elements[d++] = scanner.NextPositiveInt();
                }

                Console.WriteLine(string.Join(' ', elements));
            }
        }
    }
}