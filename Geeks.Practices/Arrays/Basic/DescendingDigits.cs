using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Form largest number from digits"
    /// 
    /// Given an array of numbers form 0 to 9 of size N.
    /// Your task is to rearrange elements of the array such that after combining all the elements of the array number formed is maximum.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// The first line of each test case contains an integer N denoting the number of elements in the array.
    /// Then in the next line are N space separated integers denoting the elements of the array.
    /// 
    /// Output:
    /// For each test case print a single line a number denoting the largest number that can be achieved by rearranging the elements of the array.
    /// 
    /// Constraints:
    /// 1 <= T <= 10e3
    /// 1 <= N <= 10e7
    /// 0 <= Ai <= 9
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 5
    /// 9 0 1 3 0
    /// 3
    /// 1 2 3
    /// 14
    /// 2 5 4 9 5 3 2 5 4 6 0 3 5 7 
    /// 16
    /// 2 3 8 0 1 1 4 7 9 9 7 0 3 0 9 1
    /// 
    /// Output:
    /// 93100
    /// 321
    /// 97655554433220
    /// 9998774332111000
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class DescendingDigits
    {
        /// <summary>
        /// The execution time is 1.13
        /// * Interesting
        /// </summary>
        public static void RunThis()
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
                var digits = test.Where(c => !char.IsWhiteSpace(c)).ToArray();
                Array.Sort(digits, (a,b) => b.CompareTo(a));
                Console.WriteLine(string.Join(string.Empty, digits));
            }
        }

        /// <summary>
        /// The execution time is 2.15
        /// * Interesting
        /// </summary>
        public static void RunAnotherSingleLineLinq()
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
                Console.WriteLine(string.Join(string.Empty, test.Where(c => !char.IsWhiteSpace(c)).OrderByDescending(x => x)));
            }
        }

        /// <summary>
        /// The execution time is 3.42   !!!
        /// * Interesting
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
                Console.WriteLine(string.Join(string.Empty, test.Split(' ').Select(int.Parse).OrderByDescending(x => x)));
            }
        }

        /// <summary>
        /// The execution time is 1.37
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
                var numbers = StringScanner.GetDigit(test[1], n);
                Array.Sort(numbers, (a,b) => b.CompareTo(a));
                Console.WriteLine(string.Join(string.Empty, numbers));
            }
        }
    }
}