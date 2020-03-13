using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    // ReSharper disable once CommentTypo
    /// <summary>
    /// The title is "Ishaan Loves Chocolates"
    /// 
    /// As we know, Ishaan has a love for chocolates. He has bought a huge chocolate bar which contains N chocolate squares.
    /// Each of the square has a tastiness level which is denoted by an array A[].
    /// Ishaan can eat the first or the last square of the chocolate at once.
    /// Ishaan has a sister who loves chocolates too and she demands the last chocolate square.
    /// Now, Ishaan being greedy eats the more tasty square first. 
    /// Determine the tastiness level of the square which his sister gets.
    ///
    /// Input : 
    /// First line of input contains a single integer T denoting the number of test cases.
    /// The first line of each test case contains an integer N.
    /// The second line contains N space-separated integers denoting the array A.
    ///
    /// Output : 
    /// For each test case, print the required answer in a new line.
    ///
    /// Constraints : 
    /// 1 <= T <= 100
    /// 1 <= N <= 250
    /// 1 <= A[i] <= 1000
    ///
    /// Example : 
    /// Input : 
    /// 5
    /// 5
    /// 5 3 1 6 9
    /// 6
    /// 2 6 4 8 1 6
    /// 4
    /// 2 2 2 2
    /// 7
    /// 952 909 153 132 190 340 604 
    /// 7
    /// 292 65 311 618 769 481 494
    /// 
    /// Output : 
    /// 1
    /// 1
    /// 2
    /// 132
    /// 65
    /// 
    /// Explaination : 
    /// Case 1 : 
    /// Initially : 5 3 1 6 9
    /// 5 3 1 6
    /// 5 3 1
    /// 3 1
    /// 1
    ///
    /// Case 2 : 
    /// Initially : 2 6 4 8 1 6
    /// 2 6 4 8 1
    /// 6 4 8 1
    /// 4 8 1
    /// 8 1
    /// 1
    ///
    /// Case 3 : 
    /// Initially : 2 2 2 2
    /// 2 2 2
    /// 2 2
    /// 2
    ///
    /// Remarks:
    /// 1) The statement is not clear
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    public class Chocolate
    {
        /// <summary>
        /// The execution time is 0.18
        /// * Single line solution
        /// </summary>
        public static void Run()
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
                Console.WriteLine(test.Split(' ').Select(int.Parse).Min());
            }
        }

        /// <summary>
        /// If Ishaan being greedy eats the more tasty square first, his sister gets the lowest tastiness level.
        /// * So, fint the min
        /// The execution time is 0.13
        /// </summary>
        public static void RunThis()
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
                var scanner = new StringScanner(test);
                var min = 1001;
                while (scanner.HasNext)
                {
                    var level = scanner.NextPositiveInt();
                    if (scanner.HasNext && level < min)
                    {
                        min = level;
                    }
                }

                Console.WriteLine(min);
            }
        }
    }
}