﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimum product pair"
    /// 
    /// Given an array of positive integers.
    /// The task is to print the minimum product of any two numbers of the given array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains a integer N and the second line contains N space separated array elements.
    /// 
    /// Output:
    /// For each test case, print the minimum product of two numbers in new line.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 2<=N<=10e5
    /// 1<=A[i]<=10e5
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 4
    /// 2 7 3 4
    /// 4
    /// 5 3 6 4
    /// 2 2
    /// Output:
    /// 6
    /// 12
    /// 4
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class MinPairProduct
    {
        /// <summary>
        /// The execution time is 0.29
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Split(' ').Select(int.Parse).OrderBy(x => x).Take(2).Aggregate(1L, (x, y) => x * y));
            }
        }

        /// <summary>
        /// The execution time is 0.12
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
                Console.WriteLine(numbers.OrderBy(x => x).Take(2).Aggregate(1L, (x, y) => x * y));
            }
        }

        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunCompareToLoop()
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
                Console.WriteLine((long)numbers[0] * numbers[1]);
            }
        }

        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunLoop()
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
                // var n = int.Parse(test[0]); Skip the number of elements
                var scanner = new StringScanner(test[1]);
                var min = int.MaxValue;
                var second = min - 1;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number >= second) continue;
                    if (number < min)
                    {
                        second = min;
                        min = number;
                    }
                    else
                    {
                        second = number;
                    }
                }

                Console.WriteLine((long)second * min);
            }
        }
    }
}