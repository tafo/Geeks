using System;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// Given an integer array A of size N, find sum of elements in it.
    /// Input:
    /// First line contains an integer denoting the test cases 'T'.
    /// Each test case contains two lines of input. First line contains N the size of the array A. The second line contains the elements of the array. 
    /// Output:
    /// For each test case, print the sum of all elements of the array in separate line.
    /// </summary>
    public class SumOfElements
    {
        /// Without displaying "incorrect input" warnings
        public static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);

            var input = new int[t][];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                input[i] = new int[n];
                var elements = Console.ReadLine()?.Trim().Split(' ');

                for (var k = 0; k < elements?.Length; k++)
                {
                    input[i][k] = int.Parse(elements[k]);
                }
            }

            // Without converting into LINQ-Expression
            foreach (var elements in input)
            {
                var sum = 0;

                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var e in elements)
                {
                    sum += e;
                }

                Console.WriteLine(sum);
            }

            Console.ReadKey();
        }
    }
}