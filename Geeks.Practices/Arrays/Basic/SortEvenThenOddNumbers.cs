using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Segregate Even and Odd numbers"
    /// 
    /// Given an array A[], write a program that segregates even and odd numbers.
    /// The program should put all even numbers first in sorted order, and then odd numbers in sorted order.
    /// 
    /// Input:
    /// The first line of input contains an integer T, denoting the number of test cases.
    /// For each test case there will be two lines of input:
    ///     The first line contains a single integer N denoting the size of array.
    ///     The second line contains N space-separated integers A1, A2, ..., AN denoting the elements of the array.
    /// 
    /// Output:
    /// For each test case, print the segregated array.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 10e5
    /// 0 ≤A[i]&lt;=10e5
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 7
    /// 12 34 45 9 8 90 3
    /// 5
    /// 0 1 2 3 4
    /// Output:
    /// 8 12 34 90 3 9 45
    /// 0 2 4 1 3
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SortEvenThenOddNumbers
    {
        /// <summary>
        /// The execution time is 1.51
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
                var left = numbers.Where(x => (x & 1) == 0).OrderBy(x => x);
                var right = numbers.Where(x => (x & 1) == 1).OrderBy(x => x);
                Console.WriteLine(string.Join(' ', left.Concat(right)));
            }
        }

        /// <summary>
        /// The execution time is 0.87
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
                var left = 0;
                var right = n - 1;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if ((number & 1) == 1)
                    {
                        numbers[right--] = number;
                    }
                    else
                    {
                        numbers[left++] = number;
                    }
                }
                Array.Sort(numbers, 0, left);
                Array.Sort(numbers, left, n - left);
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}