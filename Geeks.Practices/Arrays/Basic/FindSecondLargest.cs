using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find second largest element"
    /// 
    /// Given an array of elements. Your task is to find the second maximum element in the array.
    /// 
    /// Input:
    /// The first line of input contains an integer T which denotes the number of test cases.
    /// Then T test cases follows.
    /// First line of each test case contains a single integer N which denotes the number of elements in the array.
    /// Second line of each test case contains N space separated integers which denotes the elements of the array.
    /// 
    /// Output:
    /// For each test case in a new line print the second maximum element in the array.
    /// If there does not exist any second largest element, then print -1.
    /// 
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 2<=n<=1000
    /// 1<=a[i]<=10e6
    ///  
    /// Example:
    /// Input:
    /// 4
    /// 5
    /// 2 4 5 6 7
    /// 6
    /// 7 8 2 1 4 3
    /// 22
    /// 59 96 30 38 36 94 19 29 44 12 29 30 77 5 44 64 14 39 7 41 5 19
    /// 3
    /// 10 10 10
    /// 
    /// Output:
    /// 6
    /// 7
    /// 94
    /// -1
    /// 
    /// Remarks:
    /// 1) The statement is not clear. For example, what if the value of every element is the same?
    ///     1.1) Actually, there were 2 test cases. I added the next two test cases that contain the input "10 10 10"
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindSecondLargest
    {
        /// <summary>
        /// The execution time is 0.09
        ///     * I was expecting to get a better result!!!
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = new int[n];
                var scanner = new StringScanner(test[1]);
                var i = 0;
                while (scanner.HasNext)
                {
                    numbers[i++] = scanner.NextPositiveInt();
                }

                Console.WriteLine(numbers.Distinct().OrderByDescending(x => x).Skip(1).DefaultIfEmpty(-1).FirstOrDefault());
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// LINQ :)
        /// </summary>
        public static void Run2()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                tests[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Split(' ').Select(int.Parse).Distinct().OrderByDescending(x => x).Skip(1).DefaultIfEmpty(-1)
                    .FirstOrDefault());
            }
        }

        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void Run1()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                // Skip the number of elements
                // The elements array is also unnecessary !!!
                // var n = int.Parse(test[0]); 
                var max = 0;
                var secondLargest = 0;
                var scanner = new StringScanner(test[1]);

                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number <= secondLargest) continue;

                    if (number > max)
                    {
                        secondLargest = max;
                        max = number;
                    }
                    else if (number < max)
                    {
                        secondLargest = number;
                    }
                }

                Console.WriteLine(secondLargest == 0 ? -1 : secondLargest);
            }
        }
    }
}