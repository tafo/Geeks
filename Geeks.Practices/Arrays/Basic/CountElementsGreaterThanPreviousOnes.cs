using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Elements before which no element is bigger"
    /// 
    /// You are given an array A of size N.
    /// The task is to find count of elements before which all the elements are smaller.
    /// First element is always counted as there is no other element before it.
    /// 
    /// Input:
    /// The first line of input will contain number of test cases T.
    /// Then T test cases follow.
    /// Each test case contains 2 lines on input.
    /// The first line contains an integer N denoting the number of elements in the array.
    /// The next line contains N space separated integer's denoting the elements of the array.
    /// 
    /// Output:
    /// For each test case, print the Number of Elements before which no element is bigger.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= Ai <=10e18
    /// 
    /// Example:
    /// 
    /// Input:
    /// 4
    /// 6
    /// 10 40 23 35 50 7
    /// 3
    /// 5 4 1
    /// 1
    /// 1
    /// 2
    /// 1 2
    /// 
    /// Output:
    /// 3
    /// 1
    /// 1
    /// 2
    /// 
    /// Explanation:
    /// Test Case 1:
    /// Input: arr[] =  {10, 40, 23, 35, 50, 7}
    /// Output: 3
    /// The elements are 10, 40 and 50.
    /// No of elements is 3
    /// Test Case 2:
    /// Input: arr[] = {5, 4, 1}
    /// Output: 1
    /// There is only one element 5
    /// No of element is 1
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountElementsGreaterThanPreviousOnes
    {
        /// <summary>
        /// The execution time is 0.93
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var numbers = test.Split(' ').Select(int.Parse).ToArray();
                long max = -1;
                var maxList = numbers.SkipLast(1).Select((x, i) => x > max ? max = x : max).Prepend(-1);
                Console.WriteLine(numbers.Zip(maxList, (x, y) => x.CompareTo(y)).LongCount(x => x == 1));
            }
        }

        /// <summary>
        /// The execution time is 0.62
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
                var numbers = StringScanner.GetPositiveLong(test[1], n);
                long max = -1;
                var maxList = numbers.SkipLast(1).Select((x, i) => x > max ? max = x : max).Prepend(-1);
                var result = numbers.Zip(maxList, (x, y) => x.CompareTo(y)).LongCount(x => x == 1);
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// Time Limit Exceeded !!!
        /// Expected Time Limit < 3.832sec
        /// </summary>
        public static void RunAwayMix()
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
                var numbers = StringScanner.GetPositiveLong(test[1], n);
                long max = -1;
                var maxList = numbers.SkipLast(1).Select((x, i) => x > max ? max = x : max).Prepend(-1);
                var result = numbers.Zip(maxList, (x, y) => x.CompareTo(y)).LongCount(x => x == 1);
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.29
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
                // var n = int.Parse(test[0]); Skip the number of elements
                var scanner = new StringScanner(test[1]);
                long max = -1;
                var result = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveLong();
                    if (number <= max) continue;
                    result++;
                    max = number;
                }

                Console.WriteLine(result);
            }
        }
    }
}