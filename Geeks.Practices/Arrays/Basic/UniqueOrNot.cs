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
    /// 100
    /// 712 291 146 707 561 680 563 506 704 441 476 699 559 446 294 536 361 496 529 510 521 157 560 407 199 713 567 162 417 529 154 197 349 378 16 282 27 142 368 330 240 186 606 77 329 148 486 338 654 747 440 564 159 735 310 443 14 413 80 183 546 80 442 547 702 651 21 679 276 610 369 203 326 61 256 182 503 168 477 598 583 440 635 525 674 72 650 433 365 283 375 34 78 132 43 562 242 36 719 221
    /// 
    /// Output
    /// GIRLS
    /// BOYS
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
        /// The execution time is 0.94
        /// * Compare this solution to RunAnother
        /// * The effect of OrderBy 
        /// </summary>
        public static void RunCompareToAnother()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new long[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(long.Parse).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Length > test.Distinct().Count() ? "BOYS" : "GIRLS");
            }
        }

        /// <summary>
        /// The execution time is 1.43
        /// </summary>
        public static void RunAnother()
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
                Console.WriteLine(test.Length > test.Distinct().Count() ? "BOYS" : "GIRLS");
            }
        }

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