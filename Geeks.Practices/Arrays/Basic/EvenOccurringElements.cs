using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Even occurring elements"
    /// 
    /// Given an array that contains odd number of occurrences for all numbers except for a few elements which are present even number of times.
    /// Find the elements which have even occurrences in the array in O(n) time complexity and O(1) extra space.
    /// 
    /// Note: In some array, array contains only odd number then you have to print only a blank new line.
    /// 
    /// Input:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of two lines.
    /// The first line of each test case consists of an integer N, where N is the size of array.
    /// The second line of each test case contains N space separated integers denoting array elements.
    /// 
    /// Output:
    /// Corresponding to each test case, in a new line, print the elements which have even occurrences in the array in sorted order.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 200
    /// 1 ≤ A[i] ≤ 63
    /// 
    /// Example:
    /// Input
    /// 5
    /// 11
    /// 9 12 23 10 12 12 15 23 14 12 15
    /// 5
    /// 23 12 56 34 32
    /// 4
    /// 10 34 10 56
    /// 30
    /// 11 62 16 21 2 8 31 25 9 30 23 47 7 6 59 47 63 3 10 33 12 22 15 12 25 62 15 54 29 49 
    /// 5
    /// 28 26 14 35 43
    /// 
    /// Output
    /// 12 15 23
    /// (Empty line)
    /// 10
    /// 12 15 25 47 62
    /// (Empty line)
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class EvenOccurringElements
    {
        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunCompareToMix()
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
                Console.WriteLine(string.Join(' ', numbers.GroupBy(x => x).Where(x => (x.Count() & 1) == 0).Select(x => x.Key).OrderBy(x => x)));
            }
        }

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
                // var n = int.Parse(test[0]); Skip the number of elements
                var numbers = new int[63];
                var scanner = new StringScanner(test[1]);
                while (scanner.HasNext)
                {
                    numbers[scanner.NextPositiveInt() - 1]++;
                }

                Console.WriteLine(string.Join(' ', numbers.Select((x, i) => (x & 1) == 0 && x > 0 ? i + 1 : 0).Where(x => x > 0)));
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
                // var n = int.Parse(test[0]); Skip the number of elements
                var numbers = new int[63];
                var scanner = new StringScanner(test[1]);
                while (scanner.HasNext)
                {
                    numbers[scanner.NextPositiveInt() - 1]++;
                }

                var resultBuilder = new StringBuilder();
                for (var i = 0; i < 64; i++)
                {
                    if (numbers[i] > 0 && (numbers[i] & 1) == 0)
                    {
                        resultBuilder.AppendFormat("{0} ", i + 1);
                    }
                }

                Console.WriteLine(resultBuilder.ToString());
            }
        }
    }
}