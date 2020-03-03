using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The original title of the problem is "Majority Element"
    ///
    /// Given an array A of N elements. Find the majority element in the array.
    ///     A majority element in an array A of size N is an element that appears more than N/2 times in the array.
    /// 
    /// Input >>
    /// The first line of the input contains T denoting the number of test cases.
    ///     The first line of the test case will be the size of array and second line will be the elements of the array.
    /// 
    /// Output >>
    /// For each test case the output will be the majority element of the array. Output "-1" if no majority element is there in the array.
    ///
    /// Remarks >>
    /// The solutions are based on "Boyer-Moore Majority Vote Algorithm". 
    ///     Check >> https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
    /// </summary>
    [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
    [SuppressMessage("ReSharper", "ForCanBeConvertedToForeach")]
    internal class MajorityElement
    {
        /// <summary>
        /// The execution time of this solution is 0.18
        /// </summary>
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine(); // The number of elements
                input[i][1] = Console.ReadLine(); // The elements
            }

            foreach (var testCase in input)
            {
                var testCounter = 0;
                var majorityElement = -1;
                int.TryParse(testCase[0], out var length);
                var elements = new int[length];
                var elementIndex = 0;
                var scanner = new StringScanner(testCase[1]);
                while (scanner.HasNext)
                {
                    var n = elements[elementIndex++] = scanner.NextInt();
                    if (testCounter == 0)
                    {
                        majorityElement = n;
                        testCounter = 1;
                    }
                    else if (majorityElement == n)
                    {
                        testCounter++;
                    }
                    else
                    {
                        testCounter--;
                    }
                }

                if (testCounter > 0)
                {
                    var actualCounter = 0;
                    for (var i = 0; i < elements.Length; i++)
                    {
                        // ToDo : Check counter and i to break the loop
                        if (majorityElement == elements[i])
                        {
                            actualCounter++;
                        }
                    }

                    if (actualCounter * 2 > length)
                    {
                        Console.WriteLine(majorityElement);
                    }
                    else
                    {
                        Console.WriteLine("-1");
                    }
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }
        }
        
        /// <summary>
        /// The execution time of this solution is 0.19
        /// </summary>
        internal static void Run2()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine(); // The number of elements
                input[i][1] = Console.ReadLine(); // The elements
            }

            foreach (var testCase in input)
            {
                var c = 0;
                var m = -1;
                int.TryParse(testCase[0], out var length);
                var scanner = new StringScanner(testCase[1]);
                while (scanner.HasNext)
                {
                    var n = scanner.NextInt();
                    if (c == 0)
                    {
                        m = n;
                        c = 1;
                    }
                    else if (m == n)
                    {
                        c++;
                    }
                    else
                    {
                        c--;
                    }
                }

                if (c > 0)
                {
                    var counter = 0;
                    scanner.Reset();
                    while (scanner.HasNext)
                    {
                        if (m == scanner.NextInt())
                        {
                            counter++;
                        }

                        // ToDo : Check counter and scanner.Position to break the loop
                    }

                    if (counter * 2 > length)
                    {
                        Console.WriteLine(m);
                    }
                    else
                    {
                        Console.WriteLine("-1");
                    }
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }
        }
    }
}