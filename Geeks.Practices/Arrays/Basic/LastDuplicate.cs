using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Last duplicate element in a sorted array"
    /// 
    /// Given a sorted array with duplicate elements
    ///     we have to find the index of last duplicate element and print index of it and also print the duplicate element.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// For each test case
    ///     the first line contains an integer N denoting the size of array A
    ///     followed by N-space separated integers denoting the elements of the array.
    /// 
    /// Output:
    /// For each test case
    ///     the output is two integers denoting the last index of the duplicate element and that duplicate element respectively
    ///     and if no duplicate element occurs print -1.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=50
    /// 1<=A[i]<=50
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 6
    /// 1 5 5 6 6 7
    /// 5
    /// 1 2 3 4 5
    /// 10
    /// 5 7 8 8 10 12 14 15 16 17 
    /// 10
    /// 1 3 8 8 9 17 19 20 20 22
    /// 
    /// Output:
    /// 4 6
    /// -1
    /// 3 8
    /// 8 20
    /// 
    /// Explanation:
    /// 1.  Last duplicate element is 6 having index 4.
    /// 2. As no duplicate element exist, hence -1 is printed.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class LastDuplicate
    {
        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunAnotherLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ');
            }

            foreach (var test in tests)
            {
                var lastDuplicate = test.Where((x, i) => i > 0 && x == test[i - 1]).LastOrDefault();
                Console.WriteLine(lastDuplicate == null ? "-1" : $"{Array.LastIndexOf(test, lastDuplicate)} {lastDuplicate}");
            }
        } 

        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunCompareToLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ');
            }

            foreach (var test in tests)
            {
                var lastDuplicate = test.GroupBy(x => x).LastOrDefault(x => x.Count() > 1);
                Console.WriteLine(lastDuplicate == null ? "-1" : $"{Array.LastIndexOf(test, lastDuplicate.Key)} {lastDuplicate.Key}");
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).ToArray();
            }

            foreach (var test in tests)
            {
                var lastDuplicate = test.GroupBy(x => x).LastOrDefault(x => x.Count() > 1);
                Console.WriteLine(lastDuplicate == null ? "-1" : $"{Array.LastIndexOf(test, lastDuplicate.Key)} {lastDuplicate.Key}");
            }
        }

        /// <summary>
        /// The execution time is 0.08
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
                var lastDuplicate = numbers.Where((x, i) => i > 0 && x == numbers[i - 1]).DefaultIfEmpty(-1).LastOrDefault();
                Console.WriteLine(lastDuplicate == -1 ? "-1" : $"{Array.LastIndexOf(numbers, lastDuplicate)} {lastDuplicate}");
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunCompareToScanner()
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
                var scanner = new StringScanner(test[1], true);
                var right = scanner.PreviousPositiveInt();
                var i = 1;
                var result = "-1";
                while (scanner.HasNext)
                {
                    var left = scanner.PreviousPositiveInt();
                    if (right == left)
                    {
                        result = $"{n - i} {left}";
                        break;
                    }

                    right = left;
                    i++;
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void RunScanner()
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
                // var n = int.Parse(test[0]); Skip the number of elements
                var scanner = new StringScanner(test[1]);
                var previous = scanner.NextPositiveInt();
                var i = 1;
                var result = "-1";
                while (scanner.HasNext)
                {
                    var current = scanner.NextPositiveInt();
                    if (previous == current)
                    {
                        result = $"{i} {current}";
                    }

                    previous = current;
                    i++;
                }

                Console.WriteLine(result);
            }
        }
    }
}