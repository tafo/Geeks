using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Greater on right side"
    /// 
    /// You are given an array A of size N.
    /// Replace every element with the next greatest element (greatest element on its right side) in the array.
    /// Also, since there is no element next to the last element, replace it with -1.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains two lines of input.
    /// The first line is N, the size of tha array.
    /// The second line contains N space separated integers.
    /// 
    /// Output:
    /// For each test case, print the modified array.
    /// 
    /// Constraints:
    /// 1 <= T <= 50
    /// 1 <= N <= 100
    /// 1 <= Ai <= 1000
    /// 
    /// Example:
    /// Input:
    /// 7
    /// 6
    /// 16 17 4 3 5 2
    /// 4
    /// 2 3 1 9
    /// 5
    /// 5 4 3 2 1
    /// 9
    /// 1 2 3 4 5 9 8 7 6
    /// 9
    /// 5 4 3 9 2 1 7 8 6
    /// 9
    /// 1 9 8 2 3 7 6 5 4
    /// 4
    /// 3 2 9 1
    /// Output:
    /// 17 5 5 5 2 -1
    /// 9 9 9 -1
    /// 4 3 2 1 -1
    /// 9 9 9 9 9 8 7 6 -1
    /// 9 9 9 8 8 8 8 6 -1
    /// 9 8 7 7 7 6 5 4 -1
    /// 9 9 1 -1
    /// 
    /// Explanation:
    /// Testcase1:
    /// For 16 the greatest element on its right is 17.
    /// For 17 it's 5.
    /// For 4 it's 5.
    /// For 3 it's 5.
    /// For 5 it's 2.
    /// For 2 it's -1(no element to its right).
    /// So the answer is 17 5 5 5 2 -1
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ReplaceWithNextGreatest
    {
        /// <summary>
        /// The execution time is 0.13
        /// * Reverse read
        /// Time complexity => O(n)
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = new int[n];
                var scanner = new StringScanner(test[1], true);
                var max = numbers[--n] = -1;
                while (scanner.HasNext && n > 0)
                {
                    var number = scanner.PreviousPositiveInt();
                    if (number > max)
                    {
                        max = number;
                    }
                    numbers[--n] = max;
                }

                Console.WriteLine(string.Join(' ', numbers));
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run1()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = new int[n];
                var scanner = new StringScanner(test[1]);
                scanner.NextPositiveInt(); // Skip the first number;
                var index = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    numbers[index] = number;
                    var k = index - 1;
                    while (k >= 0 && number > numbers[k])
                    {
                        numbers[k--] = number;
                    }

                    index++;
                }

                numbers[index] = -1;

                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}