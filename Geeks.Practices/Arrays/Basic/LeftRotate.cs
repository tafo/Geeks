using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Quick Left Rotation"
    /// 
    /// Given an array of size n and multiple values around which we need to left rotate the array.
    /// 
    /// Input:
    /// First line consists of T test case.
    /// First line of every test case consists of N and K, N denoting number of elements of array and K denoting the number of places to shift.
    /// Second line of every test case consists of elements of array.
    /// 
    /// Output:
    /// Single line output, print the rotated array.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10^4
    /// 1<=K<=10^4
    /// 
    /// Example:
    /// Input:
    /// 1
    /// 5 14
    /// 1 3 5 7 9
    /// Output:
    /// 9 1 3 5 7
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class LeftRotate
    {
        /// <summary>
        /// The execution time is 0.36
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var shift = n - k % n;
                var elements = test[1].Split(' ');
                var result = new string[n];
                Array.Copy(elements, 0, result, shift, n - shift);
                Array.Copy(elements, n - shift, result, 0, shift);
                Console.WriteLine(string.Join(' ', result));
            }
        }

        /// <summary>
        /// The execution time is 0.26
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var shift = n - k % n;
                var scanner = new StringScanner(test[1]);
                var numbers = new int[n];
                while (scanner.HasNext && shift < n)
                {
                    numbers[shift++] = scanner.NextPositiveInt();
                }

                var i = 0;
                while (scanner.HasNext)
                {
                    numbers[i++] = scanner.NextPositiveInt();
                }

                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}