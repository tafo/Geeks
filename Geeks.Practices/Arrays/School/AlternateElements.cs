using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.School
{
    /// <summary>
    /// You are given an array A of size N. You need to print elements of A in alternate order.
    /// 
    /// Input Format:
    /// The first line of input contains T denoting the number of test cases. T test cases follow.
    /// Each test case contains two lines of input. The first line contains N and the second line contains the elements of the array.
    /// 
    /// Output Format:
    /// For each test case, print the alternate elements of the array(starting from index 0).
    ///
    /// Anyway!!! At least I learned what "alternating (elements)" means.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    internal class AlternateElements
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new int[t][];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                input[i] = new int[n];
                var elements = Console.ReadLine().Trim().Split(' ');

                for (var k = 0; k < n; k++)
                {
                    input[i][k] = int.Parse(elements[k]);
                }
            }

            foreach (var elements in input)
            {
                for (var i = 0; i < elements.Length; i+=2)
                {
                    Console.Write(elements[i]);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}