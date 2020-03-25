using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Binary Array Sorting"
    /// 
    /// Given a binary array A[] of size N. The task is to arrange array in increasing order.
    /// 
    /// Note: The binary array contains only 0  and 1.
    /// 
    /// Input:
    /// The first line of input contains an integer T, denoting the test cases.
    /// Every test case contains two lines, first line is N(size of array) and second line is space separated elements of array.
    /// 
    /// Output:
    /// Space separated elements of sorted arrays. There should be a new line between output of every test case.
    /// 
    /// Constraints:
    /// 1 < = T <= 100
    /// 1 <= N <= 10e6
    /// 0 <= A[i] <= 1
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 0 1 1 0
    /// 10
    /// 1 0 1 1 1 1 1 0 0 0
    /// 
    /// Output:
    /// 0 0 1 1 1
    /// 0 0 0 0 1 1 1 1 1 1
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class BinarySorting
    {
        /// <summary>
        /// Time Limit Exceeded !!!
        /// Expected Time Limit < 7.816sec
        /// Hint : Please optimize your code and submit again
        /// :)
        /// But, this is the easiest way
        /// </summary>
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t];

            for (var i = 0; i < t; i++)
            {
                input[i] = Console.ReadLine().Trim();
            }
            foreach (var testCase in input)
            {
                Console.WriteLine(string.Join(' ', testCase.Split(' ').OrderBy(x => x)));
            }
        }

        /// <summary>
        /// The execution time is 0.93
        /// </summary>
        public static void Run4()
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
                var bits = new int[n];
                for(var i = 0; i < testCase[1].Length; i+=2)
                {
                    if(testCase[1][i] == '1')
                    {
                        bits[--n] = 1;
                    }
                }
                Console.WriteLine(string.Join(' ', bits));
            }
        }

        /// <summary>
        /// The execution time is 0.97
        /// </summary>
        public static void Run3()
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
                var scanner = new StringScanner(testCase[1]);
                var elements = new int[n];
                while (scanner.HasNext)
                {
                    if (scanner.NextDigit() == 1)
                    {
                        elements[--n] = 1;
                    }
                }
                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// The execution time is 1.03
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
                var n = int.Parse(testCase[0]);
                var elements = new int[n];
                var k = testCase[1].Count(c => c == '1');
                while (k > 0)
                {
                    elements[--n] = 1;
                    k--;
                }

                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// The execution time is 1.65
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
                var n = int.Parse(testCase[0]);
                var scanner = new StringScanner(testCase[1]);
                var elements = new int[n];
                var index = 0;

                while (scanner.HasNext)
                {
                    switch (scanner.NextDigit())
                    {
                        case 0:
                            elements[index++] = 0;
                            break;
                        case 1:
                            elements[--n] = 1;
                            break;
                    }
                }
                Console.WriteLine(string.Join(' ', elements));
            }
        }
    }
}