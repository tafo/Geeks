using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Rearrange the array"
    /// 
    /// Given an array of integers, task is to print the array in the order
    ///     smallest number, Largest number, 2nd smallest number, 2nd largest number, 3rd smallest number, 3rd largest number and so on.
    /// 
    /// Input:
    /// The first line consists of an integer T i.e number of test cases.
    /// The first line of each test case consists of an integer N.
    /// The next line consists of N spaced integers. 
    /// 
    /// Output:
    /// Print the required answer.
    /// 
    /// Constraints: 
    /// 1<=T<=100
    /// 1<=N,a[i]<=1000
    /// 
    /// Example:
    /// 
    /// Input:
    /// 6
    /// 9
    /// 1 9 2 8 3 7 4 6 5
    /// 4
    /// 1 2 3 4 
    /// 6
    /// 1 2 3 4 5 6
    /// 5
    /// 1 2 3 4 5
    /// 18
    /// 935 200 141 771 73 328 452 197 883 611 495 99 393 583 954 54 803 848 
    /// 1
    /// 617
    /// 
    /// Output:
    /// 1 9 2 8 3 7 4 6 5
    /// 1 4 2 3
    /// 1 6 2 5 3 4
    /// 1 5 2 4 3
    /// 54 954 73 935 99 883 141 848 197 803 200 771 328 611 393 583 452 495
    /// 617
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SortAndInterleaveTwoEnds
    {
        /// <summary>
        /// The execution time is 0.67
        /// * Of course, using index is better than using Skip, First, SkipLast, Last, etc.
        /// </summary>
        public static void RunCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();;
            }

            foreach (var test in tests)
            {
                Console.WriteLine(string.Join(' ',
                    Enumerable.Range(0, test.Length).Select(i => (i & 1) == 0 ? test.Skip(i / 2).First() : test.SkipLast(i / 2).Last())));
            }
        }

        /// <summary>
        /// The execution time is 0.18
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();;
            }

            foreach (var test in tests)
            {
                Console.WriteLine(string.Join(' ', Enumerable.Range(1, test.Length).Select(i => (i & 1) == 1 ? test[i / 2] : test[^(i / 2)])));
            }
        }

        /// <summary>
        /// The execution time is 0.19
        /// </summary>
        public static void RunLinq()
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
                var numbers = test[1].Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
                var result = Enumerable.Range(0, n).Select(i => (i & 1) == 0 ? numbers[i / 2] : numbers[n - i / 2 - 1]);
                Console.WriteLine(string.Join(' ', result));
            }
        }

        /// <summary>
        /// The execution time is 0.11
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
                Array.Sort(numbers);
                var result = Enumerable.Range(0, n).Select(i => (i & 1) == 0 ? numbers[i / 2] : numbers[n - i / 2 - 1]);
                Console.WriteLine(string.Join(' ', result));
            }
        }

        /// <summary>
        /// The execution time is 0.10
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var result = new int[n];
                var half = n / 2;
                var k = 0;
                for (var i = 0; i < half; i++)
                {
                    result[k++] = numbers[i];
                    result[k++] = numbers[n - i - 1];
                }

                result[k] = numbers[half];

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}