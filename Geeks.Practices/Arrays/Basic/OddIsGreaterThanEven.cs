using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// the title is "Play with an array"
    /// 
    /// Given an unsorted array arr of size N,
    ///     rearrange the elements of array such that number at the odd index is greater than the number at the previous even index.
    /// The task is to complete the function formatArray() which will return formatted array.
    /// 
    /// Input:
    /// The first line of input contains T, denoting the number of test cases.
    /// First line of every test case consists of N, denoting number of elements in an array.
    /// Second line of every test case consists of elements in an array separated by space.
    /// 
    /// Output:
    /// If the array formed is according to rules print 1, else 0.
    /// 
    /// User task:
    /// Since this is a functional problem you don't have to worry about the input,
    ///     you just have to complete the function formatArray(), which accepts array arr and its size 
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 100
    /// 1 <= arr[i] <= 100
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 5
    /// 5 4 3 2 1
    /// 4
    /// 4 3 2 1
    ///
    /// Output:
    /// 1
    /// 1
    /// 
    /// Explanation:
    /// Testcase 1:
    /// The given array after modification will be as such: 4 5 2 3 1.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class OddIsGreaterThanEven
    {
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
                var numbers = test[1].Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine(string.Join(' ', FormatArrayLinq(numbers, n)));
            }
        }

        /// <summary>
        /// The signature of this method is given by GfG
        /// </summary>
        public static int[] FormatArrayLinq(int[] a, int n)
        {
            return Enumerable.Range(0, (int)Math.Ceiling(n / 2d)).SelectMany(x => a.Skip(x * 2).Take(2).OrderBy(y => y)).ToArray();
        }

        public static void RunRequired()
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
                Console.WriteLine(string.Join(' ', FormatArray(numbers, n)));
            }
        }

        /// <summary>
        /// The signature of this method is given by GfG
        /// </summary>
        public static int[] FormatArray(int[] a, int n)
        {
            for (var i = 0; i < n; i += 2)
            {
                if (i == n - 1 || a[i] < a[i + 1]) continue;
                var temp = a[i];
                a[i] = a[i + 1];
                a[i + 1] = temp;
            }

            return a;
        }

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
                while (scanner.HasNext)
                {
                    var left = scanner.NextPositiveInt();
                    if (scanner.HasNext)
                    {
                        var right = scanner.NextPositiveInt();
                        if (right < left)
                        {
                            result[i++] = right;
                            result[i++] = left;
                        }
                        else
                        {
                            result[i++] = left;
                            result[i++] = right;
                        }
                    }
                    else
                    {
                        result[i++] = left;
                    }
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}