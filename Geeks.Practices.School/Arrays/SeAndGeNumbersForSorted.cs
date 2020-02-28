using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// Given a sorted array and a value,
    ///     1) Find the number of elements that are LE that value. 
    ///     2) Find the number of elements that are GE that value.
    /// 
    /// Input:
    /// The first line is the number of test cases.
    /// For each test case there will be two lines.
    ///     The first line is the value to check. 
    ///     The second line contains the different elements from each other, separated by spaces. 
    /// 
    /// Output:
    /// For each test case
    ///     Print the number of elements LE the given value and then the number of elements GE that value.
    ///         They are separated by a space.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class SeAndGeNumbersForSorted
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var valueToCheck);
                var elements = Console.ReadLine().Split(' ');

                for (var k = 0; k < elements.Length; k++)
                {
                    int.TryParse(elements[k], out var element);

                    if (element < valueToCheck)
                    {
                        continue;
                    }

                    if (element == valueToCheck)
                    {
                        results[i] = (k + 1) + " " + (elements.Length - k);
                    }
                    else
                    {
                        results[i] = k + " " + (elements.Length - k);
                    }

                    break;
                }

                if (string.IsNullOrEmpty(results[i]))
                {
                    results[i] = elements.Length + " 0";
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