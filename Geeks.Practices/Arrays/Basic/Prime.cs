using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Transform to prime"
    /// 
    /// Given an array of n integers.
    /// Find minimum number to be inserted in array, so that sum of all elements of array becomes prime.
    /// If sum is already prime, then return 0.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// The T test cases follow.
    /// First line of every test case consists of N, denoting number of elements of array.
    /// Second line of every test case consists of elements of array.
    /// 
    /// Output:
    /// Single line output, print the required answer.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=1000
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 5
    /// 2 4 6 8 12
    /// 18
    /// 935 200 141 771 73 328 452 197 883 611 495 99 393 583 954 54 803 848 
    /// 1
    /// 617
    /// Output:
    /// 5
    /// 1
    /// 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Prime
    {
        /// <summary>
        /// The execution time is 0.18
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
                var sum = test.Split(' ').Sum(int.Parse);
                var k = sum;
                while (!k.IsPrime())
                {
                    k++;
                }

                Console.WriteLine(k - sum);
            }
        }

        /// <summary>
        /// The execution time is 0.13
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
                // var n = int.Parse(test[0]);
                var sum = StringScanner.SumPositiveInt(test);
                var k = sum;
                while (!k.IsPrime())
                {
                    k++;
                }

                Console.WriteLine(k - sum);
            }
        }
    }
}