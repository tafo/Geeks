using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ComTypes;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Max Odd Sum"
    /// 
    /// Given an array of integers, check whether there is a subsequence with odd sum and if yes, then finding the maximum odd sum.
    /// If no subsequence contains odd sum, print -1.
    /// 
    /// Input:
    /// First line of input contains a single integer T which denotes the number of test cases.
    /// Then T test cases follows.
    /// First line of each test case contains a single integer N which denotes the number of elements in the array.
    /// Second line of each test case contains N space separated integers.
    /// 
    /// Output:
    /// For each test case print the maximum odd sum that can be obtained from any subsequence of the given array.
    /// If no subsequence contains odd sum, print -1.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e4
    /// 1 <= A[i] <= 10e5
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 5
    /// 2 5 -4 3 -1
    /// 4
    /// 4 -3 3 -5
    /// 3
    /// 2 4 6
    /// 5
    /// 15 -182 244 233 -13 
    /// 14
    /// -175 26 225 216 152 222 172 -207 32 -44 -235 -140 -103 -118
    /// 
    /// Output:
    /// 9
    /// 7
    /// -1
    /// 479
    /// 1045
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaxOddSum
    {
        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine(); // Skip the number of elements
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var result = 0;
                var absoluteMinOdd = 100000;
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt();
                    if (number > 0)
                    {
                        result += number;
                    }

                    if ((number & 1) == 1)
                    {
                        absoluteMinOdd = Math.Min(absoluteMinOdd, Math.Abs(number));
                    }
                }

                if ((result & 1) == 0)
                {
                    if ((absoluteMinOdd & 1) == 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        result -= absoluteMinOdd;    
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}