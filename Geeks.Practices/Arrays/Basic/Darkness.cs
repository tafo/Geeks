using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Fighting the darkness"
    /// 
    /// You are given an array A representing size of candles which reduce 1 unit in a day.
    /// Room is illuminated using given x candles, where x is the size of array A.
    /// Question is to find maximum number of days room is without darkness.
    /// 
    /// Input:
    /// The first line of input consists of an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains an integer N denoting the size of the array.
    /// Then in the next line are N space separated elements of the array.
    /// 
    /// Output:
    /// For each test case, print the maximum number of days room will be illuminated.
    /// 
    /// Constraints:
    /// 1<=T<=200
    /// 1<=N<=10e7
    /// 1<=Elements of array <=10e18
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 3
    /// 1 1 2
    /// 5
    /// 2 3 4 1 2
    /// 5 
    /// 15 16 18 19 20
    /// Output:
    /// 2
    /// 4
    /// 20
    /// Explanation:
    /// Testcase1: The candles' length reduce by 1 in 1 day.
    /// So, at the end of day 1: Sizes would be 0 0 1
    /// So, at end of day 2: Sizes would be 0 0 0.
    /// This means the room was illuminated for 2 days.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Darkness
    {
        /// <summary>
        /// The execution time is 0.49
        /// </summary>
        public static void RunLinq()
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
                Console.WriteLine(test.Split(' ').Max(long.Parse));
            }
        }

        /// <summary>
        /// The execution time is 0.24
        /// </summary>
        public static void Run()
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
                long max = 0;
                var scanner = new StringScanner(test);
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveLong();
                    if (number > max)
                    {
                        max = number;
                    }
                }

                Console.WriteLine(max);
            }
        }
    }
}