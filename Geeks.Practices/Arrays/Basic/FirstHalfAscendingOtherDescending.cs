using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sort first half in ascending and second half in descending"
    /// 
    /// Given an array of integers, sort the first half of the array in ascending order and second half in descending order.
    /// 
    /// Input:
    /// The first line consists of an integer T i.e number of test cases.
    /// The first line of each test case consists of an integers N.
    /// The next line consists of N spaced integers. 
    /// 
    /// Output:
    /// Print the required output.
    /// 
    /// Constraints: 
    /// 1<=T<=100
    /// 1<=N<=100
    /// 1<=a[i]<=1000
    /// 
    /// Example:
    /// 
    /// Input:
    /// 3
    /// 9
    /// 5 2 4 7 9 3 1 6 8
    /// 6
    /// 1 2 3 4 5 6
    /// 15
    /// 988 857 744 492 228 366 860 937 433 552 438 229 276 408 475 
    /// 22
    /// 859 396 30 238 236 794 819 429 144 12 929 530 777 405 444 764 614 539 607 841 905 819
    /// 
    /// Output:
    /// 1 2 3 4 9 8 7 6 5
    /// 1 2 3 6 5 4
    /// 228 229 276 366 408 433 438 988 937 860 857 744 552 492 475
    /// 12 30 144 236 238 396 405 429 444 530 539 929 905 859 841 819 819 794 777 764 614 607
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FirstHalfAscendingOtherDescending
    {
        /// <summary>
        /// The execution time is 0.10
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
                Console.WriteLine(string.Join(' ', numbers.Take(n / 2).Concat(numbers.Skip(n / 2).Reverse())));
            }
        }

        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void RunCompareToMix()
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
                var numbers = StringScanner.GetPositiveInt(test[1], n).OrderBy(x => x).ToArray();
                Console.WriteLine(string.Join(' ', numbers.Take(n / 2).Concat(numbers.Skip(n / 2).Reverse())));
            }
        }

        /// <summary>
        /// The execution time is 0.09
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
                Console.WriteLine(string.Join(' ', numbers.Take(n / 2).Concat(numbers.Skip(n / 2).Reverse())));
            }
        }

        /// <summary>
        /// The execution time is 0.09
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
                var numbers = new int[n];
                var scanner = new StringScanner(test[1]);
                var i = 0;
                while (scanner.HasNext)
                {
                    numbers[i++] = scanner.NextPositiveInt();
                }
                Array.Sort(numbers);
                Array.Reverse(numbers, n / 2, n - n / 2);
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}