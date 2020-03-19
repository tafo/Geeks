using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Average Count Array"
    /// 
    /// You are given an integer 'n' which denote the number of elements in an array a[ ] and an integer 'x'.
    /// You have to calculate the average of element a[i] and x and find out if that number exist in array or not.
    /// Do it for all the elements of array and store the count result in another array for each index i.
    /// 
    /// Note:Always take the floor value of the average.
    /// 
    /// Input:
    /// The first line of the input contains an integer T denoting the number of test cases.
    /// For each test case there will be two lines.
    /// The first line contains n i.e, length of the array a[ ] and value of x.
    /// The second line contains the 'n' space separated integers of the array a[ ].
    /// 
    /// Output:
    /// You have to print the resultant array in which
    ///     you have to calculate the number of times the average of a[i] and x occurs in the array for each index i.
    /// 
    /// Constraints:
    /// 0 <= T <= 100
    /// 0 <= n <= 100
    /// 0 <= x <= 100
    /// 1 <= a[i] <= 100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5 2
    /// 2 4 8 6 2
    /// 6 3
    /// 9 5 2 4 0 3
    /// 
    /// Output:
    /// 2 0 0 1 2
    /// 0 1 1 1 0 1
    /// 
    /// Explanation:
    /// 
    /// For eg 1:
    ///     value of n is 5 and that of x is 2.
    ///     The array is 2 4 8 6 2.
    ///     We take x i.e. 2 and take average with a[0] whch is equal to 2.
    ///     We found 2 resides in array at two positions (1st and 5th element) thus storing 2 in another array at 0th index.
    ///     Similarly do for all elements and store the count in second array.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountAvg
    {
        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new int[2][];
                tests[i][0] = Console.ReadLine().Split(' ').Skip(1).Select(int.Parse).ToArray();
                tests[i][1] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(string.Join(' ', test[1].Select(x => test[1].Count(y => y == (x + test[0][0]) / 2))));
            }
        }

        /// <summary>
        /// The execution time is 0.14
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var x = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Console.WriteLine(string.Join(' ', numbers.Select(k => numbers.Count(y => y == (k + x) / 2))));
            }
        }

        /// <summary>
        /// The execution time is 0.15
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var x = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var result = new int[n];
                for (var k = 0; k < n; k++)
                {
                    var avg = (numbers[k] + x) / 2;
                    var count = 0;
                    foreach (var number in numbers)
                    {
                        if (number == avg)
                        {
                            count++;
                        }
                    }

                    result[k] = count;
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}