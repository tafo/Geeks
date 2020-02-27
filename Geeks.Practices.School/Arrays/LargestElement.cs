using System;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// Given an array a[] of size N. The task is to find the largest element in it.
    /// 
    /// Input:
    /// The first line of input contains an integer T, denoting the number of test cases.
    /// Then T test cases follow. Each test case contains an integer N, the number of elements in the array.
    /// Then next line contains N integers of the array separated by space.
    /// 
    /// Output:
    /// Print the maximum element in the array.
    /// </summary>
    public class LargestElement
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

            foreach (var elements in input)
            {
                var max = 0;
                
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var element in elements)
                {
                    if (element > max)
                    {
                        max = element;
                    }
                }

                Console.WriteLine(max);
            }

            Console.ReadKey();
        }
    }
}