using System;
using System.Diagnostics.CodeAnalysis;
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
    /// 1
    /// 5
    /// 2 4 6 8 12
    /// Output:
    /// 5
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Prime
    {
        /// <summary>
        /// The execution time is 0.14
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
                // var n = int.Parse(test[0]);
                var sum = StringScanner.SumPositiveInt(test[1]);
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