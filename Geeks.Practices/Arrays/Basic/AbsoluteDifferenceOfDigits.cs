using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Absolute Difference of 1"
    /// 
    /// Given an array A of size N.
    /// Print all the numbers less than K in the array.
    /// The numbers should be such that the difference between every adjacent digit should be 1.
    /// 
    /// Note: Print '-1' if no number if valid.
    /// 
    /// Input:
    /// The first line consists of an integer T i.e number of test cases.
    /// T test cases follow.
    /// Each test case contains two lines of input.
    /// The first line consists of two integers N and K separated by a space.
    /// The next line consists of N spaced integers. 
    /// 
    /// Output:
    /// For each test case, print the required output.
    /// 
    /// Constraints: 
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= K, A[i] <= 10e18
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 8 54
    /// 7 98 56 43 45 23 12 8
    /// 10 1000
    /// 87 89 45 235 465 765 123 987 499 655
    /// 
    /// Output:
    /// 43 45 23 12
    /// 87 89 45 765 123 987
    /// 
    /// Explanation:
    /// Testcase1: 43 45 23 12  all these numbers have adjacent digits diff as 1 and they are less than 54
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class AbsoluteDifferenceOfDigits
    {
        /// <summary>
        /// The execution time is 0.32
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
                var line = test[0].Split(' ');
                var n = int.Parse(line[0]);
                var key = int.Parse(line[1]);
                var numbers = new long[n];
                var scanner = new StringScanner(test[1]);
                var i = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextUInt64();
                    
                    if (number >= key || number < 10) continue;

                    var num = number;
                    var lastDigit = num % 10;
                    num /= 10;
                    var isQualifiedNumber = true;
                    while (num > 0)
                    {
                        var digit = num % 10;
                        if (Math.Abs(lastDigit - digit) != 1)
                        {
                            isQualifiedNumber = false;
                            break;
                        }

                        lastDigit = digit;
                        num /= 10;
                    }

                    if (isQualifiedNumber)
                    {
                        numbers[i++] = number;
                    }
                }

                Console.WriteLine(string.Join(' ', numbers.Take(i).DefaultIfEmpty(-1)));
            }
        }
    }
}