using System;

namespace Geeks.Practices.School.Solutions
{
    /// <summary>
    /// Given an array A of size N, print second largest element from an array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T test cases follow. Each test case contains two lines of input. The first line contains an integer N denoting the size of the array.
    /// The second line contains the N space separated integers of the array.
    /// 
    /// Output:
    /// For each test case, in a new line, print the second largest element.
    /// </summary>
    public class SecondLargestElementInArray
    {
        public static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new int[t][];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                input[i] = new int[n];
                var elements = Console.ReadLine()?.Trim().Split(' ');

                for (var k = 0; k < n; k++)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    input[i][k] = int.Parse(elements[k]);
                }
            }

            foreach (var elements in input)
            {
                var max = elements[0];
                var secondLargest = 0;
                
                // ReSharper disable once LoopCanBeConvertedToQuery
                for (var i = 1; i < elements.Length; i++)
                {
                    if (elements[i] <= secondLargest) continue;

                    if (elements[i] < max)
                    {
                        secondLargest = elements[i];
                    }
                    else
                    {
                        secondLargest = max;
                        max = elements[i];
                    }
                }

                Console.WriteLine(secondLargest);
            }

            Console.ReadKey();
        }
    }
}