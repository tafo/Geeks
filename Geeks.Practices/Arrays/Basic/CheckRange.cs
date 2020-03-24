using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Elements in the Range"
    /// 
    /// An array containing positive elements is given.
    /// 'A' and 'B' are two numbers defining a range.
    /// Write a function to check if the array contains all elements in the given range.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains space separated integers n, A and B which denotes the number of elements in the array a[] and the range [A, B].
    /// Next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Print "Yes" if all the elements in the range are present else print "No".
    /// 
    /// Constraints:
    /// 1 <= T <=100
    /// 1 <= n <=1000
    /// 1 <= A < B <=1000
    /// 1 <= a[i] <=1000​
    /// 
    /// Example:
    /// 
    /// Input:
    /// 1
    /// 7 2 5
    /// 1 4 5 2 7 8 3
    /// 
    /// Output:
    /// Yes
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CheckRange
    {
        /// <summary>
        /// The execution time is 0.16
        /// </summary>
        public static void RunCompareToLinq()
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
                var a = int.Parse(split[1]);
                var b = int.Parse(split[2]);
                Console.WriteLine(test[1].Split(' ').Select(int.Parse).OrderBy(x => x).SkipWhile(x => x < a).TakeWhile(x => x <= b).Count() == b - a + 1 ? "Yes" : "No");
            }
        }

        /// <summary>
        /// The execution time is 0.17
        /// </summary>
        public static void RunLinq()
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
                var a = int.Parse(split[1]);
                var b = int.Parse(split[2]);
                Console.WriteLine(test[1].Split(' ').Select(int.Parse).OrderBy(x => x).Count(x => x >= a && x <= b) == b - a + 1 ? "Yes" : "No");
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var a = int.Parse(split[1]);
                var b = int.Parse(split[2]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Console.WriteLine(numbers.Count(x => x >= a && x <= b) == b - a + 1 ? "Yes" : "No");
            }
        }

        /// <summary>
        /// The execution time is 0.13
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
                var a = int.Parse(split[1]);
                var b = int.Parse(split[2]);
                var count = b - a + 1;
                var range = new bool[count];
                var scanner = new StringScanner(test[1]);

                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number >= a && number <= b)
                    {
                        range[number - a] = true;
                    }
                }

                var result = "Yes";
                for (var i = 0; i < count; i++)
                {
                    if (range[i]) continue;
                    result = "No";
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}