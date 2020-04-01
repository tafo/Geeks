using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sum Triangle for given array"
    /// 
    /// Given a array, write a program to construct a triangle where last row contains elements of given array,
    ///     every element of second last row contains sum of below two elements and so on.
    /// 
    /// Example:
    /// Input: arr[] = {4, 7, 3, 6, 7};
    /// Output:
    /// 81
    /// 40 41
    /// 21 19 22
    /// 11 10 9 13
    /// 4 7 3 6 7
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains an integer n denoting the size of the array.
    /// Then next line contains n space separated integers forming the array.
    /// 
    /// Output:
    /// Output the sum triangle for the input array with space separated integers.
    /// 
    /// Constraints:
    /// 1<=T<=1000
    /// 1<=N<=1000
    /// 1<=Ai<=1000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 4 7 3 6 7
    /// 7
    /// 5 8 1 2 4 3 14
    /// 5
    /// 1 3 4 5 2
    /// 
    /// Output:
    /// 81 40 41 21 19 22 11 10 9 13 4 7 3 6 7 
    /// 200 98 102 55 43 59 34 21 22 37 22 12 9 13 24 13 9 3 6 7 17 5 8 1 2 4 3 14
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SumTriangle
    {
        /// <summary>
        /// The execution time is 0.14
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
                var result = numbers.Concat(Array.Empty<int>());
                while (n-- > 0)
                {
                    numbers = numbers.Skip(1).Select((x, i) => x + numbers[i]).ToArray();
                    result = numbers.Concat(result);
                }
                Console.WriteLine(string.Join(' ', result));
            }
        }

        /// <summary>
        /// The execution time is 0.13
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
                var triangle = new int[n][];
                var scanner = new StringScanner(test[1]);
                var i = 0;
                while (scanner.HasNext)
                {
                    triangle[i] = new int[n - i];
                    triangle[0][i] = scanner.NextPositiveInt();
                    for (var a = 1; a <= i; a++)
                    {
                        triangle[a][i - a] = triangle[a - 1][i - a] + triangle[a - 1][i - a + 1];
                    }

                    i++;
                }


                var result = new int[n * (n + 1) / 2];
                var index = 0;
                for (var a = n - 1; a >= 0; a--)
                {
                    Array.Copy(triangle[a], 0, result, index, n - a);
                    index += n - a;
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}