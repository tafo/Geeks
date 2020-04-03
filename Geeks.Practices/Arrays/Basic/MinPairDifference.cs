using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimum Difference among K"
    /// 
    /// Given an array of n integers and a positive number k.
    /// We are allowed to take any k integers from the given array.
    /// The task is to find the minimum possible value of the difference between maximum and minimum of k numbers.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains two integers n and k where n denotes the number of elements in the array a[].
    /// Next line contains space separated n elements in the array a[].​
    /// 
    /// Output:
    /// Print an integer which denotes the minimum difference achieved.
    /// 
    /// Constraints:
    /// 1<=T<=50
    /// 1<=n<=1000
    /// 1<=a[i]<=100000
    /// 1<=k<=1000​
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 7 3
    /// 10 100 300 200 1000 20 30
    /// 10 4
    /// 1 2 3 4 10 20 30 40 100 200
    /// 
    /// Output:
    /// 20
    /// 3
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinPairDifference
    {
        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var input = Console.ReadLine().TrimEnd();
                // var n = int.Parse(split[0]); Skip the number of elements
                var k = int.Parse(split[1]);
                var numbers = input.Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
                Console.WriteLine(numbers.Skip(k - 1).Select((x, i) => x - numbers[i]).Min());
            }
        }

        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var input = Console.ReadLine().TrimEnd();
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(input, n);
                Array.Sort(numbers);
                var min = numbers[k - 1] - numbers[0];
                for (var i = k; i < n; i++)
                {
                    min = Math.Min(min, numbers[i] - numbers[i - k + 1]);
                }

                Console.WriteLine(min);
            }
        }
    }
}