using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimum distance between two numbers"
    /// 
    /// You are given an array A, of N elements. You need to find minimum distance between given two integers x and y.
    /// 
    /// Distance: The distance (index-based) between two elements of the array.
    /// 
    /// Input Format:
    /// The first line of input contains an integer T, denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of three lines.
    ///     The first line of each test case contains an integer N denoting size array.
    ///     Then in the next line are N space separated values of the array A.
    ///     The last line of each test case contains two integers  x and y.
    /// 
    /// Output Format:
    /// For each test case, print the required answer .
    /// 
    /// Your Task:
    /// Complete the function minDist. If no such distance is possible then return -1.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e5
    /// 1 <= A, x, y <= 10e5
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 4
    /// 1 2 3 2
    /// 1 2
    /// 7
    /// 86 39 90 67 84 66 62 
    /// 42 12
    /// 62
    /// 96 82 48 76 34 19 7 80 36 57 77 34 19 35 5 57 16 66 42 62 89 19 60 19 25 16 20 51 77 75 12 73 8 11 100 93 81 58 72 17 14 48 2 33 82 6 41 49 72 34 10 12 53 21 30 77 36 49 79 13 75 42
    /// 36 33
    /// Output:
    /// 1
    /// -1
    /// 13
    /// 
    /// Explanation:
    /// Testcase1: x = 1 and y = 2. There are two distances between x and y, which are 1 and 3 out of which the minDistance between x and y is 1.
    /// Testcase2: x = 42 and y = 12. We return -1 as the x and y don't exist in the array.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinimumDistance
    {
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
                input[i][2] = Console.ReadLine();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = new long[n];
                var scanner = new StringScanner(testCase[1]);
                var split = testCase[2].Split(' ');
                var first = int.Parse(split[0]);
                var second = int.Parse(split[1]);
                var index = 0;
                while (scanner.HasNext)
                {
                    elements[index++] = scanner.NextPositiveInt();
                }

                Console.WriteLine(MinDist(elements, n, first, second));
            }
        }

        /// <summary>
        /// The execution time is 1.04
        /// * If x and y are different
        /// </summary>
        private static long MinDist(long[] arr, long n, long x, long y)
        {
            long positionX = 2 * n;
            long positionY = 2 * n;
            long difference = n;
            for (int i = 0; i < n; i++)
            {
                long number = arr[i];
                if (number == x)
                {
                    positionX = i;
                    difference = Math.Min(difference, Math.Abs(positionX - positionY));
                }
                else if (number == y)
                {
                    positionY = i;
                    difference = Math.Min(difference, Math.Abs(positionX - positionY));
                }
            }

            return difference == n ? -1 : difference;
        }

        /// <summary>
        /// The execution time is 0.94
        /// * If x and y are different
        /// </summary>
        private static long MinDist2(long[] arr, long n, long x, long y)
        {
            int xp = -1;
            long yp = -1;
            long difference = -1;
            for (int i = 0; i < n; i++)
            {
                long number = arr[i];
                if (number == x)
                {
                    xp = i;
                    if (yp != -1)
                    {
                        long currentDifference = xp - yp;
                        if (difference == -1)
                        {
                            difference = currentDifference;
                        }
                        else if (currentDifference < difference)
                        {
                            difference = currentDifference;
                        }
                    }
                }

                if (number == y)
                {
                    yp = i;
                    if (xp != -1)
                    {
                        long currentDifference = yp - xp;

                        {   // The assignment code block should be another method
                            if (difference == -1)
                            {
                                difference = currentDifference;
                            }
                            else if (currentDifference < difference)
                            {
                                difference = currentDifference;
                            }

                        }
                    }
                }
            }

            return difference;
        }

        /// <summary>
        /// The execution time is 0.98
        /// * If x and y can be same
        /// </summary>
        private static long MinDist1(long[] arr, long n, long x, long y)
        {
            long xp = -1;
            long yp = -1;
            long difference = -1;
            for (int i = 0; i < n; i++)
            {
                long number = arr[i];
                if (number == x)
                {
                    xp = i;
                    if (yp != -1)
                    {
                        long currentDifference = xp - yp;
                        if (difference == -1)
                        {
                            difference = currentDifference;
                        }
                        else if (currentDifference < difference)
                        {
                            difference = currentDifference;
                        }
                    }
                }

                if (number == y)
                {
                    yp = i;
                    if (xp != -1)
                    {
                        long currentDifference = yp - xp;
                        if (difference == -1)
                        {
                            difference = currentDifference;
                        }
                        else if (currentDifference < difference)
                        {
                            difference = currentDifference;
                        }
                    }
                }
            }

            return difference;
        }
    }
}