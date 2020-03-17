using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "First and last occurrences of X"
    /// 
    /// Given a sorted array with possibly duplicate elements,
    ///     the task is to find indexes of first and last occurrences of an element x in the given array.
    /// 
    /// Note: If the number x is not found in the array just print '-1'.
    /// 
    /// Input:
    /// The first line consists of an integer T i.e number of test cases.
    /// The first line of each test case contains two integers n and x.
    /// The second line contains n spaced integers.
    /// 
    /// Output:
    /// Print index of the first and last occurrences of the number x with a space in between.
    /// 
    /// Constraints: 
    /// 1<=T<=100
    /// 1<=n,a[i]<=1000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 9 5
    /// 1 3 5 5 5 5 67 123 125
    /// 9 7
    /// 1 3 5 5 5 5 7 123 125
    /// 
    /// Output:
    /// 2 5
    /// 6 6
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class IndexOfAndLastIndexOf
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunAway()
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
                // var n = ... Skip the number of elements
                var key = test[0].Split(' ')[1];
                var numbers = test[1].Split(' ');
                var indexOf = Array.IndexOf(numbers, key);
                if (indexOf == -1)
                {
                    Console.WriteLine("-1");
                }
                else
                {
                    Console.WriteLine("{0} {1}", indexOf, Array.LastIndexOf(numbers, key));
                }
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunThis()
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
                var key = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var indexOf = Array.IndexOf(numbers, key);
                if (indexOf == -1)
                {
                    Console.WriteLine("-1");
                }
                else
                {
                    Console.WriteLine("{0} {1}", indexOf, Array.LastIndexOf(numbers, key));
                }
            }
        }

        /// <summary>
        /// The execution time is 0.12
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
                // var n = ... Skip the number of elements
                var key = int.Parse(test[0].Split(' ')[1]);
                var numbers = test[1].Split(' ').Select(int.Parse).ToArray();
                var indexOf = Array.IndexOf(numbers, key);
                if (indexOf == -1)
                {
                    Console.WriteLine("-1");
                }
                else
                {
                    Console.WriteLine("{0} {1}", indexOf, Array.LastIndexOf(numbers, key));
                }
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
                // var n = ... Skip the number of elements
                var key = int.Parse(test[0].Split(' ')[1]);
                var scanner = new StringScanner(test[1]);
                var i = 0;
                var indexOf = -1;
                var lastIndexOf = -1;
                while (scanner.HasNext)
                {
                    if (scanner.NextPositiveInt() == key)
                    {
                        if (indexOf == -1)
                        {
                            indexOf = lastIndexOf = i;
                        }
                        else
                        {
                            lastIndexOf = i;
                        }
                    }

                    i++;
                }
                Console.WriteLine(indexOf == -1 ? "-1" : $"{indexOf} {lastIndexOf}");
            }
        }
    }
}