using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Array of alternate +ve and -ve no.s"
    /// 
    /// Given an unsorted array of positive and negative numbers.
    /// Your task is to create an array of alternate positive and negative numbers
    ///     without changing the relative order of positive and negative numbers.
    /// 
    /// Input:
    /// First line of input contains an integer T denoting the number of test cases.
    /// For each test case, first line contains N, size of array.
    /// The subsequent line contains N array elements.
    /// 
    /// Output:
    /// Print the modified array.
    /// Note: Array should start with positive number.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 10e7
    /// -106 ≤ a[i] ≤ 10e7
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 9
    /// 9 4 -2 -1 5 0 -5 -3 2
    /// 6
    /// 3 2 1 -1 -2 -3
    /// 6
    /// -3 -2 -1 1 2 3
    /// 
    /// Output:
    /// 9 -2 4 -1 5 -5 0 -3 2
    /// 3 -1 2 -2 1 -3
    /// 1 -3 2 -2 3 -1
    ///
    /// Remark:
    /// Positive numbers precede negative ones. 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public class AlternateComparison
    {
        /// <summary>
        /// The execution time is 0.66
        /// </summary>
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = new int[n];
                var scanner = new StringScanner(testCase[1]);
                var index = 0;
                var flag = true;
                var backup = new int[n];
                var backupIndex = 0;
                var counter = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt();
                    if (flag && number >= 0 || !flag && number < 0)
                    {
                        elements[index++] = number;
                        if (backupIndex < counter)
                        {
                            elements[index++] = backup[backupIndex];
                            backupIndex++;
                            continue;
                        }
                    }
                    else
                    {
                        backup[counter] = number;
                        counter++;
                        continue;
                    }

                    flag = !flag;
                }

                while (backupIndex < counter)
                {
                    elements[index++] = backup[backupIndex++];
                }

                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// The execution time is 1.20
        /// </summary>
        public static void Run2()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                // var n = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ').Select(int.Parse).ToArray();
                var positiveElements = elements.Where(x => x >= 0).ToArray();
                var negativeElements = elements.Where(x => x < 0).ToArray();
                var index = 0;
                foreach (var element in positiveElements)
                {
                    elements[index++] = element;
                    if (index / 2 < negativeElements.Length)
                    {
                        elements[index] = negativeElements[index / 2];
                        index++;
                    }
                }

                for (var i = index / 2; i < negativeElements.Length; i++)
                {
                    elements[index++] = negativeElements[i];
                }

                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// The execution time is 1.24
        /// </summary>
        public static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                // var n = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ').Select(int.Parse).ToArray();
                var positiveElements = elements.Where(x => x >= 0).ToArray();
                var negativeElements = elements.Where(x => x < 0).ToArray();
                elements = positiveElements.Interleave(negativeElements).ToArray();
                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// * Just for fun
        /// Time Limit Exceeded
        /// Expected Time Limit < 4.12sec
        /// </summary>
        public static void RunAway()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ').Select(int.Parse).ToArray();
                var flag = elements[0] > 0;
                for (var i = 1; i < n - 1; i++)
                {
                    var k = i;
                    while ((flag && elements[k] >= 0 || !flag && elements[k] < 0) && ++k < n) { }

                    if (k == n)
                    {
                        break;
                    }

                    if (k > i)
                    {
                        var temp = elements[k];
                        do
                        {
                            elements[k] = elements[k - 1];
                        } while (--k > i);

                        elements[i] = temp;
                    }

                    flag = !flag;
                }

                Console.WriteLine(string.Join(' ', elements));
            }
        }
    }
}