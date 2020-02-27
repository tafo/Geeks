using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
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