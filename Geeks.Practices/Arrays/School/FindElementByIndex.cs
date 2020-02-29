using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.School
{
    internal class FindElementByIndex
    {
        /// <summary>
        /// !!! THE ORIGINAL PROBLEM STATEMENT HAS BEEN UPDATED !!!
        /// 
        /// Print the element present at the given index of the given array.
        /// 
        /// Input:
        /// The first line of input is the number of test cases.
        /// For each test case
        ///     The first line contains the number of elements and an index separated by a space.
        ///     The second line contains the elements separated by a space.
        /// 
        /// Output:
        /// For each test case print the element present at the given index.
        ///
        /// (The solutions should be arranged in order to have step by step practices)
        /// </summary>
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var result = new string[t];

            for (var i = 0; i < t; i++)
            {
                var index = Console.ReadLine().Split(' ')[1];
                result[i] = Console.ReadLine().Split(' ')[int.Parse(index)];
            }

            foreach (var element in result)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}