using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Count number of elements between two given elements in array"
    /// 
    /// Given an unsorted array and two elements num1 and num2.
    /// The task is to count the number of elements occurs between the given elements (excluding num1 and num2).
    /// If there are multiple occurrences of num1 and num2, we need to consider leftmost occurrence of num1 and rightmost occurrence of num2.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of three lines.
    /// First line of each test case contains an Integer N denoting size of array,
    /// Second line contains N space separated array elements
    /// And third line contains two elements num1 and num2.
    /// 
    /// Output:
    /// For each test case, print the count in new line.
    /// 
    /// Constraints:
    /// 1<=T<=200
    /// 2<=N<=10e5
    /// 1<=A[i],num1,num2<=10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 4
    /// 5
    /// 4 2 1 10 6
    /// 4 6
    /// 4
    /// 3 2 1 4
    /// 2 4
    /// 9
    /// 3 5 7 6 3 9 12 4 6
    /// 5 4
    /// 33
    /// 30 4 20 71 69 9 16 41 50 97 24 19 46 47 52 22 56 80 89 65 29 42 51 94 1 35 65 25 15 88 57 44 92 
    /// 4 41
    /// 
    /// Output:
    /// 3
    /// 1
    /// 5
    /// 5
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountElementsBetweenGivenNumbers
    {
        /// <summary>
        /// The execution time is 0.32
        /// </summary>
        public static void RunCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                Console.ReadLine();
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var split = test[2].Split(' ');
                var left = split[0];
                var right = split[1];
                Console.WriteLine(test[1].Split(' ').SkipWhile(x => x != left).Reverse().SkipWhile(x => x != right).Count() - 2);
            }
        }

        /// <summary>
        /// The execution time is 0.36
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                // Skip the number of elements
                // var n = int.Parse(test[0]);
                
                var split = test[2].Split(' ');
                var left = int.Parse(split[0]);
                var right = int.Parse(split[1]);
                Console.WriteLine(test[1].Split(' ').Select(int.Parse).SkipWhile(x => x != left).Reverse().SkipWhile(x => x != right).Count() - 2);
            }
        }

        /// <summary>
        /// The execution time is 0.16
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var split = test[2].Split(' ');
                var left = int.Parse(split[0]);
                var right = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Console.WriteLine(numbers.SkipWhile(x => x != left).Reverse().SkipWhile(x => x != right).Count() - 2);
            }
        }

        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void RunCompareToLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var split = test[2].Split(' ');
                var left = int.Parse(split[0]);
                var right = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Console.WriteLine(Array.IndexOf(numbers, left) - Array.LastIndexOf(numbers, right) - 1);
            }
        }

        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                // var n = int.Parse(test[0]); Skip the number of elements
                var split = test[2].Split(' ');
                var left = int.Parse(split[0]);
                var right = int.Parse(split[1]);
                var scanner = new StringScanner(test[1]);
                var leftIndex = -1;
                var rightIndex = -1;
                var i = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number == left && leftIndex == -1)
                    {
                        leftIndex = i;
                    }
                    else if (number == right)
                    {
                        rightIndex = i;
                    }

                    i++;
                }

                Console.WriteLine(rightIndex - leftIndex - 1);
            }
        }
    }
}