using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Maximize ∑arr[i]*i of an Array"
    /// 
    /// Given an array A of N integers.
    /// Your task is to write a program to find the maximum value of ∑arr[i]*i, where i = 0, 1, 2,…., n – 1.
    /// You are allowed to rearrange the elements of the array.
    /// Note: Since output could be large, hence module 10e9+7 and then print answer.
    /// 
    /// Input:
    /// First line of the input contains an integer T, denoting the number of test cases.
    /// Then T test case follows.
    /// Each test case contains two lines of input.
    /// First line contains an integer N, denoting the size of the array.
    /// Next line contains N space separated integers denoting the elements of the array.
    /// 
    /// Output:
    /// For each test case, print the required answer on a new line.
    /// 
    /// Constraints:
    /// 1 <= T <= 10e3
    /// 1 <= N <= 10e7
    /// 1 <= Ai <= N
    /// 
    /// Example Input:
    /// 4
    /// 5
    /// 5 3 2 4 1
    /// 3
    /// 1 2 3
    /// 15
    /// 88 57 44 92 28 66 60 37 33 52 38 29 76 8 75 
    /// 22
    /// 59 96 30 38 36 94 19 29 44 12 29 30 77 5 44 64 14 39 7 41 5 19
    /// 
    /// Output:
    /// 40
    /// 8
    /// 6976
    /// 12136
    /// 
    /// Explanation:
    /// Testcase1: If we arrange the array as 1 2 3 4 5 then
    ///     we can see that the minimum index will multiply with minimum number
    ///     and maximum index will multiply with maximum number.
    /// So 1*0+2*1+3*2+4*3+5*4=0+2+6+12+20 =40 mod(109+7) = 40
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaximizeProductOfIndexAndNumber
    {
        /// <summary>
        /// The execution time is 1.3
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                tests[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Split(' ').Select(long.Parse).OrderBy(x => x).Select((x, i) => x * i).Sum() % 1000000007);
            }
        }

        /// <summary>
        /// The execution time is 0.54
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
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveLong(test[1], n);
                Array.Sort(numbers);
                long sum = 0;
                for (var i = 0; i < n; i++)
                {
                    sum += i * numbers[i];
                }

                Console.WriteLine(sum % 1000000007);
            }
        }
    }
}