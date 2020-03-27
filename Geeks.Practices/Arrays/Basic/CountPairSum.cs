using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Count pair sum"
    /// 
    /// Given two sorted arrays of size m and n of distinct elements.
    /// Given a value x.
    /// The problem is to count all pairs from both arrays whose sum is equal to x.
    /// Note: The pair has an element from each array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains two integers m and n denoting the size of the two arrays.
    /// The next two lines contains the two arrays arr1 and arr2 respectively.
    /// The last line contains the value of sum x.
    /// 
    /// Output:
    /// Print the count of all pairs from both arrays whose sum is equal to x.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=m,n<=10^5
    /// 1<=arr1[i],arr2[j]<=10^5
    /// 1<=k<=10^5
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 4 4
    /// 1 3 5 7
    /// 2 3 5 8
    /// 10
    /// 7 7
    /// 1 2 3 4 5 7 11
    /// 2 3 4 5 6 8 12
    /// 9
    /// 4 7
    /// 336 778 794 916 
    /// 28 363 387 422 493 650 691 
    /// 60
    /// 4 7
    /// 173 427 541 737 
    /// 212 369 430 531 568 783 863 
    /// 124
    /// Output:
    /// 2
    /// 5
    /// 0
    /// 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountPairSum
    {
        /// <summary>
        /// The execution time is 0.10
        /// * Sorting has a positive effect on performance
        /// </summary>
        public static void RunCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                Console.ReadLine();
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var firstNumbers = test[0].Split(' ').Select(int.Parse).OrderBy(x => x);
                var secondNumbers = test[1].Split(' ').Select(int.Parse).OrderBy(x => x);
                var sum = int.Parse(test[2]);
                Console.WriteLine(firstNumbers.Count(x => secondNumbers.Any(y => x + y == sum)));
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
                Console.ReadLine();
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var firstNumbers = test[0].Split(' ').Select(int.Parse);
                var secondNumbers = test[1].Split(' ').Select(int.Parse);
                var sum = int.Parse(test[2]);
                Console.WriteLine(firstNumbers.Count(x => secondNumbers.Any(y => x + y == sum)));
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunCompareToMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[4];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
                tests[i][3] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var m = int.Parse(split[1]);
                var firstNumbers = StringScanner.GetPositiveInt(test[1], n);
                var secondNumbers = StringScanner.GetPositiveInt(test[2], m);
                var sum = int.Parse(test[3]);

                var count = firstNumbers.Count(x => secondNumbers.Any(y => x + y == sum));

                Console.WriteLine(count);
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[4];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
                tests[i][3] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var m = int.Parse(split[1]);
                var firstNumbers = StringScanner.GetPositiveInt(test[1], n);
                var secondNumbers = StringScanner.GetPositiveInt(test[2], m);
                var sum = int.Parse(test[3]);

                Array.Sort(firstNumbers);
                Array.Sort(secondNumbers);

                var count = firstNumbers.Count(x => secondNumbers.Any(y => x + y == sum));

                Console.WriteLine(count);
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[4];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
                tests[i][3] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var m = int.Parse(split[1]);
                var firstNumbers = StringScanner.GetPositiveInt(test[1], n);
                var secondNumbers = StringScanner.GetPositiveInt(test[2], m);
                var sum = int.Parse(test[3]);

                Array.Sort(firstNumbers);
                Array.Sort(secondNumbers);

                var y = m - 1;
                var count = 0;
                for (var x = 0; x < n; x++)
                {
                    var number = firstNumbers[x];
                    while (y > 0 && number + secondNumbers[y] > sum)
                    {
                        y--;
                    }

                    if (number + secondNumbers[y] == sum)
                    {
                        count++;
                    }
                }

                Console.WriteLine(count);
            }
        }
    }
}