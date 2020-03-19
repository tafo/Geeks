using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Professor and Parties"
    /// 
    /// A professor went to a party.
    /// Being an erudite person, he classified the party into two categories.
    /// He proposed that if all the persons in the party are wearing different colored robes, then that is a girl’s only party.
    ///     * REMARK: "the persons" should be "people"
    /// If we even get one duplicate color, it must be a boy’s party.
    /// The colors of the robes are represented by positive integers.
    /// 
    /// Input
    /// The first line of each test case contains an integer T, denoting the no of test cases.
    /// Then T test cases follow.
    /// The first line of each test case contains an integer N denoting the number of people in the party.
    /// In the next line are N space separated values of Ai denoting the color of the robes.
    /// 
    /// Output
    /// For each test case, print “BOYS” without quotes if it’s a boy’s party, else print “GIRLS”.
    /// 
    /// Constraints
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= Ai <= 10e18
    /// 
    /// Example
    /// Input
    /// 2
    /// 5
    /// 1 2 3 4 7
    /// 6
    /// 1 3 2 4 5 1
    /// 
    /// Output
    /// GIRLS
    /// BOYS
    /// 
    /// Explanation:
    /// In the first testcase, all the colors are unique so it's a GIRLS party.
    /// In the second testcase, there are two colors 1. So it's a BOYS party.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class UniqueOrNot
    {
        /// <summary>
        /// The execution time is 1.27
        /// * Interesting!
        /// * Compare this solution with RunLinq
        /// </summary>
        public static void RunLinqCompare()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new long[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(long.Parse).OrderBy(x => x).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Skip(1).Where((x, i) => x == test[i]).Any() ? "BOYS" : "GIRLS");
            }
        }

        /// <summary>
        /// The execution time is 1.30
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new long[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(long.Parse).OrderBy(x => x).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Where((x, i) => i > 0 && x == test[i - 1]).Any() ? "BOYS" : "GIRLS");
            }
        }

        /// <summary>
        /// The execution time is 0.54
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
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositive(test[1], n);
                Array.Sort(numbers);
                var result = "GIRLS";
                for (var i = 1; i < n; i++)
                {
                    if (numbers[i] != numbers[i - 1]) continue;
                    result = "BOYS";
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}