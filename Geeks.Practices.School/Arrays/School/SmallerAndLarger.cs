using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays.School
{
    /// <summary>
    /// !!! THE ORIGINAL PROBLEM STATEMENT HAS BEEN UPDATED !!!
    /// (The original title of the problem is "Smaller and Larger")
    ///
    /// Find the number of elements that are less than or equal to the given number
    ///     and also find the number of elements that are greater than or equal to that number.
    /// 
    /// Input:
    /// The first line is the number of test cases.
    /// For each test case there will be two lines.
    /// The first line contains the size of the array and a value to check. They are separated by a space.
    /// The second line contains the elements that are separated by spaces. 
    /// 
    /// Output:
    /// For each test case
    ///     Print the number of elements less than or equal to the given number and then the number of elements greater than or equal to that number.
    ///         They are separated by a space.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class SmallerAndLarger
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var result = new int[t][];

            for (var i = 0; i < t; i++)
            {
                result[i] = new int[2];
                int.TryParse(Console.ReadLine().Split(' ')[1], out var valueToCheck);
                var elements = Console.ReadLine().Split(' ');

                foreach (var e in elements)
                {
                    int.TryParse(e, out var element);
                    if (element < valueToCheck)
                    {
                        result[i][0]++;
                    }
                    else if (element > valueToCheck)
                    {
                        result[i][1]++;
                    }
                    else
                    {
                        result[i][0]++;
                        result[i][1]++;
                    }
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