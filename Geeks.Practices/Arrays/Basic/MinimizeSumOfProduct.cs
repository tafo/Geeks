using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimize the sum of product"
    /// 
    /// You are given two arrays, A and B, of equal size N.
    /// The task is to find the minimum value of A[0] * B[0] + A[1] * B[1] +…+ A[N-1] * B[N-1],
    ///     where shuffling of elements of arrays A and B is allowed.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the no of test cases.
    /// Then T test cases follow. Each test case contains three lines.
    /// The first line contains an integer N denoting the size of the arrays.
    /// In the second line are N space separated values of the array A[], and in the last line are N space separated values of the array B[].
    /// 
    /// Output:
    /// For each test case, print the minimum sum.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= A[] <= 10e18
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 3 
    /// 3 1 1
    /// 6 5 4
    /// 5
    /// 6 1 9 5 4
    /// 3 4 8 2 4
    /// 4
    /// 7 18 16 14 
    /// 16 7 13 10
    /// 2
    /// 3 8 
    /// 11 20
    /// Output:
    /// 23 
    /// 80
    /// 580
    /// 148
    /// 
    /// Explanation:
    /// For testcase1: 1*6+1*5+3*4 = 6+5+12 = 23 is the minimum sum
    /// For testcase2: 2*9+3*6+4*5+4*4+8*1 =18+18+20+16+8 = 80 is the minimum sum
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinimizeSumOfProduct
    {
        /// <summary>
        /// The execution time is 1.18
        /// * Compare this with Run6
        /// * We have got better performance by declaring the collections
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                Console.ReadLine(); // Skip the number of elements
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var left = test[0].Split(' ').Select(long.Parse).OrderBy(x => x);
                var right = test[1].Split(' ').Select(long.Parse).OrderByDescending(x => x);
                Console.WriteLine(left.Zip(right, (a, b) => a * b).Sum());
            }
        }

        /// <summary>
        /// The execution time is 1.23
        /// * Single line solution
        /// </summary>
        public static void Run6()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                Console.ReadLine(); // Skip the number of elements
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test[0].Split(' ').Select(long.Parse).OrderBy(x => x)
                    .Zip(test[1].Split(' ').Select(long.Parse).OrderByDescending(x => x), (a, b) => a * b).Sum());
            }
        }

        /// <summary>
        /// The execution time is 0.52
        /// * Using Zip
        /// </summary>
        public static void Run5()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
                tests[i][2] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var leftNumbers = new StringScanner(test[1]).GetAllPositiveInt64(n).OrderBy(x => x);
                var rightNumbers = new StringScanner(test[2]).GetAllPositiveInt64(n).OrderByDescending(x => x).ToArray();
                Console.WriteLine(leftNumbers.Zip(rightNumbers, (a, b) => a * b).Sum());
            }
        }

        /// <summary>
        /// The execution time is 0.47
        /// * The best solution in this class!!!
        /// </summary>
        public static void Run4()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
                tests[i][2] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var leftNumbers = new StringScanner(test[1]).GetAllPositiveInt64(n);
                var rightNumbers = new StringScanner(test[2]).GetAllPositiveInt64(n);
                Array.Sort(leftNumbers);
                Array.Sort(rightNumbers, (a, b) => b.CompareTo(a));
                long sum = 0;
                for (var i = 0; i < n; i++)
                {
                    sum += leftNumbers[i] * rightNumbers[i];
                }
                Console.WriteLine(sum);
            }
        }

        /// <summary>
        /// The execution time is 0.73
        /// * Evaluating Iteration vs LINQ
        /// * Iteration is better !!!
        /// </summary>
        public static void Run3()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
                tests[i][2] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var leftNumbers = new StringScanner(test[1]).GetAllPositiveInt64(n).OrderBy(x => x).ToArray();
                var rightNumbers = new StringScanner(test[2]).GetAllPositiveInt64(n).OrderByDescending(x => x).ToArray();
                long sum = 0;
                for (var i = 0; i < n; i++)
                {
                    sum += leftNumbers[i] * rightNumbers[i];
                }
                Console.WriteLine(sum);
            }
        }

        /// <summary>
        /// The execution time is 0.77
        /// </summary>
        public static void Run2()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
                tests[i][2] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var leftNumbers = new StringScanner(test[1]).GetAllPositiveInt64(n).OrderBy(x => x);
                var rightNumbers = new StringScanner(test[2]).GetAllPositiveInt64(n).OrderByDescending(x => x).ToArray();
                Console.WriteLine(leftNumbers.Select((x, k) => x * rightNumbers[k]).Sum());
            }
        }

        /// <summary>
        /// The execution time is 1.21
        /// </summary>
        public static void Run1()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                Console.ReadLine(); // Skip the number of elements
                tests[i][0] = Console.ReadLine().Trim();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var leftNumbers = test[0].Split(' ').Select(long.Parse).OrderBy(x => x);
                var rightNumbers = test[1].Split(' ').Select(long.Parse).OrderByDescending(x => x).ToArray();
                Console.WriteLine(leftNumbers.Select((x, k) => x * rightNumbers[k]).Sum());
            }
        }
    }
}