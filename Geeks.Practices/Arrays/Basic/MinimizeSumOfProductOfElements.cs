using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimize sum of alternate product"
    /// 
    /// Given an array of even size consisting of positive integers.
    /// Your task is to find the sum after sorting the array, such that the sum of product of alternate elements is minimum.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains an integer N denoting the size of the array.
    /// Then in the next line are N space separated array elements.
    /// 
    /// Output:
    /// For each test case, print the minimum sum.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 2 <= N <= 10e7
    /// 1 <= Ai <= 10e9
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 8
    /// 9 2 8 4 5 7 6 0
    /// 4
    /// 1 2 3 4
    /// 14
    /// 287 478 116 294 836 587 193 250 722 663 428 591 260 564 
    /// 16
    /// 241 127 773 137 612 369 268 430 783 531 63 824 668 236 330 703
    /// 
    /// Output:
    /// 74
    /// 10
    /// 1094601
    /// 1082066
    /// 
    /// Explanation:
    /// 
    /// Testcase 1:
    ///     Required sum can be obtained as 9*0 + 8*2 + 7*4 + 6*5 which is equal to 74.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinimizeSumOfProductOfElements
    {
        /// <summary>
        /// The execution time is 0.55
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var half = n / 2;
                long sum = 0;
                for (var i = 0; i < half; i++)
                {
                    sum += numbers[i] * numbers[n - i - 1];
                }

                Console.WriteLine(sum);
            }
        }
    }
}