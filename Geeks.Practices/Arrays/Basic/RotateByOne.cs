using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Cyclically rotate an array by one"
    /// 
    /// Given an array, cyclically rotate an array by one.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow. Each test case contains an integer n denoting the size of the array.
    /// Then following line contains 'n' integers forming the array. 
    /// 
    /// Output:
    /// Output the cyclically rotated array by one.
    /// 
    /// Constraints:
    /// 1<=T<=1000
    /// 1<=N<=1000
    /// 0<=a[i]<=1000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 2 3 4 5
    /// 8
    /// 9 8 7 6 4 2 1 3
    /// 
    /// Output:
    /// 5 1 2 3 4
    /// 3 9 8 7 6 4 2 1
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class RotateByOne
    {
        /// <summary>
        /// the execution time is 0.13
        /// </summary>
        public static void RunBest()
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
                var elements = test[1].Split(' ');
                var savedElement = elements[n - 1];
                Array.Copy(elements, 0, elements, 1, n - 1);
                elements[0] = savedElement;
                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// the execution time is 0.14 (Same!)
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
                var elements = test[1].Split(' ');
                var savedElement = elements[n - 1];
                for (var i = n - 1; i > 0; i--)
                {
                    elements[i] = elements[i - 1];
                }

                elements[0] = savedElement;
                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// the execution time is 0.14
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
                var numbers = new int[n];
                var scanner = new StringScanner(test[1]);
                var i = 1;
                while (i < n)
                {
                    numbers[i++] = scanner.NextPositiveInt();
                }

                numbers[0] = scanner.NextPositiveInt();

                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}