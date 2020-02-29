using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.School
{
    /// <summary>
    /// Given an array of size N, swap the kth element from beginning with kth element from end.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains 2 lines of input
    /// The first line contains two integers (N and K) separated with a space,
    ///     where N is the size of the array and K is the order number of the element that will be swapped.
    /// The second line contains N integers(the elements of the array) separated with spaces.
    /// 
    /// Output:
    /// For each test case, print the modified array.
    /// </summary>
    internal class SwapElements
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new int[t][][];
            for (var i = 0; i < t; i++)
            {
                input[i] = new int[2][];
                var line = Console.ReadLine().Split(' ');
                var n = int.Parse(line[0]);
                input[i][0] = new[] { int.Parse(line[1]) };
                input[i][1] = new int[n];

                var elements = Console.ReadLine().Split(' ');
                for (var k = 0; k < n; k++)
                {
                    input[i][1][k] = int.Parse(elements[k]);
                }
            }

            foreach (var data in input)
            {
                var elements = data[1];
                var leftIndex = data[0][0] - 1; //  Index = OrderNumber - 1
                var rightIndex = elements.Length - leftIndex - 1;
                var backup = elements[leftIndex];
                elements[leftIndex] = elements[rightIndex];
                elements[rightIndex] = backup;
                foreach (var element in elements)
                {
                    Console.Write("{0} ", element);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}