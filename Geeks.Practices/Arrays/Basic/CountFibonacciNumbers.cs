using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Fibonacci in the array"
    /// 
    /// We are given an array and our task is to check if the elements of the array are present in Fibonacci series or not.
    /// Give the count of such numbers in the array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains an integer n which denotes the number of elements in the array a[].
    /// Next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Print an integer which denotes the count of Fibonacci numbers in the array.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=1000
    /// 1<=a[i]<=10000
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 9
    /// 4 2 8 5 20 1 40 13 23
    /// 5
    /// 1 2 3 4 5
    /// 6
    /// 7644 7913 3434 1777 7448 488 
    /// 9
    /// 8221 2191 1694 6622 3764 5795 2058 4900 4631
    /// 
    /// Output:
    /// 5
    /// 4
    /// 0
    /// 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountFibonacciNumbers
    {
        /// <summary>
        /// The execution time is 0.08
        /// </summary>
        public static void RunCompareToLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            var series = new[] {1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765};
            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var counter = 0;
                foreach (var number in numbers)
                {
                    if (Array.IndexOf(series, number) != -1)
                    {
                        counter++;
                    }
                }

                Console.WriteLine(counter);
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
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var left = 1;
                var current = 2;
                var counter = 0;
                var i = 0;
                while(i < n)
                {
                    if (numbers[i] == left || numbers[i] == current)
                    {
                        counter++;
                        i++;
                    }
                    else if (numbers[i] > current)
                    {
                        current = left + (left = current);
                    }
                    else
                    {
                        i++;
                    }
                }

                Console.WriteLine(counter);
            }
        }
    }
}