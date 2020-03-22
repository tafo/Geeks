using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sur passer Count"
    /// 
    /// A sur passer of an element of an array is a greater element to its right,
    ///     therefore x[j] is a sur passer of x[i] if i < j & x[i] < x[j].
    /// The surpasser count of an element is the number of surpassers.
    ///
    /// Given an array of distinct integers, for each element of the array find its surpasser count
    ///     i.e. count the number of elements to the right that are greater than that element.
    /// 
    /// Input:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of two lines.
    /// The first line of each test case consists of an integer N, where N is the size of array.
    /// The second line of each test case contains N space separated integers denoting array elements.
    /// 
    /// Output:
    /// Corresponding to each test case, in a new line, print the surpasser count
    ///     i.e. count the number of elements to the right that are greater than that element.
    /// 
    /// Constraints:
    /// 
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 500
    /// 1 ≤ A[i] ≤ 1000
    /// 
    /// Example:
    /// 
    /// Input
    /// 3
    /// 5
    /// 4 5 1 2 3
    /// 4
    /// 946 782 505 393 
    /// 24
    /// 292 167 262 982 942 462 444 246 697 230 374 901 651 704 829 732 942 524 943 711 389 14 789 480
    /// 
    /// Output
    /// 1 0 2 1 0
    /// 0 0 0 0
    /// 18 21 18 0 1 12 12 14 8 13 12 2 7 6 2 3 1 3 0 1 2 2 0 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SurPasserCount
    {
        /// <summary>
        /// The execution time is 0.30
        /// </summary>
        public static void RunCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(string.Join(' ', test.Select((x, i) => test.Skip(i + 1).Count(y => y > x))));
            }
        }

        /// <summary>
        /// The execution time is 1.22
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ');
            }

            foreach (var test in tests)
            {
                Console.WriteLine(string.Join(' ', test.Select((x, i) => test.Skip(i + 1).Count(y => int.Parse(y) > int.Parse(x)))));
            }
        }

        /// <summary>
        /// The execution time is 0.32
        /// </summary>
        public static void RunLinq()
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
                var numbers = test.Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine(string.Join(' ', numbers.Select((x, i) => numbers.Skip(i + 1).Count(y => y > x))));
            }
        }

        /// <summary>
        /// The execution time is 0.22
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
                Console.WriteLine(string.Join(' ', numbers.Select((x, i) => numbers.Skip(i + 1).Count(y => y > x))));
            }
        }

        /// <summary>
        /// The execution time is 0.15
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
                var scanner = new StringScanner(test[1]);
                var i = 0;
                var result = new int[n];
                var numbers = new int[n];

                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    for (var k = 0; k < i; k++)
                    {
                        if (number < numbers[i])
                        {
                            result[i]++;
                        }
                    }

                    i++;
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}