using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The original title of the problem is "Rotate Array"
    /// 
    /// Given an unsorted array arr[] of size N, rotate it by D elements (clockwise). 
    /// 
    /// Input:
    /// The first line of the input contains T denoting the number of test cases.
    /// First line of each test case contains two space separated elements,
    ///     N denoting the size of the array and an integer D denoting the number size of the rotation.
    /// Subsequent line will be the N space separated array elements.
    /// 
    /// Output:
    /// For each test case, in a new line, output the rotated array.
    ///
    /// Explanation :
    /// 1 2 3 4 5  when rotated by 2 elements, it becomes 3 4 5 1 2.
    ///
    /// ToDo : Implement another solution that iterates every character one by one. This will be a better one. 
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "UseIndexFromEndExpression")]
    internal class Rotate
    {
        /// <summary>
        /// This is accepted as the correct solution. 
        /// </summary>
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t][];

            for (var i = 0; i < t; i++)
            {
                results[i] = new string[2];
                results[i][0] = Console.ReadLine();
                results[i][1] = Console.ReadLine();
            }

            foreach (var result in results)
            {
                var firstLine = result[0].Split(' ');
                int.TryParse(firstLine[0], out var n);
                int.TryParse(firstLine[1], out var r);
                var elements = result[1].Split(' ');
                for (var k = r; k < n; k++)
                {
                    Console.Write("{0} ", elements[k]);
                }
                for (var k = 0; k < r - 1; k++)
                {
                    Console.Write("{0} ", elements[k]);
                }

                Console.WriteLine(elements[r - 1]);
            }
        }

        internal static void Run2()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t][];

            for (var i = 0; i < t; i++)
            {
                var firstLine = Console.ReadLine().Split(' ');
                int.TryParse(firstLine[0], out var n);
                int.TryParse(firstLine[1], out var r);
                results[i] = new string[n];
                var elements = Console.ReadLine().Split(' ');

                var index = 0;
                for (var k = r; k < n; k++)
                {
                    results[i][index++] = elements[k];
                }
                for (var k = 0; k < r; k++)
                {
                    results[i][index++] = elements[k];
                }
            }

            foreach (var result in results)
            {
                for (var i = 0; i < result.Length - 1; i++)
                {
                    Console.Write("{0} ", result[i]);
                }
                Console.WriteLine(result[result.Length - 1]);
            }
        }

        internal static void Run3()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            for (var i = 0; i < t; i++)
            {
                var firstLine = Console.ReadLine().TrimEnd().Split(' ');
                int.TryParse(firstLine[0], out var n);
                int.TryParse(firstLine[1], out var r);

                var elements = Console.ReadLine().TrimEnd().Split(' ');

                for (var k = 0; k < n - 1; k++)
                {
                    results[i] += $"{elements[(r + k) % n]} ";
                }
                results[i] += elements[r - 1];
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}