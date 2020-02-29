using System;

namespace Geeks.Practices.Arrays.School
{
    /// <summary>
    /// Write a program to find the sum of the given series 1+2+3+ . . . . . .(N terms) 
    /// 
    /// Input:
    /// The first line of input contains an integer, the number of test cases T. Each test case should contain a positive integer N.
    /// 
    /// Output:
    /// Print the sum in a separate line.
    ///
    /// Anyway!!! At least I practiced striking the keyboard. 
    /// 
    /// </summary>
    internal class SumOfSeries
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new int[t];
            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out input[i]);
            }

            foreach (var n in input)
            {
                Console.WriteLine(n * (n+1) / 2);
            }

            Console.ReadKey();
        }
    }
}