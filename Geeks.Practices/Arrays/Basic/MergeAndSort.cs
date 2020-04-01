using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Merge and Sort"
    /// 
    /// Input N number of arrays and print the merged array in ascending order containing only unique elements.
    /// 
    /// Input:
    /// The first line consists of T test cases
    /// And then next line consists of number of arrays denoted by N
    /// And then next of each N lines contain a number n denoting the number of elements in an array.
    /// 
    /// Output:
    /// Output in one line the merged array sorted in ascending order.
    /// 
    /// Constraints:
    /// 1<=T<=50
    /// 1<=N<=4
    /// 1<=Ai<=100
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 3
    /// 3
    /// 1 2 8
    /// 2
    /// 4 9
    /// 3
    /// 1 2 8
    /// 4
    /// 20 
    /// 17 34 18 23 8 5 3 37 8 36 33 36 6 4 5 23 5 12 3 32 
    /// 11
    /// 37 1 36 38 7 42 1 23 2 31 40 
    /// 16
    /// 38 8 6 26 9 12 10 21 3 40 33 6 27 42 36 8 
    /// 26
    /// 42 26 3 26 25 33 10 3 16 2 37 41 19 12 9 4 2 30 35 22 9 10 3 7 10 8 
    /// 4
    /// 7
    /// 4 7 2 4 17 3 11 
    /// 2
    /// 4 30 
    /// 13
    /// 7 10 6 10 40 4 6 11 8 40 7 5 8 
    /// 4
    /// 8 41 8 26
    /// 
    /// Output:
    /// 1 2 4 8 9
    /// 1 2 3 4 5 6 7 8 9 10 12 16 17 18 19 21 22 23 25 26 27 30 31 32 33 34 35 36 37 38 40 41 42
    /// 2 3 4 5 6 7 8 10 11 17 26 30 40 41
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MergeAndSort
    {
        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];
            for (var i = 0; i < testCount; i++)
            {
                var s = int.Parse(Console.ReadLine());
                while (s > 0)
                {
                    Console.ReadLine();
                    tests[i] += Console.ReadLine().TrimEnd() + " ";
                    s--;
                }
            }

            foreach (var test in tests)
            {
                Console.WriteLine(string.Join(' ', test.TrimEnd().Split(' ').Select(int.Parse).Distinct().OrderBy(x => x)));
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunCompareToMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][][];
            for (var i = 0; i < testCount; i++)
            {
                var s = int.Parse(Console.ReadLine());
                tests[i] = new string[s][];
                for (var a = 0; a < s; a++)
                {
                    tests[i][a] = new string[2];
                    tests[i][a][0] = Console.ReadLine();
                    tests[i][a][1] = Console.ReadLine().TrimEnd();
                }
            }

            foreach (var test in tests)
            {
                var size = test.Sum(array => int.Parse(array[0]));
                var merged = test.Aggregate(string.Empty, (current, array) => current + array[1] + " ");
                Console.WriteLine(string.Join(' ', StringScanner.GetPositiveInt(merged.TrimEnd(), size).Distinct().OrderBy(x => x)));
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][][];
            for (var i = 0; i < testCount; i++)
            {
                var s = int.Parse(Console.ReadLine());
                tests[i] = new string[s][];
                for (var a = 0; a < s; a++)
                {
                    tests[i][a] = new string[2];
                    tests[i][a][0] = Console.ReadLine();
                    tests[i][a][1] = Console.ReadLine().TrimEnd();
                }
            }

            foreach (var test in tests)
            {
                var size = test.Sum(array => int.Parse(array[0]));
                var merged = test.Aggregate(string.Empty, (current, array) => current + array[1] + " ");
                var numbers = StringScanner.GetPositiveInt(merged.TrimEnd(), size);
                Array.Sort(numbers);
                Console.WriteLine(string.Join(' ', numbers.Distinct()));
            }
        }

        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][][];
            for (var i = 0; i < testCount; i++)
            {
                var s = int.Parse(Console.ReadLine());
                tests[i] = new string[s][];
                for (var a = 0; a < s; a++)
                {
                    tests[i][a] = new string[2];
                    tests[i][a][0] = Console.ReadLine();
                    tests[i][a][1] = Console.ReadLine().TrimEnd();
                }
            }

            foreach (var test in tests)
            {
                var size = 0;
                var merged = string.Empty;
                for (var a = 0; a < test.Length; a++)
                {
                    size += int.Parse(test[a][0]);
                    merged += test[a][1] + " ";
                }

                var numbers = StringScanner.GetPositiveInt(merged.TrimEnd(), size);
                Array.Sort(numbers);
                var distinctCounter = 1;
                var left = numbers[0];
                for (var a = 1; a < size; a++)
                {
                    if (numbers[a] == left)
                    {
                        continue;
                    }

                    left = numbers[distinctCounter++] = numbers[a];
                }

                var result = new int[distinctCounter];
                Array.Copy(numbers, result, distinctCounter);

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}