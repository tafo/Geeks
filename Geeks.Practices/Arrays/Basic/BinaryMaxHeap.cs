﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Does array represent Heap"
    /// 
    /// Given an array A of size N, the task is to check if the given array represents a Binary Max Heap.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains two lines.
    /// The first line of input contains an integer N denoting the size of the array.
    /// Then in the next line are N space separated array elements.
    /// 
    /// Output:
    /// If array represents a Binary Max Heap, print "1", else print "0" (without quotes).
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= Ai <= 10e15
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 6
    /// 90 15 10 7 12 2
    /// 6
    /// 9 15 10 7 12 11
    /// 18
    /// 94 57 12 43 30 74 22 20 85 38 99 25 16 71 14 27 92 81 
    /// 7
    /// 74 63 71 97 82 6 26
    /// Output:
    /// 1
    /// 0
    /// 0
    /// 0
    /// 
    /// Explanation:
    /// Testcase 1: Array of first elements represents Binary Max Heap, so output is 1.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class BinaryMaxHeap
    {
        /// <summary>
        /// The execution time is 0.23
        /// </summary>
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
                var numbers = new long[n];
                var scanner = new StringScanner(test[1]);
                var i = 0;
                numbers[i++] = scanner.NextPositiveLong();
                var result = "1";
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveLong();
                    if (number < numbers[(i - 1) / 2])
                    {
                        numbers[i++] = number;
                    }
                    else
                    {
                        result = "0";
                        break;
                    }
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.79
        /// </summary>
        public static void RunSingleLine()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new long[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(long.Parse).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Where((x, i) => test[(i - 1) / 2] < x).Any() ? "0" : "1");
            }
        }

        /// <summary>
        /// The execution time is 0.31
        /// </summary>
        public static void RunThis()
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
                var numbers = StringScanner.GetPositiveLong(test[1], n);
                var result = "1";
                for (var i = 1; i < n; i++)
                {
                    if (numbers[(i - 1) / 2] >= numbers[i]) continue;
                    result = "0";
                    break;
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.32
        /// </summary>
        public static void RunAnother()
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
                var numbers = StringScanner.GetPositiveLong(test[1], n);
                var level = (int)Math.Log(n, 2);
                var k = Math.Pow(2, level) - 1;
                var result = "1";
                for (var i = 0; i < k; i++)
                {
                    var leftChildIndex = 2 * i + 1;
                    if (leftChildIndex < n)
                    {
                        if (numbers[i] < numbers[leftChildIndex])
                        {
                            result = "0";
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                    if (++leftChildIndex < n)
                    {
                        if (numbers[i] >= numbers[leftChildIndex]) continue;
                        result = "0";
                    }

                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}