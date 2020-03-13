using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find the fine"
    /// 
    /// Given an array of penalties P, an array of car numbers C, and also the date D.
    /// The task is to find the total fine which will be collected on the given date.
    /// Fine is collected from odd-numbered cars on even dates and vice versa.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of three lines of input.
    /// The first line of each test case contains two integers N & D,
    /// The second line contains N space separated car numbers C
    /// The third line contains N space separated penalties P.
    /// 
    /// Output:
    /// For each test case,In new line print the total fine.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e5
    /// 1000 <= Ci <= 9999
    /// 1 <= D <= 31
    /// 1 <= Pi <= 10e3
    /// Example:
    /// Input:
    /// 2
    /// 4 12
    /// 2375 7682 2325 2352
    /// 250 500 350 200
    /// 3 8
    /// 2222 2223 2224
    /// 200 300 400
    /// Output:
    /// 600
    /// 300
    /// 
    /// Explantion:
    /// Testcase1:
    /// The date is 12 (even), so we collect the fine from odd numbered cars.
    /// The odd numbered cars and the fines associated with them are as follows:
    /// 2375 >> 250
    /// 2325 >> 350
    /// The sum of the fines is 250+350 = 600
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindTheFine
    {
        /// <summary>
        /// The execution time is 0.20
        /// * Without using StringScanner
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
                input[i][2] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                 var n = int.Parse(split[0]);
                var date = int.Parse(split[1]);
                var bit = date & 1;
                var carNumbers = testCase[1].Split(' ');
                var penalties = testCase[2].Split(' ');
                var totalFine = 0;

                for (var i = 0; i < n; i++)
                {
                    if (bit != (int.Parse(carNumbers[i]) & 1))
                    {
                        totalFine += int.Parse(penalties[i]);
                    }
                    
                }

                Console.WriteLine(totalFine);
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// * Using bitwise logical AND
        /// </summary>
        public static void Run2()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
                input[i][2] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                // var n = int.Parse(split[0]); Skip the number of elements
                var date = int.Parse(split[1]);
                var bit = date & 1;
                var scanner = new StringScanner(testCase[1]);
                var penaltyScanner = new StringScanner(testCase[2]);
                var totalFine = 0;
                
                while (scanner.HasNext)
                {
                    var carNumber = scanner.NextPositiveInt();
                    var penalty = penaltyScanner.NextPositiveInt();
                    if (bit != (carNumber & 1))
                    {
                        totalFine += penalty;
                    }
                }

                Console.WriteLine(totalFine);
            }
        }

        /// <summary>
        /// The execution time is 0.14
        /// * Using XOR
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
                input[i][2] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                // var n = int.Parse(split[0]); Skip the number of elements
                var date = int.Parse(split[1]);
                var scanner = new StringScanner(testCase[1]);
                var penaltyScanner = new StringScanner(testCase[2]);
                var totalFine = 0;
                
                while (scanner.HasNext)
                {
                    var carNumber = scanner.NextPositiveInt();
                    var penalty = penaltyScanner.NextPositiveInt();
                    if (((carNumber ^ date) & 1) == 1)
                    {
                        totalFine += penalty;
                    }
                }

                Console.WriteLine(totalFine);
            }
        }
    }
}
