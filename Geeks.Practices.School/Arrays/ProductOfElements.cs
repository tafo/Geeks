using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// Calculate the product of all elements in an array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// The first line of each test case contains an integer N denoting the number of elements.
    /// The second line of each test case contains the elements.
    /// 
    /// Output:
    /// For each test case print the product of all elements in a new line.
    /// </summary>
    internal class ProductOfElements
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var output = new int[t];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                var elements = Console.ReadLine().Split(' ');
                var product = 1;

                for (var k = 0; k < n; k++)
                {
                    product *= int.Parse(elements[k]);
                }

                output[i] = product;
            }

            foreach (var result in output)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}