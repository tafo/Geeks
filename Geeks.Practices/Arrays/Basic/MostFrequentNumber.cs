using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Maximum repeating number"
    /// 
    /// Given an array A of size N, the array contains numbers in range from 0 to k-1 where k is a positive integer and k <= N.
    /// Find the maximum repeating number in this array.
    /// If there are two or more maximum repeating numbers print the element having least value.
    /// 
    /// Input:
    /// The first line of input contains an integer T, denoting the number of test cases.
    /// T testcases follow.
    /// Each testcase contains two lines of input.
    /// First line contains N and k, both separated by a space. The next line contains N integers separated by spaces.
    /// 
    /// Output:
    /// For each testcase, in a new line, print the maximum frequency element.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 0 <= k <= N
    /// 0 <= Ai <= k-1
    /// 
    /// Example:
    /// Input:
    /// 
    /// 2
    /// 4 3
    /// 2 2 1 2
    /// 6 3
    /// 2 2 1 0 0 1
    /// Output:
    /// 2
    /// 0
    /// 
    /// Explanation:
    /// 
    /// Testcase1: 2 is the most frequent element.
    /// Testcase2: 0 1 and 2 all have same frequency of 2. But since 0 is smallest, we print that.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MostFrequentNumber
    {
        /// <summary>
        /// The execution time is 0.28
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
                var split = test[0].Split(' ');
                // var n = int.Parse(split[0]); Skip the number of elements
                var k = int.Parse(split[1]);
                var numbers = new int[k, 1];
                var scanner = new StringScanner(test[1]);
                while (scanner.HasNext)
                {
                    numbers[scanner.NextPositiveInt(), 0]++;
                }

                var most = 0;
                var mostNumber = k;
                for (var i = 0; i < k; i++)
                {
                    if (numbers[i, 0] <= most) continue;
                    most = numbers[i, 0];
                    mostNumber = i;
                }

                Console.WriteLine(mostNumber);
            }
        }
    }
}