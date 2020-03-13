using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Check if two arrays are equal or not"
    /// 
    /// Given two arrays A and B of equal size N, the task is to find if given arrays are equal or not.
    /// Two arrays are said to be equal if both of them contain same set of elements,
    ///     arrangements (or permutation) of elements may be different though.
    /// Note : If there are repetitions, then counts of repeated elements must also be same for two array to be equal.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the no of test cases.
    /// Then T test cases follow.
    /// Each test case contains 3 lines of input.
    ///     The first line contains an integer N denoting the size of the array.
    ///     The second line contains element of array A[].
    ///     The third line contains elements of the array B[].
    /// 
    /// Output:
    /// For each test case, print 1 if the arrays are equal else print 0.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10e7
    /// 1<=A[],B[]<=10e18
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 2 5 4 0
    /// 2 4 5 0 1
    /// 3
    /// 1 2 5
    /// 2 4 15
    /// 
    /// Output:
    /// 1
    /// 0
    /// 
    /// Explanation:
    /// Testcase1:
    /// Input : A[] = {1, 2, 5, 4, 0}; B[] = {2, 4, 5, 0, 1};
    /// Output : 1
    /// 
    /// Testcase2:
    /// Input : A[] = {1, 2, 5}; B[] = {2, 4, 15};
    /// Output : 0
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class Equality
    {
        /// <summary>
        /// The execution time is 0.45 !!!
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
                input[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var first = new long[n];
                var second = new long[n];
                var scanner = new StringScanner(testCase[1]);
                var i = 0;
                while (scanner.HasNext)
                {
                    first[i++] = scanner.NextPositiveInt64();
                }

                i = 0;
                scanner = new StringScanner(testCase[2]);
                while (scanner.HasNext)
                {
                    second[i++] = scanner.NextPositiveInt64();
                }

                var result = first.OrderBy(x => x).SequenceEqual(second.OrderBy(x => x));

                Console.WriteLine(result ? 1 : 0);
            }
        }

        /// <summary>
        /// The execution time is 0.56 :(
        /// </summary>
        internal static void Run2()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
                input[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var first = new long[n];
                var second = new long[n];
                var scanner = new StringScanner(testCase[1]);
                var i = 0;
                while (scanner.HasNext)
                {
                    first[i++] = scanner.NextPositiveInt64();
                }

                i = 0;
                scanner = new StringScanner(testCase[2]);
                while (scanner.HasNext)
                {
                    second[i++] = scanner.NextPositiveInt64();
                }

                Array.Sort(first);
                Array.Sort(second);

                var result = first.SequenceEqual(second);

                Console.WriteLine(result ? 1 : 0);
            }
        }

        /// <summary>
        /// The execution time is 0.76
        /// Remark >> Using StringScanner would be better
        /// </summary>
        internal static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
                input[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                // var n = int.Parse(testCase[0]); // Skip the number of elements
                var first = testCase[1].Split(' ').Select(long.Parse).OrderBy(x => x).ToArray();
                var result = testCase[2].Split(' ').Select(long.Parse).OrderBy(x => x).SequenceEqual(first);
                Console.WriteLine(result ? 1 : 0);
            }
        }

        /// <summary>
        /// The execution time is more than 6 seconds
        ///     >> Run away
        ///     >> Compare with Run1
        ///         >> Parsing is better
        /// </summary>
        internal static void RunAway()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
                input[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                // var n = int.Parse(testCase[0]); // Skip the number of elements
                var first = testCase[1].Split(' ').OrderBy(x => x).ToArray();
                var result = testCase[2].Split(' ').OrderBy(x => x).SequenceEqual(first);
                Console.WriteLine(result ? 1 : 0);
            }
        }
    }
}