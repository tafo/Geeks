﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// How many pizzas?
    /// 
    /// You are given two stacks of pizzas.
    /// You can only take those pizzas from one stack that are also present in the other stack, in the same order.
    /// The pizzas that you can take need not be continuous.
    /// Print the maximum amount of pizzas that you can take. (You can only take pizzas from one of the two stacks)
    /// 
    /// INPUT:
    /// The first line contains only one integer, t, the number of test cases.
    /// For each case, there are two lines: 
    /// Line 1: 10 integers, which represent radii of the pizzas in the first stack.
    /// Line 2: 10 integers, each of which represent radii of pizzas in the second stack.
    /// 
    /// OUTPUT:
    /// For each case, a single integer that gives the maximum amount of pizzas that you can take.
    /// 
    /// Constraints:
    /// 
    /// 1<=T<=100
    /// 1<=radii<=1000
    /// 
    /// Example:
    /// Input:
    /// 1
    /// 891 424 945 741 897 514 692 221 678 168
    /// 702 952 221 614 69 753 821 971 318 364
    /// 
    /// Output:
    /// 1
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountSameNumbers
    {
        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunAnotherCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var left = test[0].Split(' ').Select(int.Parse);
                var right = test[1].Split(' ').Select(int.Parse);
                Console.WriteLine(right.Count(x => left.Contains(x)));
            }
        }

        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void RunCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var left = test[0].Split(' ').Select(int.Parse);
                var right = test[1].Split(' ').Select(int.Parse);
                Console.WriteLine(right.Count(x => left.Any(y => x == y)));
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var numbers = test[0].Split(' ').Select(int.Parse);
                Console.WriteLine(test[1].Split(' ').Select(int.Parse).Count(x => numbers.Any(y => x == y)));
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
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var left = StringScanner.GetPositiveInt(test[0], 10);
                var right = StringScanner.GetPositiveInt(test[1], 10);
                Console.WriteLine(left.Count(x => right.Any(y => x == y)));
            }
        }

        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var numbers = StringScanner.GetPositiveInt(test[0], 10);
                var counter = 0;
                var scanner = new StringScanner(test[1]);
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    for (var i = 0; i < 10; i++)
                    {
                        if (number != numbers[i]) continue;
                        counter++;
                        break;
                    }
                }

                Console.WriteLine(counter);
            }
        }
    }
}