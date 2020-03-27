using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Maximum Perimeter of Triangle from array"
    /// 
    /// Given an Array of non-negative integers.
    /// Find out the maximum perimeter of the triangle from the array.
    /// 
    /// Input:
    /// The first line contains an integer T, the number of test cases.
    /// For each test case, the first line contains an integer n, the size of the array. Next line contains n- space separated integers.
    /// 
    /// Output:
    /// For each test case, the output is an integer displaying the maximum perimeter if the triangle is possible else print -1.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 3 <= n <= 100
    /// 1 <= a[] <=100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6
    /// 6 1 6 5 8 4
    /// 7
    /// 7 55 20 1 4 33 12
    /// 
    /// Output:
    /// 20
    /// -1
    /// 
    /// Explanation:
    /// 1. Triangle formed by  8, 6 & 6. Thus perimeter 20.
    /// 2. As the triangle is not possible because the condition: the sum of two sides should be greater than third is not fulfilled here.
    ///
    /// Remark:
    /// 1) Even if the problem statement has a constraint as "3<=n<=100", there is at least one test case with n=1 !!!
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaxPerimeter
    {
        /// <summary>
        /// The execution time is 0.13
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
                int result;
                if (n < 3)
                {
                    result = -1;
                }
                else
                {
                    var numbers = StringScanner.GetPositiveInt(test[1], n);
                    Array.Sort(numbers, (x, y) => y.CompareTo(x));
                    result = numbers.SkipLast(2).Select((x, i) => x < numbers[i + 1] + numbers[i + 2] ? x + numbers[i + 1] + numbers[i + 2] : -1)
                        .Max();

                }

                Console.WriteLine(result);
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers, (x, y) => y.CompareTo(x));
                var result = -1;
                for (var i = 0; i < n - 2; i++)
                {
                    if (numbers[i] >= numbers[i + 1] + numbers[i + 2]) continue;
                    result = numbers[i] + numbers[i + 1] + numbers[i + 2];
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}