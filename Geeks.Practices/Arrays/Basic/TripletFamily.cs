using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Triplet Family"
    /// 
    /// Given an array A of integers.
    /// Find three numbers such that sum of two elements equals the third element and return the triplet in a container result
    /// If no such triplet is found return the container as empty.
    /// 
    /// Input:
    /// First line of input contains number of test cases.
    /// For each test cases there will two lines.
    /// First line contains size of array and next line contains array elements.
    /// 
    /// Output:
    /// For each test case output the triplets, if any triplet found from the array, if no such triplet is found, output -1.
    /// 
    /// Your Task: Your task is to complete the function to find triplet and return container containing result.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e3
    /// 0 <= Ai <= 10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 5
    /// 5
    /// 1 2 3 4 5
    /// 3
    /// 3 3 3
    /// 6
    /// 8 10 16 6 15 25
    /// 21
    /// 325 114 397 428 748 126 197 315 618 133 85 888 357 795 796 938 87 170 401 518 820 
    /// 25
    /// 394 846 216 41 211 891 103 714 233 147 547 630 293 295 474 489 609 811 340 412 699 696 208 495 353
    /// 
    /// Output:
    /// 1
    /// -1
    /// 1
    /// -1
    /// 1
    /// 
    /// Explanation:
    /// Testcase 1:
    /// Triplet Formed: {2, 1, 3}
    /// Hence 1 
    ///
    /// Test Case 2:
    /// Triplet Formed: {}
    /// Hence -1
    ///
    /// Test Case 3:
    /// Triplet Formed: {10, 15, 25}
    /// Hence 1
    ///
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class TripletFamily
    {
        /// <summary>
        /// The execution time of the equivalent JAVA solution is 0.45
        /// :P >>> Because, this is brute force. 
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test
                    .SelectMany(a => test.Except(new[] { a }), (a, b) => new { a, b })
                    .SelectMany(x => test.Except(new[] { x.a, x.b }), (x, c) => new { x.a, x.b, c })
                    .Any(x => x.a + x.b == x.c)
                    ? 1
                    : -1);
            }
        }

        /// <summary>
        /// The execution time of the equivalent JAVA solution is 0.45
        /// :P
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers, (a, b) => b.CompareTo(a));
                Console.WriteLine(numbers
                    .SelectMany(a => numbers.Except(new[] { a }), (a, b) => new { a, b })
                    .SelectMany(x => numbers.Except(new[] { x.a, x.b }), (x, c) => new { x.a, x.b, c }).Any(x => x.a + x.b == x.c)
                    ? 1
                    : -1);
            }
        }

        /// <summary>
        /// The execution time of the equivalent JAVA solution is 0.45
        /// </summary>
        public static void RunEquivalent()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);

                // The structure of below code is given by GfG
                var triplet = FindTriplet(numbers, n);
                if (triplet.Count != 3)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    triplet.Sort();
                    Console.WriteLine(triplet[0] + triplet[1] == triplet[2] ? 1 : 0);
                }
            }
        }

        /// <summary>
        /// The signature of this method is given by GfG
        /// </summary>
        public static List<int> FindTriplet(int[] arr, int n)
        {
            var result = new List<int>();
            Array.Sort(arr);

            var c = n - 1;
            while (c > 1)
            {
                var b = c - 1;
                var a = 0;
                while (a < b)
                {
                    var sum = arr[a] + arr[b];
                    if (sum < arr[c])
                    {
                        a++;
                    }
                    else if (sum > arr[c])
                    {
                        b--;
                    }
                    else
                    {
                        result.Add(arr[a]);
                        result.Add(arr[b]);
                        result.Add(arr[c]);
                        c = 2;
                        break;
                    }
                }
                c--;
            }

            return result;
        }

        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);

                var isQualified = false;
                var c = n - 1;
                while (c > 1)
                {
                    var b = c - 1;
                    var a = 0;
                    while (a < b)
                    {
                        var sum = numbers[a] + numbers[b];
                        if (sum < numbers[c])
                        {
                            a++;
                        }
                        else if (sum > numbers[c])
                        {
                            b--;
                        }
                        else
                        {
                            isQualified = true;
                            c = 2;
                            break;
                        }
                    }
                    c--;
                }

                Console.WriteLine(isQualified ? 1 : -1);
            }
        }
    }
}