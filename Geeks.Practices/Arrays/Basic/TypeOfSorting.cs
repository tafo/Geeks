using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Type of array"
    /// 
    /// You are given an array of size N having no duplicate elements. The array can be categorized into following:
    /// 1.  Ascending
    /// 2.  Descending
    /// 3.  Descending Rotated
    /// 4.  Ascending Rotated
    /// Your task is to print which type of array it is and the maximum element of that array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the no test cases.
    /// Then T test cases follow.
    /// Each test case contains two lines of input.
    ///     The first line contains an integer N denoting the size of the array.
    ///     The next line contains N space separated values of the array.
    /// 
    /// Output:
    /// For each test case, print the largest element in the array and and integer x denoting the type of the array.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 3 <= N <= 10e7
    /// 1 <= A[] <= 10e18
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 5
    /// 2 1 5 4 3
    /// 5
    /// 3 4 5 1 2
    /// 52
    /// 982 60 99 101 125 134 138 148 151 168 182 196 206 208 212 223 235 236 267 273 343 350 352 356 366 380 431 447 482 505 509 523 537 550 576 578 581 600 641 644 649 655 693 735 753 804 814 822 888 935 949 962
    /// Output:
    /// 5 3
    /// 5 4
    /// 982 4
    /// 
    /// Explanation:
    /// Testcase1:
    /// Input : A[] = { 2, 1, 5, 4, 3}
    /// Output : Descending rotated with maximum element 5
    /// Testcase2:
    /// Input : A[] = { 3, 4, 5, 1, 2}
    /// Output : Ascending rotated with maximum element 5
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class TypeOfSorting
    {
        /// <summary>
        /// The execution time is 0.28
        /// * Just for fun
        /// </summary>
        public static void Run()
        {
            var x = int.Parse(Console.ReadLine());
            var input = new string[x][];

            for (var i = 0; i < x; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                int sorting;
                // var n = int.Parse(testCase[0]); Skip the number of elements
                var scanner = new StringScanner(testCase[1]);
                long max;
                var current = max = scanner.NextUInt64();
                var next = scanner.NextUInt64();
                long previous;
                do
                {
                    previous = current;
                    current = next;
                    next = scanner.NextUInt64();
                } while (scanner.HasNext && (previous < current && current < next || previous > current && current > next));

                if (previous < current && current < next)
                {
                    sorting = 1;
                    max = next;
                }
                else if (previous > current && current > next)
                {
                    sorting = 2;
                }
                else if (previous < current && current > next)
                {
                    max = current;
                    sorting = previous < next ? 3 : 4;
                }
                else
                {
                    if (previous < next)
                    {
                        sorting = 3;
                        max = next;
                    }
                    else
                    {
                        sorting = 4;
                        max = previous;
                    }
                }

                Console.WriteLine($"{max} {sorting}");
            }
        }

        /// <summary>
        /// The execution time is 0.28
        /// </summary>
        public static void Run1()
        {
            var x = int.Parse(Console.ReadLine());
            var input = new string[x][];

            for (var i = 0; i < x; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var sorting = 1;
                // var n = int.Parse(testCase[0]); Skip the number of elements
                var scanner = new StringScanner(testCase[1]);
                var previous = scanner.NextUInt64();
                var current = scanner.NextUInt64();
                long max;
                if (previous > current)
                {
                    sorting = 2;
                    max = previous;
                }
                else
                {
                    max = current;
                }

                while (scanner.HasNext)
                {
                    var next = scanner.NextUInt64();
                    if (sorting == 1)
                    {
                        if (next < current)
                        {
                            sorting = previous < next ? 3 : 4;
                            max = current;
                            break;
                        }

                        max = next;
                    }
                    else if (sorting == 2)
                    {
                        if (next > current)
                        {
                            if (previous < next)
                            {
                                sorting = 3;
                                max = next;
                            }
                            else
                            {
                                sorting = 4;
                                max = previous;
                            }
                            break;
                        }
                    }
                    previous = current;
                    current = next;
                }

                Console.WriteLine($"{max} {sorting}");
            }
        }
    }
}