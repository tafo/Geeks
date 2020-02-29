using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.School
{
    /// <summary>
    /// !!! THE ORIGINAL PROBLEM STATEMENT HAS BEEN UPDATED !!!
    /// (The original title is "Average")
    /// Print the moving average of the number stream.
    /// 
    /// Input: The first line of input is the number of test cases.
    /// For each test case there will be two lines.
    ///     The first line is the size.
    ///     The second line is the elements separated by spaces. 
    /// 
    /// Output:
    /// Print the moving average.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class MovingAverage
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var result = new int[t][];
            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                result[i] = new int[n];
                var elements = Console.ReadLine().Split(' ');
                var sum = 0;
                for (var k = 0; k < n; k++)
                {
                    result[i][k] = (sum += int.Parse(elements[k])) / (k + 1);
                }
            }

            foreach (var elements in result)
            {
                foreach (var element in elements)
                {
                    Console.Write($"{element} ");    
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}