using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimum number to form the sum even"
    /// 
    /// Given an array, write a program to add the minimum number(should be greater than 0) to the array so that the sum of array becomes even.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// The first and last line of each test case consists of an integer n.
    /// Next line of each test case consists of n spaced integers.
    /// 
    /// Output:
    /// Print the minimum number required to the array so that the sum becomes even .
    /// 
    /// Constraints: 
    /// 1<=T<=100
    /// 1<=n<=1000
    /// 1<=a[i]<=100000
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 8
    /// 1 2 3 4 5 6 7 8
    /// 9
    /// 1 2 3 4 5 6 7 8 9
    /// 1
    /// 99617 
    /// 14
    /// 64021 53676 80778 42025 20996 47583 1906 78990 16081 33665 62079 19230 26221 73938
    /// 
    /// Output:
    /// 2
    /// 1
    /// 1
    /// 1
    /// 
    /// Remark:
    /// If the sum of the integers is an even number, the result will be 2, otherwise 1. 
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class EvenSum
    {
        /// <summary>
        /// The execution time is 0.18
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
                Console.WriteLine((test.Split(' ').Sum(int.Parse) & 1) == 1 ? 1 : 2);
            }
        }

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
                // var n = int.Parse(test[0]); Skip the number of elements
                var sum = StringScanner.SumPositiveInt(test[1]);
                Console.WriteLine((sum & 1) == 1 ? 1 : 2);
            }
        }
    }
}