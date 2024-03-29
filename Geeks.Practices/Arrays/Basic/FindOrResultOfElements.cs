﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Play With OR"
    /// 
    /// You are given an array A[] , you have to construct a new array A2[].
    /// The values in A2[] are obtained by doing OR of consecutive elements in array.
    /// 
    /// Input:
    /// First line of the input contains t, the number of test cases.
    /// Each line of the test case contains a number n specifying the number of elements.
    /// Each 'n' lines denoting elements of array A[].
    /// 
    /// Output:
    /// Each new line of the output contains element of array A2[].
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=100000
    /// 1<=A[i]<=100000
    /// 
    /// 
    /// 
    /// Example:
    /// 
    /// Input:
    /// 3
    /// 5
    /// 10 11 1 2 3
    /// 6
    /// 9040 8942 9264 2648 7446 3805 
    /// 16
    /// 8935 7451 600 5249 6519 1556 2798 303 6224 1008 5844 2609 4989 2702 3195 485
    /// 
    /// Output:
    /// 11 11 3 3 3
    /// 9214 9982 11896 8030 8159 3805
    /// 16383 8027 5849 7671 8055 3838 3055 6527 7152 6132 7925 7037 7167 3839 3583 485
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindOrResultOfElements
    {
        /// <summary>
        /// The execution time is 0.18
        /// </summary>
        public static void RunSingleLineLinq()
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
                var numbers = test[1].Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine(string.Join(' ', numbers.Skip(1).Select((x, i) => x | numbers[i]).Append(numbers[n - 1])));
            }
        }

        /// <summary>
        /// The execution time is 0.14
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
                Console.WriteLine(string.Join(' ', numbers.Skip(1).Select((x, i) => x | numbers[i]).Append(numbers[n - 1])));
            }
        }

        /// <summary>
        /// The execution time is 0.14
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
                var n = int.Parse(test[0]);
                var scanner = new StringScanner(test[1]);
                var left = scanner.NextPositiveInt();
                var result = new int[n];
                var i = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    result[i++] = left | number;
                    left = number;
                }

                result[i] = left;

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}