using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Count possible triangles"
    /// 
    /// Given an unsorted array of positive integers.
    /// Find the number of triangles that can be formed with three different array elements as lengths of three sides of triangles. 
    /// 
    /// Input: 
    /// The first line of the input contains T denoting the number of test cases.
    /// First line of test case is the length of array N and second line of test case are its elements.
    /// 
    /// Output:
    /// Number of possible triangles are displayed to the user.
    /// 
    /// Constraints:
    /// 1 <= T <= 200
    /// 3 <= N <= 10e7
    /// 1 <= arr[i] <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 3
    /// 3 5 4
    /// 5
    /// 6 4 9 7 8
    /// 86
    /// 887 778 916 794 336 387 493 650 422 363 28 691 60 764 927 541 427 173 737 212 369 568 430 783 531 863 124 68 136 930 803 23 59 70 168 394 457 12 43 230 374 422 920 785 538 199 325 316 371 414 527 92 981 957 874 863 171 997 282 306 926 85 328 337 506 847 730 314 858 125 896 583 546 815 368 435 365 44 751 88 809 277 179 789 585 404
    /// 
    /// Output:
    /// 1
    /// 10
    /// 45883
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class PossibleTriangles
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = new int[n];
                var scanner = new StringScanner(testCase[1]);
                var index = 0;
                while (scanner.HasNext)
                {
                    elements[index++] = scanner.NextUInt();
                }

                Array.Sort(elements);

                long counter = 0;
                var c = n - 1;
                while (c > 1)
                {
                    var b = c - 1;
                    var a = 0;
                    while (a < b)
                    {
                        if (elements[a] + elements[b] > elements[c])
                        {
                            counter = counter + b - a;
                            b--;
                        }
                        else
                        {
                            a++;
                        }
                    }

                    c--;
                }
                Console.WriteLine(counter);
            }
        }

        /// <summary>
        /// Brute Force
        /// </summary>
        public static void RunAway()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = new int[n];
                var scanner = new StringScanner(testCase[1]);
                var index = 0;
                while (scanner.HasNext)
                {
                    elements[index++] = scanner.NextUInt();
                }

                var counter = 0;
                for (var a = 0; a < n - 2; a++)
                {
                    for (var b = a + 1; b < n - 1; b++)
                    {
                        for (var c = b + 1; c < n; c++)
                        {
                            if (
                                elements[a] + elements[b] > elements[c] && 
                                elements[a] + elements[c] > elements[b] &&
                                elements[b] + elements[c] > elements[a])
                            {
                                counter++;
                            }
                        }
                    }
                }

                Console.WriteLine(counter);
            }
        }
    }
}