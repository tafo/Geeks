﻿using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Print K smallest elements in their original order"
    /// 
    /// Given an array, the task is to print K smallest elements from the array but they must be in the same order as they are in given array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains two Integers N and K and the second line contains N space separated elements.
    /// 
    /// Output:
    /// For each test case, print the K smallest elements in new line.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=K<=N<=10e6
    /// 1<=A[i]<=10e5
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5 2
    /// 5 4 2 1 2
    /// 7 5
    /// 1 2 3 4 5 6 7
    /// 59 15
    /// 30 8 16 14 9 9 4 22 19 10 27 5 14 14 24 9 27 11 5 29 19 19 10 28 18 7 15 4 1 24 21 30 23 6 5 1 6 30 15 17 10 3 13 15 8 28 16 5 9 12 3 19 30 4 17 9 11 23 12
    /// 
    /// Output:
    /// 2 1
    /// 1 2 3 4 5
    /// 8 4 5 5 7 4 1 6 5 1 6 3 5 3 4
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindSmallestElements
    {
        /// <summary>
        /// Time Limit Exceeded
        /// Expected Time Limit < 2.68 sec
        /// </summary>
        public static void RunAwayLoop()
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
                var split = test[0].Split();
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var scanner = new StringScanner(test[1]);
                var numbers = new int[n];
                var backup = new int[n];
                var i = 0;
                while (scanner.HasNext)
                {
                    backup[i] = numbers[i] = scanner.NextPositiveInt();
                    i++;
                }
                Array.Sort(backup);
                var result = new int[k];
                i = 0;
                for (var x = 0; x < n; x++)
                {
                    var index = Array.IndexOf(backup, numbers[x], 0, k);
                    if (index == -1) continue;
                    result[i++] = numbers[x];
                    backup[index] = 0;
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}