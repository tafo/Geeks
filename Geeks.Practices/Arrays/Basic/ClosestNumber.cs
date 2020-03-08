using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find the closest number"
    /// 
    /// Given an array of sorted integers.
    /// The task is to find the closest value to the given number in array. Array may contain duplicate values.
    /// 
    /// Note: If the difference is same for two values print the value which is greater than the given number.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    ///     First line of each test case contains two integers N & K and the second line contains N space separated array elements.
    /// 
    /// Output:
    /// For each test case, print the closest number in new line.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10e5
    /// 1<=K<=10e5
    /// 1<=A[i]<=10e5
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 4 4
    /// 1 3 6 7
    /// 7 4
    /// 1 2 3 5 6 8 9
    /// 
    /// Output:
    /// 3
    /// 5
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class ClosestNumber
    {
        /// <summary>
        /// Without using Math.Abs()
        /// The execution time is 0.16
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                //var n = int.Parse(split[0]); Skip the number of elements
                var key = int.Parse(split[1]);
                var scanner = new StringScanner(testCase[1]);
                var result = scanner.NextPositiveInt();
                var difference = result - key;
                if (difference < 0)
                {
                    difference *= -1;
                }

                difference = difference < 0 ? -1 * difference : difference;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    var currentDifference = number - key;
                    if (currentDifference < 0)
                    {
                        currentDifference *= -1;
                    }

                    if (currentDifference < difference)
                    {
                        result = number;
                        difference = currentDifference;
                    }
                    else if (currentDifference == difference && number > result)
                    {
                        result = number;
                    }
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        internal static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                //var n = int.Parse(split[0]); Skip the number of elements
                var key = int.Parse(split[1]);
                var scanner = new StringScanner(testCase[1]);
                var result = scanner.NextPositiveInt();
                var difference = Math.Abs(result - key);
                
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    var currentDifference = Math.Abs(number - key);
                    if (currentDifference < difference)
                    {
                        result = number;
                        difference = currentDifference;
                    }
                    else if (currentDifference == difference && number > result)
                    {
                        result = number;
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}