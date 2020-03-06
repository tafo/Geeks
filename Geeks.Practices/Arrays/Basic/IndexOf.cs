using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Search an Element in an array"
    /// 
    /// Given an integer array Arr[] and an element x. The task is to find if the given element is present in array or not.
    /// 
    /// Input:
    /// First line contains an integer, the number of test cases 'T'.
    /// For each test case,
    ///     first line contains an integer 'N', size of array.
    ///     The second line contains the elements of the array separated by spaces.
    ///     Third line contains element to be find in the array.
    /// 
    /// Output:
    /// For each test case, output a single line containing first index of element to be found in array.
    ///     If element is not in the array, then print "-1" (without quotes).
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 100
    /// 1 <= Arr[i] <= 100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 4
    /// 1 2 3 4
    /// 3
    /// 2 4 7 8
    /// 1
    /// 
    /// Output:
    /// 2
    /// -1
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class IndexOf
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        internal static void Run()
        {
            var t = byte.Parse(Console.ReadLine());
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
                var value = int.Parse(testCase[2]);
                var scanner = new StringScanner(testCase[1]);
                var index = 0;

                while (scanner.HasNext)
                {
                    if (scanner.NextInt() == value)
                    {
                        break;
                    }

                    index++;
                }

                if (index == n)
                {
                    Console.WriteLine("-1");
                }
                else
                {
                    Console.WriteLine(index);
                }
            }
        }
    }
}