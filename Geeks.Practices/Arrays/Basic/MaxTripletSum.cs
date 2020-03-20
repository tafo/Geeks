using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Maximum triplet sum in array"
    /// 
    /// Given an array, the task is to find maximum triplet sum in the array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains an Integer N denoting size of array and the second line contains N space separated elements.
    /// 
    /// Output:
    /// For each test case, print the maximum triplet sum in new line.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 3<=N<=10e6
    /// -10e5<=A[i]<=10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 4
    /// 6
    /// 1 0 8 6 4 2
    /// 7
    /// 1 2 3 0 -1 8 10
    /// 4
    /// 55 100 33 61 
    /// 15
    /// 57 44 92 28 66 60 37 33 52 38 29 76 8 75 22
    /// Output:
    /// 18
    /// 21
    /// 216
    /// 243
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaxTripletSum
    {
        /// <summary>
        /// The execution time is 0.67
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
                Console.WriteLine(test.Split(' ').Select(int.Parse).OrderByDescending(x => x).Take(3).Sum());
            }
        }

        /// <summary>
        /// The execution time is 0.17
        /// </summary>
        public static void RunBest()
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
                var first = int.MinValue;
                var second = int.MinValue;
                var third = int.MinValue;
                var scanner = new StringScanner(test);
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt();
                    if (number < third) continue;
                    if (number > second)
                    {
                        third = second;
                        if (number > first)
                        {
                            second = first;
                            first = number;
                        }
                        else
                        {
                            second = number;
                        }
                    }
                    else
                    {
                        third = number;
                    }
                }
                Console.WriteLine(first + second + third);
            }
        }

        /// <summary>
        /// The execution time is 0.35
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
                var numbers = StringScanner.GetInt(test[1], n);
                Array.Sort(numbers, (a, b) => b.CompareTo(a));
                Console.WriteLine(numbers[0] + numbers[1] + numbers[2]);
            }
        }
    }
}