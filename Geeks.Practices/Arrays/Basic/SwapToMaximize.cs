using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Swap and Maximize"
    /// 
    /// Given an array of n elements.
    /// Consider array as circular array i.e element after an is a1.
    /// The task is to find maximum sum of the difference between consecutive elements with rearrangement of array element allowed
    ///     i.e after rearrangement of element find |a1 – a2| + |a2 – a3| + …… + |an – 1– an| + |an – a1|.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains the number of elements in the array a[] as n and next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Print an integer which denotes the maximized sum.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=10000
    /// 1<=a[i]<=100000​
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 4
    /// 4 2 1 8
    /// 3
    /// 10 12 15​
    /// 
    /// Output:
    /// 18​
    /// 10
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SwapToMaximize
    {
        /// <summary>
        /// The execution time is 0.48
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
                var n = int.Parse(test[0]);
                var numbers = test[1].Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
                var half = n / 2;
                for (var i = 1; i < half; i += 2)
                {
                    var temp = numbers[i];
                    numbers[i] = numbers[n - i - 1];
                    numbers[n - i - 1] = temp;
                }

                Console.WriteLine(numbers.Skip(1).Select((x, i) => Math.Abs(x - numbers[i])).Sum() + Math.Abs(numbers[0] - numbers[n - 1]));
            }
        }

        /// <summary>
        /// The execution time is 0.22
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var half = n / 2;
                for (var i = 1; i < half; i += 2)
                {
                    var temp = numbers[i];
                    numbers[i] = numbers[n - i - 1];
                    numbers[n - i - 1] = temp;
                }

                Console.WriteLine(numbers.Skip(1).Select((x, i) => Math.Abs(x - numbers[i])).Sum() + Math.Abs(numbers[0] - numbers[n - 1]));
            }
        }

        /// <summary>
        /// The execution time is 0.21
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
                var half = n / 2;
                for (var i = 1; i < half; i += 2)
                {
                    var temp = numbers[i];
                    numbers[i] = numbers[n - i - 1];
                    numbers[n - i - 1] = temp;
                }

                var sum = Math.Abs(numbers[0] - numbers[n - 1]);
                for (var i = 1; i < n; i++)
                {
                    sum += Math.Abs(numbers[i] - numbers[i - 1]);
                }

                Console.WriteLine(sum);
            }
        }
    }
}