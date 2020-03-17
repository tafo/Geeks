using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Positive and negative elements"
    /// 
    /// Given an array containing equal number of positive and negative elements,
    ///     arrange the array such that every positive element is followed by a negative element.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains an Integer N denoting size of array and the second line contains N space separated elements.
    /// 
    /// Output:
    /// For each test case, in a new line print the arranged array.
    /// 
    /// Constraints:
    /// 1 <= T <= 300
    /// 2 <= N <= 10e5
    /// -10e5 <= A[i] <= 10e5
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 6
    /// -1 2 -3 4 -5 6
    /// 4
    /// -3 2 -4 1
    /// 2
    /// -70 320 
    /// 20
    /// -6 -56 -796 -535 -257 -25 -745 -243 -270 -286 651 685 792 860 638 650 347 426 470 157
    /// Output:
    /// 2 -1 4 -3 6 -5
    /// 2 -3 1 -4
    /// 320 -70
    /// 651 -6 685 -56 792 -796 860 -535 638 -257 650 -25 347 -745 426 -243 470 -270 157 -286
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class PositiveAndNegative
    {
        /// <summary>
        /// The execution time is 0.59
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                tests[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var numbers = test.Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine(string.Join(' ', numbers.Where(x => x >= 0).Interleave(numbers.Where(x => x < 0))));
            }
        }

        /// <summary>
        /// The execution time is 0.51
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
                var numbers = new int[n];
                var scanner = new StringScanner(test[1]);
                var evenIndex = 0;
                var oddIndex = 1;
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt();
                    if (number < 0)
                    {
                        numbers[oddIndex += 2] = number;
                    }
                    else
                    {
                        numbers[evenIndex += 2] = number;
                    }
                }

                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}