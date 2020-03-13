using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "k largest elements"
    /// 
    /// Given an array of N positive integers, print k largest elements from the array.
    /// The output elements should be printed in decreasing order.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// The first line of each test case is N and k, N is the size of array and K is the largest elements to be returned.
    /// The second line of each test case contains N input C[i].
    /// 
    /// Output:
    /// Print the k largest element in descending order.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 100
    /// K ≤ N
    /// 1 ≤ C[i] ≤ 1000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5 2
    /// 12 5 787 1 23
    /// 7 3
    /// 1 23 12 9 30 2 50
    /// 
    /// Output:
    /// 787 23
    /// 50 30 23
    /// 
    /// Explanation:
    /// Test case 1: 1st largest element in the array is 787 and second largest is 23.
    /// Test case 2: 3 Largest element in the array are 50, 30 and 23.
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class LargestElements
    {
        /// <summary>
        /// This execution time is 0.39 !!!
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var top = int.Parse(split[1]);
                var elements = new int[n];
                var scanner = new StringScanner(testCase[1]);
                var counter = 0;
                while (scanner.HasNext)
                {
                    elements[counter++] = scanner.NextPositiveInt();
                }
                Console.WriteLine(string.Join(' ', elements.OrderByDescending(x => x).Take(top)));
            }
        }

        /// <summary>
        /// This execution time is 0.40
        /// </summary>
        internal static void Run4()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var top = int.Parse(split[1]);
                var elements = new int[n];
                var scanner = new StringScanner(testCase[1]);
                var counter = 0;
                while (scanner.HasNext)
                {
                    elements[counter++] = scanner.NextPositiveInt();
                }
                var largestElements = elements.OrderByDescending(x => x).Take(top);
                Console.WriteLine(string.Join(' ', largestElements));
            }
        }

        /// <summary>
        /// This execution time is 0.67
        /// </summary>
        internal static void Run3()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                //var n = int.Parse(split[0]);
                var top = int.Parse(split[1]);
                var largestElements = testCase[1].Split(' ').Select(int.Parse).OrderByDescending(x => x).Take(top);
                Console.WriteLine(string.Join(' ', largestElements));
            }
        }

        /// <summary>
        /// This execution time is 0.42
        /// </summary>
        internal static void Run2()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var top = int.Parse(split[1]);
                var largestElements = new int[top];
                var elements = new int[n];
                var scanner = new StringScanner(testCase[1]);
                var counter = 0;
                while (scanner.HasNext)
                {
                    elements[counter++] = scanner.NextPositiveInt();
                }

                Array.Sort(elements, (a, b) => b.CompareTo(a));
                Array.Copy(elements, largestElements, top);

                Console.WriteLine(string.Join(' ', largestElements));
            }
        }

        /// <summary>
        /// This solution exceeded the expected time limit !!! >> More than 3 seconds
        /// </summary>
        internal static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                // var n = int.Parse(split[0]); // Skip the number of elements
                var top = int.Parse(split[1]);
                var largestElements = new int[top];
                var scanner = new StringScanner(testCase[1]);
                var counter = 0;
                while (scanner.HasNext)
                {
                    var index = 0;
                    var number = scanner.NextPositiveInt();

                    while (index < top)
                    {
                        var compare = largestElements[index];
                        if (compare == 0)
                        {
                            largestElements[index] = number;
                            if (counter < top - 1)
                            {
                                counter++;
                            }
                            break;
                        }

                        if (compare >= number)
                        {
                            index++;
                        }
                        else
                        {
                            for (var k = counter; k > index; k--)
                            {
                                largestElements[k] = largestElements[k - 1];
                            }

                            largestElements[index] = number;
                            if (counter < top - 1)
                            {
                                counter++;
                            }
                            break;
                        }
                    }
                }

                Console.WriteLine(string.Join(' ', largestElements));
            }
        }
    }
}