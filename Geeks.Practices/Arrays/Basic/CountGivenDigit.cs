using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find Number of Numbers"
    /// 
    /// Given an array A[]  of n elements.
    /// Your task is to complete the Function num which returns an integer denoting the total number of times digit k appears in the whole array.
    /// 
    /// For Example:
    /// 
    /// A[]={11,12,13,14,15}, k=1
    /// 
    /// Output=6 //Count of the digit 1 in the array
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the no of test cases.
    /// Then T test cases follow.
    /// The first line of each test case contain an integer n denoting the size of the array A[].
    /// Then in the second line are n space separated values of the array A[].
    /// In the third line of each test case contains an integer k, which is the digit to be counted.
    /// 
    /// Output:
    /// For each test case in a new line print the number of elements counted.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=20
    /// 1<=A[i]<=1000
    /// 
    /// Example(To be used for expected output):
    /// Input:
    /// 2
    /// 5
    /// 11 12 13 14 15 
    /// 1
    /// 4
    /// 0 10 20 30
    /// 0
    /// 
    /// Output:
    /// 6
    /// 4
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountGivenDigit
    {
        /// <summary>
        /// Without the specified method
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
                var numbers = test[1].Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine(Num(numbers, n, k));
            }
        }

        /// <summary>
        /// The execution time of the equivalent JAVA function is 0.19 
        /// </summary>
        // ReSharper disable once SuggestBaseTypeForParameter
        private static int Num(int[] a, int n, int k)
        {
            var count = 0;
            for (var i = 0; i < n; i++)
            {
                var number = a[i];

                do
                {
                    if (number % 10 == k)
                    {
                        count++;
                    }

                    number /= 10;

                } while (number > 0);
            }

            return count;
        }

        /// <summary>
        /// Without the specified method
        /// </summary>
        public static void RunThis()
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
                var digit = test[1][0];
                var count = test[0].Count(c => c == digit);
                Console.WriteLine(count);
            }
        }
    }
}