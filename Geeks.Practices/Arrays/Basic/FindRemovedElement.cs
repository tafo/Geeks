using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Missing number in shuffled array"
    /// 
    /// Given an array A of size N.
    /// The contents of A are copied into another array B and numbers are shuffled.
    /// Also, one element is removed from B.
    /// The task is to find the missing element.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains three lines of input.
    /// The first line contains an integer N, where N is the size of array.
    /// The second line contains N space separated integers denoting elements of the array A[ ].
    /// The third line contains N-1 space separated integers denoting elements of the array B[ ].
    /// 
    /// Output:
    /// For each test case, print the missing number.
    /// 
    /// Constraints:
    /// 1 <= T <= 1000
    /// 1 <= N <= 107e
    /// 1 <= A, B <= 10e10
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 3 5 6 9
    /// 1 9 6 5
    /// 3
    /// 1 2 3
    /// 1 3
    /// 
    /// Output:
    /// 3
    /// 2
    /// 
    /// Explanation:
    /// Test case 1: 3 is the only element missing from B.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindRemovedElement
    {
        /// <summary>
        /// The execution time is 0.99
        /// * We could not get a better performance by sorting arrays. 
        /// </summary>
        public static void RunAnotherCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var allNumbers = test[1].Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
                var result = allNumbers[0];
                if (n > 1)
                {
                    var numbers = test[2].Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
                    result = allNumbers.SkipWhile((x, i) => i < numbers.Length && x == numbers[i]).First();
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.74
        /// </summary>
        public static void RunCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var allNumbers = test[1].Split(' ').Select(int.Parse).ToArray();
                var result = allNumbers[0];
                if (n > 1)
                {
                    var numbers = test[2].Split(' ').Select(int.Parse).ToArray();
                    result = allNumbers.Except(numbers).Single();
                }
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.74
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var allNumbers = test[1].Split(' ').Select(int.Parse);
                Console.WriteLine(n == 1 ? allNumbers.Single() : allNumbers.Except(test[2].Split(' ').Select(int.Parse)).Single());
            }
        }

        /// <summary>
        /// The execution time is 0.29
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var allNumbers = StringScanner.GetPositiveLong(test[1], n);
                Console.WriteLine(n == 1 ? allNumbers[0] : allNumbers.Except(StringScanner.GetPositiveLong(test[2], n - 1)).Single());
            }
        }

        /// <summary>
        /// The execution time is 0.40
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var allNumbers = StringScanner.GetPositiveLong(test[1], n);
                Array.Sort(allNumbers);
                var result = allNumbers[n - 1];
                if (n > 1)
                {
                    var numbers = StringScanner.GetPositiveLong(test[2], n - 1);
                    Array.Sort(numbers);
                    for (var i = 0; i < n - 1; i++)
                    {
                        if (allNumbers[i] == numbers[i]) continue;
                        result = allNumbers[i];
                        break;
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}