using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find first and last occurrence of x"
    /// 
    /// Given a sorted array with possibly duplicate elements.
    /// The task is to find indexes of first and last occurrences of an element X in the given array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the no of test cases.
    /// Then T test cases follow.
    /// Each test case contains an integer N denoting the size of the array.
    /// Then in the next line are N space separated values of the array.
    /// The last line of each test case contains an integer X.
    /// 
    /// Output:
    /// For each test case in a new line print two integers separated by space denoting the first and last occurrence of the element X.
    /// If the element is not present in the array print -1.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 1000
    /// 1 <= A[i], X <= 10e18
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 9
    /// 1 3 5 5 5 5 67 123 125
    /// 5
    /// 9
    /// 1 3 5 5 5 5 7 123 125
    /// 7
    /// 
    /// Output:
    /// 2 5
    /// 6 6
    /// 
    /// Explanation:
    /// Testcase 1: Index of first occurrence of 5 is 2 and index of last occurrence of 5 is 5.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FirstAndLastIndexOf
    {
        /// <summary>
        /// The execution time is 0.27
        /// </summary>
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
                input[i][2] = Console.ReadLine();
            }

            foreach (var testCase in input)
            {
                // var n = int.Parse(testCase[0]); Skip the number of elements
                var scanner = new StringScanner(testCase[1]);
                var key = long.Parse(testCase[2]);

                var counter = 0;
                var index = -1;
                while (scanner.HasNext)
                {
                    index++;
                    var number = scanner.NextPositiveInt64();
                    if (number < key)
                    {
                        continue;
                    }

                    if (number == key)
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (counter == 0)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine("{0} {1}", index - counter, index - 1);
                }
            }
        }

        /// <summary>
        /// The execution time is 0.26
        /// </summary>
        public static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
                input[i][2] = Console.ReadLine();
            }

            foreach (var testCase in input)
            {
                // var n = int.Parse(testCase[0]); Skip the number of elements
                var scanner = new StringScanner(testCase[1]);
                var key = long.Parse(testCase[2]);

                var firstIndex = -1;
                var index = -1;
                while (scanner.HasNext)
                {
                    index++;
                    var number = scanner.NextPositiveInt64();
                    if (number < key)
                    {
                        continue;
                    }

                    if (number == key)
                    {
                        if (firstIndex == -1)
                        {
                            firstIndex = index;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (firstIndex == -1)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine("{0} {1}", firstIndex, index - 1);
                }
            }
        }
    }
}