using System;
using System.Diagnostics;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// ToDo : Fix the original problem statement. 
    ///
    /// (The original title of the problem is "Print Elements of Array")
    /// 
    /// Given an array, print all its elements. 
    /// 
    /// Input:
    /// The first line of the input contains T denoting the total number of test cases.
    ///     The first line of each test case contains N denoting the size of array.
    ///     The second line contains N space separated positive integers denoting the elements of array.
    ///  
    /// Output:
    /// For each test case, print all its element in new line.
    ///
    /// Actually, I should create an array for the elements :)
    /// </summary>
    internal class PrintElements
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            for (var i = 0; i < t; i++)
            {
                Console.ReadLine(); // Skip the number of elements. 
                results[i] = Console.ReadLine(); // :)
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}