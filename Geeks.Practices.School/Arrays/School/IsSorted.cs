using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays.School
{
    /// <summary>
    /// ToDo : Fix the original problem statement
    /// (The original title of the problem is "Check if an array is sorted")
    /// 
    /// Given an array C[], write a program that prints 1 if array is sorted in non-decreasing order, else prints 0.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// For each test case there will be two lines.
    ///     First line contains the size of the array N.
    ///     Second line contains N space separated integers of the array C[i].
    /// 
    /// Output:
    /// Print 1 if array is sorted, else print 0.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class IsSorted
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new int[t];

            for (var i = 0; i < t; i++)
            {
                Console.ReadLine(); // Skip the number of elements. 
                var elements = Console.ReadLine().Split(' ');
                int.TryParse(elements[0], out var left);
                results[i] = 1;
                for (var k = 1; k < elements.Length; k++)
                {
                    int.TryParse(elements[k], out var right);
                    if (right >= left)
                    {
                        left = right;
                    }
                    else
                    {
                        results[i] = 0;
                        break;
                    }
                }
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}