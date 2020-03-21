using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Alternative Sorting"
    /// 
    /// Given an array Arr[] of N distinct integers,
    ///     print the array in such a way that the first element is first maximum and second element is first minimum and so on.
    /// 
    /// Input:
    /// First line of input contains a single integer T which denotes the number of test cases.
    /// Then T test case follows.
    /// First line of each test case contains a single integer N which denotes the number of elements in the array.
    /// Second line of each test case contains N space separated integers.
    /// 
    /// Output:
    /// For each test case
    ///     print the given array in such a way that the first element is first maximum and second element is first minimum and so on.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10e4
    /// 1<=Arr[i]<=10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 7
    /// 7 1 2 3 4 5 6
    /// 8
    /// 1 6 9 4 3 7 8 2
    /// 22
    /// 843 869 529 190 873 909 959 499 37 809 754 249 304 334 134 649 891 755 568 747 369 530 
    /// 1
    /// 47
    /// 
    /// Output:
    /// 7 1 6 2 5 4 3
    /// 9 1 8 2 7 3 6 4
    /// 959 37 909 134 891 190 873 249 869 304 843 334 809 369 755 499 754 529 747 530 649 568
    /// 47
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class AlternateSorting
    {
        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(string.Join(' ', test.Skip(test.Length / 2).Reverse().Interleave(test.Take(test.Length / 2))));
            }
        }

        /// <summary>
        /// The execution time is 0.10
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
                Console.WriteLine(string.Join(' ', numbers.Skip(n / 2).Reverse().Interleave(numbers.Take(n / 2))));
            }
        }

        /// <summary>
        /// The execution time is 0.08
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
                Array.Sort(numbers);
                var result = new int[n];
                var i = 0;
                var right = n - 1;
                var left = 0;
                var flag = true;
                while (left <= right)
                {
                    if (flag)
                    {
                        result[i++] = numbers[right--];
                    }
                    else
                    {
                        result[i++] = numbers[left++];
                    }

                    flag = !flag;
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}