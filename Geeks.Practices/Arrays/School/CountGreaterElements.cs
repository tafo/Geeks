using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.School
{
    /// <summary>
    /// Given an sorted array A of size N. Find number of elements which are less than or equal to given element X.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains 3 lines of input.
    /// The first line contains an integer N denoting the size of the array.
    /// Then the next line contains space-separated integer elements.
    /// The third line contains the number that will be compared.
    /// 
    /// Output:
    /// For each test case, print the number of elements that are less than or equal to the given number in a new line.
    ///
    /// >>> Update
    /// >>> Find the number of elements that are greater than the given number in order to have a more elegant class name :) 
    /// 
    /// </summary>
    internal class CountGreaterElements
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);

            // Because of we will display only the number of elements, We do not need to use a jagged array
            var output = new int[t];
            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);

                var elements = Console.ReadLine().Split(' ');

                int.TryParse(Console.ReadLine(), out var x);

                var count = 0;
                for (var k = 0; k < n; k++)
                {
                    if (int.Parse(elements[k]) > x)
                    {
                        count++;
                    }
                }

                output[i] = count;
            }

            foreach (var result in output)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}