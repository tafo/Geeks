using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays.Basic
{
    /// <summary>
    /// (The original title of the problem is "Missing number in array")
    /// 
    /// Given an array C of size N-1 and given that there are numbers from 1 to N with one element missing, the missing number is to be found.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// For each test case first line contains N(size of array). The subsequent line contains N-1 array elements.
    /// 
    /// Output:
    /// Print the missing number in array.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class MissingNumber
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                var checkList = new int[n];
                var elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in elements)
                {
                    checkList[int.Parse(element) - 1] = 1;
                }

                // IndexOf function will be handled in a different problem. 
                results[i] = Array.IndexOf(checkList, 0) + 1 + string.Empty;
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}