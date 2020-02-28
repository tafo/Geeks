using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// ToDo : Fix the original problem statement.
    /// (The original title of the problem is "Value equal to index value")
    /// 
    /// Given an array of positive integers. Your task is to find that element whose value is equal to that of its index value.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// The first line of each test case is N, size of array. The second line of each test case contains array elements.
    /// 
    /// Output:
    /// Print the element whose value is equal to index value. Print "Not Found" when index value does not match with value.
    /// Note: There can be more than one element in the array which have same value as their index.
    /// You need to print every such element's index separated by a single space. Follows 1-based indexing of the array.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class ValueEqualToIndex
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n); // Actually, I can skip the number of elements by using the length of the elements. 
                var elements = Console.ReadLine().Split(' ');

                for (var k = 0; k < n; k++)
                {
                    if (k + 1 == int.Parse(elements[k]))
                    {
                        results[i] += $"{k + 1} ";
                    }
                }

                if (string.IsNullOrEmpty(results[i]))
                {
                    results[i] = "Not Found";
                }
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}