using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Binary Array Sorting"
    /// 
    /// Given a binary array A[] of size N.
    /// The task is to arrange array in increasing order.
    /// 
    /// Note: The binary array contains only 0  and 1.
    /// 
    /// Input:
    /// The first line of input contains an integer T, denoting the test cases.
    /// Every test case contains two lines.
    /// The first line is N(size of array).
    /// The second line is space-separated elements of the array.
    /// 
    /// Output:
    /// Space-separated elements of sorted arrays.
    /// There should be a new line between the output of every test case.
    /// 
    /// Your Task:
    /// Complete the function SortBinaryArray() which takes given array as input and returns the sorted array. 
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e6
    /// 0 <= e <= 1
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 0 1 1 0
    /// 10
    /// 1 0 1 1 1 1 1 0 0 0
    /// 
    /// Output:
    /// 0 0 1 1 1
    /// 0 0 0 0 1 1 1 1 1 1
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SortBinaryArray
    {
        /// <summary>
        /// (:
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine();
                Console.WriteLine(string.Join(' ', Console.ReadLine().TrimEnd().Split(' ').OrderBy(x => x)));
            }
        }

        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine();
                var input = Console.ReadLine().TrimEnd();
                var digits = input.Split(' ').Select(int.Parse).ToList();
                Console.WriteLine(string.Join(' ', Sort(digits)));
            }
        }

        public static List<int> Sort(List<int> digits)
        {
            var result = new int[digits.Count];
            var i = digits.Count - 1;
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var digit in digits)
            {
                if (digit == 1)
                {
                    result[i--] = 1;
                }
            }

            return result.ToList();
        }
    }
}