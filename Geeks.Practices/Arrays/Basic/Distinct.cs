using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Remove Duplicates from unsorted array"
    /// 
    /// Given an array of integers which may or may not contain duplicate elements.
    /// Your task is to print the array after removing duplicate elements, if present.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains an integer n denoting the size of the array.
    /// Then following line contains 'n' integers forming the array.
    /// 
    /// Output:
    /// Output the array with no duplicate element present, in the same order as input.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=100
    /// 1<=a[i]<=100
    /// 
    /// Example:
    /// Input:
    /// 1
    /// 6
    /// 1 2 3 1 4 2
    /// Output:
    /// 1 2 3 4
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Distinct
    {
        /// <summary>
        /// The execution time is 0.08 !!!
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
                Console.WriteLine(new StringBuilder().AppendJoin(' ', test.Split(' ').Distinct()).ToString());
            }
        }

        /// <summary>
        /// The execution time is 0.13-0.14
        /// * Check different types of appending operations
        /// </summary>
        public static void RunAnotherCompareToTest()
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
                var resultBuilder = new StringBuilder(n);
                resultBuilder.Append($"{numbers[0]} ");
                for (var i = 1; i < n; i++)
                {
                    var exists = false;
                    for (var k = 0; k < i; k++)
                    {
                        if (numbers[i] == numbers[k])
                        {
                            exists = true;
                        }
                    }

                    if (!exists)
                    {
                        resultBuilder.Append($"{numbers[i]} ");
                    }
                }

                Console.WriteLine(resultBuilder.ToString());
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunCompareToTest()
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
                var resultBuilder = new StringBuilder(n);
                resultBuilder.AppendFormat("{0} ", numbers[0]);
                for (var i = 1; i < n; i++)
                {
                    var exists = false;
                    for (var k = 0; k < i; k++)
                    {
                        if (numbers[i] == numbers[k])
                        {
                            exists = true;
                        }
                    }

                    if (!exists)
                    {
                        resultBuilder.AppendFormat("{0} ", numbers[i]);
                    }
                }

                Console.WriteLine(resultBuilder.ToString());
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunTest()
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
                var resultBuilder = new StringBuilder(n);
                resultBuilder.Append(numbers[0] + " ");
                for (var i = 1; i < n; i++)
                {
                    var exists = false;
                    for (var k = 0; k < i; k++)
                    {
                        if (numbers[i] == numbers[k])
                        {
                            exists = true;
                        }
                    }

                    if (!exists)
                    {
                        resultBuilder.Append(numbers[i] + " ");
                    }
                }

                Console.WriteLine(resultBuilder.ToString());
            }
        }

        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void RunCompareTo()
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
                var resultBuilder = new StringBuilder(n);
                resultBuilder.Append(numbers[0]);
                resultBuilder.Append(" ");
                for (var i = 1; i < n; i++)
                {
                    var exists = false;
                    for (var k = 0; k < i; k++)
                    {
                        if (numbers[i] == numbers[k])
                        {
                            exists = true;
                        }
                    }

                    if (!exists)
                    {
                        resultBuilder.Append(numbers[i]);
                        resultBuilder.Append(" ");
                    }
                }

                Console.WriteLine(resultBuilder.ToString());
            }
        }

        /// <summary>
        /// The execution time is 0.12
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var counter = 1;
                for (var i = 1; i < n; i++)
                {
                    var exists = false;
                    for (var k = 0; k < i; k++)
                    {
                        if (numbers[i] == numbers[k])
                        {
                            exists = true;
                        }
                    }

                    if (!exists)
                    {
                        numbers[counter++] = numbers[i];
                    }
                }

                var result = new int[counter];
                Array.Copy(numbers, 0, result, 0, counter);
                Console.WriteLine(new StringBuilder(counter).AppendJoin(' ', result).ToString());
            }
        }
    }
}