using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Replace all 0's with 5"
    /// 
    /// You are given an integer N. You need to convert all zeroes of N to 5.
    /// 
    /// Input Format:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains a single integer N denoting the number.
    /// 
    /// Output Format:
    /// For each test case, there will be a new line containing an integer where all zero's are converted to 5.
    /// 
    /// Your Task:
    /// Your task is to complete the function convertFive() which takes an integer N as an argument and replaces all zeros in the number N with 5.
    /// Your function should return the converted number.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= n <= 10000
    /// 
    /// Example:
    /// Input
    /// 2
    /// 1004
    /// 121
    /// Ouput
    /// 1554
    /// 121
    /// Explanation:
    /// Test Case 1: There are two zeroes in "1004", on replacing all zeroes with 5, the new number will be 1554.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class ReplaceDigits
    {
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new int[t];

            for (var i = 0; i < t; i++)
            {
                input[i] = int.Parse(Console.ReadLine());
            }

            foreach (var number in input)
            {
                Console.WriteLine(ConvertFive(number));
            }
        }

        /// <summary>
        /// The execution time of equivalent JAVA function is 0.16
        ///     return Integer.valueOf(Integer.toString(num).replace('0', '5'));
        ///     OR
        ///     return Integer.parseInt(Integer.toString(num).replace('0', '5'));
        /// </summary>
        private static int ConvertFive(int number)
        {
            return int.Parse(number.ToString().Replace("0", "5"));
        }

        /// <summary>
        /// The execution time of equivalent JAVA function is 0.15
        /// </summary>
        private static int ConvertFive1(int number)
        {
            var result = 0;
            var factor = 1;

            while (number > 0)
            {
                var digit = number % 10;
                if (digit == 0)
                {
                    digit = 5;
                }

                result += factor * digit;
                factor *= 10;
                number /= 10;
            }

            return result;
        }
    }
}