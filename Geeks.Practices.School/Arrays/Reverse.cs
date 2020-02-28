using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// !!! THE ORIGINAL PROBLEM STATEMENT HAS BEEN UPDATED !!!
    /// (The original title of the problem is "Reverse an Array")
    /// 
    /// Print the reverse of the given array.
    /// 
    /// Input:
    /// First line is the number of test cases. 
    /// Then for each test case, there will be a line of input that contains the elements separated by spaces. 
    /// 
    /// Output:
    /// For each test case, print the array in reverse order.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class Reverse
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            for (var i = 0; i < t; i++)
            {
                var elements = Console.ReadLine().Split(' ');

                for (var k = elements.Length - 1; k > 0; k--)
                {
                    results[i] += $"{elements[k]} ";
                }

                results[i] += elements[0];
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}