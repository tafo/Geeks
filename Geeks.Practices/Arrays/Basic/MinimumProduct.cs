using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimum Product of k Integers"
    /// 
    /// Given an array of N positive integers.
    /// You need to write a program to print the minimum product of k integers of the given array.
    /// 
    /// Examples:
    /// 
    /// Input: 198 76 544 123 154 675
    /// k = 2
    /// Output : 9348
    /// We get minimum product after multiplying 76 and 123.
    /// 
    /// Input : 11 8 5 7 5 100
    /// k = 4
    /// Output : 1400
    /// Note: Since output could be large, hence module 10^9+7 and then print answer.
    /// 
    /// Input:
    /// First line of the input contains an integer T, denoting the number of test cases.
    /// Then T test case follows. First line of each test case contains an integer N, denoting the size of the array.
    /// Next line contains N space separated integers denoting the elements of the array.
    /// Last line of each test case contains the integer K.
    /// 
    /// Output:
    /// For each test case print the required answer in a new line.
    /// 
    /// Constraints:
    /// 1<=T<=10e3
    /// 1<=K<=N<=10e5
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 5
    /// 1 2 3 4 5
    /// 2
    /// 3
    /// 9 10 8
    /// 3
    /// 22
    /// 168 372 141 96 439 187 144 42 425 286 272 87 421 311 49 341 282 255 52 363 425 350 
    /// 8
    /// 10
    /// 381 313 442 77 40 244 428 9 344 223
    /// 9
    /// 
    /// Output:
    /// 2
    /// 720
    /// 54839848
    /// 528030742
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinimumProduct
    {
        /// <summary>
        /// The execution time is 0.27
        /// </summary>
        public static void RunSingeLine()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                Console.ReadLine();
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test[0].Split(' ').Select(int.Parse).OrderBy(x => x).Take(int.Parse(test[1])).Aggregate(1L, (x, y) => x * y % 100000007));
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var k = int.Parse(test[2]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                long product = 1;
                for (var i = 0; i < k; i++)
                {
                    product = product * numbers[i] % 1000000007;
                }

                Console.WriteLine(product);
            }
        }
    }
}