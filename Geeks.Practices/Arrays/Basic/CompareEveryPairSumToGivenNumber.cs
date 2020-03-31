using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Permutations in array"
    /// 
    /// Given two arrays of equal size N and an integer K.
    /// The task is to check if after permuting both arrays, we get sum of their corresponding element greater than or equal to k
    ///     i.e Ai + Bi >= K for i =0 to N-1.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains three lines.
    /// The first line of input contains two integers N and K.
    /// Then in the next two lines are space separated elements of the array A and B.
    /// 
    /// Output:
    /// For each test case, print "1" (without quotes) if sum is possible(for whole array) else "0" (without quotes).
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <=103
    /// 1 <= K <= 10e7
    /// 1 <= Ai, Bi<= 10e18
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 3 10
    /// 2 1 3
    /// 7 8 9
    /// 4 5
    /// 1 2 2 1
    /// 3 3 3 4
    /// 4 87
    /// 28 116 144 86 
    /// 137 43 100 122 
    /// 3 28
    /// 141 110 114 
    /// 77 91 127
    /// 
    /// Output:
    /// 1
    /// 0
    /// 1
    /// 1
    /// 
    /// Explanation:
    /// Testcase 1:
    /// K=10 here.
    /// A can be written as {1 2 3} and B can be written as {9 8 7} so that for all i A[i]+B[i]&gt;=K
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CompareEveryPairSumToGivenNumber
    {
        /// <summary>
        /// The execution time is 1.14
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var k = int.Parse(test[0].Split(' ')[1]);
                var leftList = test[1].Split(' ').Select(long.Parse).ToArray();
                var rightList = test[2].Split(' ').Select(long.Parse);
                Console.WriteLine(leftList.OrderBy(x => x).Zip(rightList.OrderByDescending(x => x), (x,y) => x+y).Any(x => x < k) ? 0 : 1);
            }
        }

        /// <summary>
        /// The execution time is 1.18
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                // var n = int.Parse(split[0]); Skip the number of elements
                var k = int.Parse(split[1]);
                var leftList = test[1].Split(' ').Select(long.Parse).OrderBy(x => x);
                var rightList = test[2].Split(' ').Select(long.Parse).OrderByDescending(x => x);
                Console.WriteLine(leftList.Zip(rightList, (x,y) => x+y).Any(x => x < k) ? 0 : 1);
            }
        }

        /// <summary>
        /// The execution time is 0.74
        /// * Array.Sort(...) won against OrderBy, again. 
        /// </summary>
        public static void RunCompareToMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var leftList = StringScanner.GetPositiveLong(test[1], n);
                var rightList = StringScanner.GetPositiveLong(test[2], n);
                Console.WriteLine(leftList.OrderBy(x => x).Zip(rightList.OrderByDescending(x => x), (x,y) => x+y).Any(x => x < k) ? 0 : 1);
            }
        }

        /// <summary>
        /// The execution time is 0.54
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var leftList = StringScanner.GetPositiveLong(test[1], n);
                var rightList = StringScanner.GetPositiveLong(test[2], n);
                Array.Sort(leftList);
                Array.Sort(rightList, (x,y) => y.CompareTo(x));
                Console.WriteLine(leftList.Zip(rightList, (x,y) => x+y).Any(x => x < k) ? 0 : 1);
            }
        }

        /// <summary>
        /// The execution time is 0.50
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var leftList = StringScanner.GetPositiveLong(test[1], n);
                var rightList = StringScanner.GetPositiveLong(test[2], n);
                Array.Sort(leftList);
                Array.Sort(rightList, (x,y) => y.CompareTo(x));
                var result = 1;
                for (var i = 0; i < n; i++)
                {
                    if (leftList[i] + rightList[i] >= k) continue;
                    result = 0;
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}