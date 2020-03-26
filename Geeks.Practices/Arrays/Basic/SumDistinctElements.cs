using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sum of distinct elements for a limited range"
    /// 
    /// Given an array of n elements such that every element of array is an integer in the range 1 to n,
    ///     find the sum of all the distinct elements of the array.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// First line of every test case consists of N.
    /// Second line of every test case consists of elements of Array.
    /// 
    /// Output:
    /// Single line output, print the sum of distinct element of array.
    /// 
    /// Constraints:
    /// 1<=T<=200
    /// 1<=N<=10^4
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 2 3 3 4
    /// 5
    /// 1 1 1 2 2
    /// 
    /// Output:
    /// 10
    /// 3
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SumDistinctElements
    {
        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var results = new int[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                results[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).Distinct().Sum();
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// * Better!
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
                Console.WriteLine(numbers.Distinct().Sum());
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// * !!!
        /// </summary>
        public static void RunAnotherCompareToLoop()
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
                var numbers = new int[n];
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    numbers[number - 1] = number;
                }

                var sum = 0;
                for (var i = 0; i < n; i++)
                {
                    sum += numbers[i];
                }

                Console.WriteLine(sum);
            }
        }

        /// <summary>
        /// The execution time is 0.13
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
                var scanner = new StringScanner(test[1]);
                var numbers = new bool[n + 1];
                while (scanner.HasNext)
                {
                    numbers[scanner.NextPositiveInt()] = true;
                }

                var sum = 0;
                for (var i = 1; i <= n; i++)
                {
                    if (numbers[i])
                    {
                        sum += i;
                    }
                }

                Console.WriteLine(sum);
            }
        }

        /// <summary>
        /// The execution time is 0.13
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
                var numbers = new bool[n];
                while (scanner.HasNext)
                {
                    numbers[scanner.NextPositiveInt() - 1] = true;
                }

                var sum = 0;
                for (var i = 0; i < n; i++)
                {
                    if (numbers[i])
                    {
                        sum += i + 1;
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}