using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Stuffs Division"
    /// 
    /// Your are given N students with some goodies to be distributed among them such that student at ith index gets exactly i amount of goodies.
    /// The goodies has already been distributed by some other.
    /// Your task is to check if it can be redistributed such that student at ith index gets i amount of goodies.
    /// 
    /// Input:
    /// First line of input denotes the number of test cases T.
    /// The first line of each test case contains one integer N, denoting the number of students.
    /// The second line of each test case contains N integers each Ai, denoting the number of goodies distributed to ith member.
    /// 
    /// Output:
    /// Print "YES" if we can redistribute in the required way, otherwise "NO" (without quotes).
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= Ai <= 10e18
    /// 
    /// Examples:
    /// Input:
    /// 3
    /// 5
    /// 7 4 1 1 2
    /// 5
    /// 1 1 1 1 1
    /// 7
    /// 7 7 7 1 1 2 3
    /// 
    /// Output:
    /// YES
    /// NO
    /// YES
    /// 
    /// Explanation:
    /// Testcase 1: Since, all the goods can be redistributed as 1 2 3 4 5 (ith students get i number of goodies). So, output is YES.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CheckValueSumIsEqualToPositionSum
    {
        /// <summary>
        /// The execution time is 0.30
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
                var n = long.Parse(test[0]);
                var scanner = new StringScanner(test[1]);
                long sum = 0;
                while (scanner.HasNext)
                {
                    sum += scanner.NextPositiveLong();
                }

                Console.WriteLine(sum == n * (n + 1) / 2 ? "YES" : "NO");
            }
        }
    }
}