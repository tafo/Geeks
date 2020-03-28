using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Why is Melody so chocolaty?"
    /// 
    /// Chunky gets happy by eating Melody.
    /// Given an array of N elements each element represent happiness chunky get by eating melody.
    /// Chunky knows why melody is so chocolaty but will only tell you once you tell him
    ///     the Max happiness he can get by eating two adjacent melodies.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains an integer N and the second line contains N space separated array elements.
    /// 
    /// Output:
    /// For each test case, print the Maximum Happiness in new line.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 100000
    /// -100000 <= A[i] <= 100000
    /// 
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 5
    /// 1 2 3 4 5
    /// 4
    /// 5 2 3 4
    /// 20
    /// -11478 -29358 -26962 -24464 -5705 -28145 -23281 -16827 -9961 -491 -2995 -11942 -4827 -5436 -32391 -14604 -3902 -153 -292 -12382
    /// 
    /// Output:
    /// 9
    /// 7
    /// -445
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaxAdjacentPairSum
    {
        /// <summary>
        /// The execution time is 0.23
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
                var numbers = StringScanner.GetInt(test[1], n);
                Console.WriteLine(numbers.Skip(1).Select((x, i) => x + numbers[i]).Max());
            }
        }

        /// <summary>
        /// The execution time is 0.20
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
                var scanner = new StringScanner(test[1]);
                var left = 0;
                var current = scanner.NextInt();
                if (n == 1)
                {
                    Console.WriteLine(current);
                }
                else
                {
                    var result = -200001;
                    while (scanner.HasNext)
                    {
                        var number = scanner.NextInt();
                        current = (left = current - left) + number;
                        if (current > result)
                        {
                            result = current;
                        }
                    }

                    Console.WriteLine(result);
                }
            }
        }
    }
}