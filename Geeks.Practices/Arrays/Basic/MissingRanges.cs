using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Missing ranges of numbers"
    /// 
    /// Given an array of N positive integers, print out the missing elements (if any) in the range 0 to max of Ai.
    /// If there are more than one missing, collate them using hyphen ( - ).
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// The first line of each test case contains a positive integer N, denoting the length of the array.
    /// The second line of each test case contains N space separated positive integers.
    /// 
    /// Output:
    /// Print out the range of missing numbers.
    /// If no element is missing, print "-1" (without quotes).
    /// 
    /// Constraints
    /// 1 <= T <= 100
    /// 0 < N <= 10000000
    /// 0 <= Ai < 10000000
    /// 
    /// Examples:
    /// 
    /// Input
    /// 5
    /// 5
    /// 62 8 34 5 332 
    /// 4
    /// 13 0 32 500
    /// 5
    /// 2 0 9 15 999
    /// 13
    /// 467 334 500 169 724 478 358 962 464 705 145 281 827 
    /// 15
    /// 491 995 942 827 436 391 604 902 153 292 382 421 716 718 895
    /// 
    /// Output
    /// 0-4 6-7 9-33 35-61 63-331 
    /// 1-12 14-31 33-499 
    /// 1 3-8 10-14 16-998 
    /// 0-144 146-168 170-280 282-333 335-357 359-463 465-466 468-477 479-499 501-704 706-723 725-826 828-961 
    /// 0-152 154-291 293-381 383-390 392-420 422-435 437-490 492-603 605-715 717 719-826 828-894 896-901 903-941 943-994 
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MissingRanges
    {
        /// <summary>
        /// The execution time is 0.86
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
                var numbers = StringScanner.GetPositiveInt(test[1], n).Prepend(-1).ToArray();
                Array.Sort(numbers);
                Console.WriteLine(string.Join(' ',
                    numbers.Skip(1).Select((x, i) => x - numbers[i] == 2 ? $"{x - 1}" : x - numbers[i] > 2 ? $"{numbers[i] + 1}-{x - 1}" : "")
                        .Where(x => !string.IsNullOrEmpty(x)).DefaultIfEmpty("-1")));
            }
        }

        /// <summary>
        /// The execution time is 0.70
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var resultBuilder = new StringBuilder();
                var left = -1;
                for (var i = 0; i < n; i++)
                {
                    var dif = numbers[i] - left;
                    switch (dif)
                    {
                        case 0:
                        case 1:
                            break;
                        case 2:
                            resultBuilder.AppendFormat("{0} ", left + 1);
                            break;
                        default:
                            resultBuilder.AppendFormat("{0}-{1} ", left + 1, numbers[i] - 1);
                            break;
                    }

                    left = numbers[i];
                }

                var result = resultBuilder.ToString();
                Console.WriteLine(result.Length == 0 ? "-1" : result);
            }
        }
    }
}