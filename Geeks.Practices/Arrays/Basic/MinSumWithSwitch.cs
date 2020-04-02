using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "A guy with a mental problem"
    /// 
    /// A guy has to reach his home and does not want to be late.
    /// He takes train to reach home.
    /// He has a mental illness, so he always switches train at every station.
    /// For eg: If he starts with train A then at station 2 he will switch his train to train B and so on.
    /// Similarly, if he starts with train B then he will switch to train A at station 2 and so on.
    /// Please help him to find the minimum total time he would take to reach his home.
    /// 
    /// Input:
    /// The first line of the input contains an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains three lines of input.
    /// The first line contains a positive integer N - the number of tasks to be completed.
    /// The second line contains N space-separated positive integers representing the time taken in seconds by train A to reach next Stations.
    /// The third line contains N space-separated positive integers representing the time taken in seconds by train B to reach next Stations.
    /// 
    /// Output:
    /// For each test case, print the minimum total time in seconds to reach home.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= Ai, Bi <= 10e10
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 3
    /// 2 1 2
    /// 3 2 1
    /// 7
    /// 196 640 950 121 968 227 764 
    /// 678 597 982 866 561 37 956
    /// 
    /// Output:
    /// 5
    /// 4165
    /// 
    /// Explanation:
    /// Testcase1:
    /// If he chose train A initially, then time to reach home will be : 2 + 2 + 2 = 6 
    /// If he Chose train B initially, then time to reach home will be : 3 + 1 + 1 = 5
    /// 5 is minimum hence the answer.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinSumWithSwitch
    {
        /// <summary>
        /// The execution time is 0.89
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());

            while (testCount-- > 0)
            {
                Console.ReadLine();
                var left = Console.ReadLine().TrimEnd().Split(' ').Select(long.Parse).ToArray();
                var right = Console.ReadLine().TrimEnd().Split(' ').Select(long.Parse).ToArray();
                var leftSum = left.Where((x, i) => (i & 1) == 0).Concat(right.Where((x, i) => (i & 1) == 1)).Sum();
                var rightSum = left.Where((x, i) => (i & 1) == 1).Concat(right.Where((x, i) => (i & 1) == 0)).Sum();
                Console.WriteLine(Math.Min(leftSum, rightSum));
            }
        }

        /// <summary>
        /// The execution time is 0.37
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());

            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var left = StringScanner.GetPositiveLong(Console.ReadLine().TrimEnd(), n);
                var right = StringScanner.GetPositiveLong(Console.ReadLine().TrimEnd(), n);
                var leftSum = left.Where((x, i) => (i & 1) == 0).Concat(right.Where((x, i) => (i & 1) == 1)).Sum();
                var rightSum = left.Where((x, i) => (i & 1) == 1).Concat(right.Where((x, i) => (i & 1) == 0)).Sum();
                Console.WriteLine(Math.Min(leftSum, rightSum));
            }
        }

        /// <summary>
        /// The execution time is 0.32
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());

            while (testCount-- > 0)
            {
                Console.ReadLine(); // Skip the number of elements
                var leftScanner = new StringScanner(Console.ReadLine().TrimEnd());
                var rightScanner = new StringScanner(Console.ReadLine().TrimEnd());
                var flag = true;
                long leftSum = 0;
                long rightSum = 0;
                while (leftScanner.HasNext)
                {
                    if (flag)
                    {
                        leftSum += leftScanner.NextPositiveLong();
                        rightSum += rightScanner.NextPositiveLong();
                    }
                    else
                    {
                        rightSum += leftScanner.NextPositiveLong();
                        leftSum += rightScanner.NextPositiveLong();
                    }

                    flag = !flag;
                }

                Console.WriteLine(Math.Min(leftSum, rightSum));
            }
        }
    }
}