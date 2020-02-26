using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Solutions
{
    /// <summary>
    /// Given an array A[ ], find maximum and minimum elements from the array.
    /// 
    /// Input:
    /// The first line of input contains an integer T, denoting the number of test cases.
    /// The description of T test cases follows.
    /// The first line of each test case contains a single integer N denoting the size of array.
    /// The second line contains N space-separated integers A1, A2, ..., AN denoting the elements of the array.
    /// 
    /// Output:
    /// For each test case in a new line, print the maximum and minimum elements in a single line with space in between.
    ///
    /// Anyway!!! At least I practiced somewhat keyboard and English.
    /// 
    /// </summary>
    public class MaxAndMinElementsInArray
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new int[t][];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                input[i] = new int[n];
                var elements = Console.ReadLine().Trim().Split(' ');
                for (var k = 0; k < elements.Length; k++)
                {
                    input[i][k] = int.Parse(elements[k]);
                }
            }

            foreach (var elements in input)
            {
                var max = elements[0];
                var min = elements[0];

                for (var index = 1; index < elements.Length; index++)
                {
                    var element = elements[index];
                    if (element > max)
                    {
                        max = element;
                    }
                    else if (element < min)
                    {
                        min = element;
                    }
                }

                Console.WriteLine("{0} {1}", max, min);
            }

            Console.ReadKey();
        }
    }
}