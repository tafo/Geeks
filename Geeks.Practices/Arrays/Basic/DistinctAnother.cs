using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Repeated I.Ds"
    /// 
    /// Raghav is given a task to select at most 10 employees for a company project.
    /// Each employee is represented by a single digit I.D. number which is unique for all the selected employees of the project.
    /// Raghav has a technical problem in his system which printed I.D. number multiple times.
    /// Help him to get rid of the repeated numbers.
    ///
    /// Input:
    /// First line contain T test cases.
    /// Second line contain the Total number (N) of employees where repeated I.Ds. are present.
    /// Third line contain the array A[N] of size N containing the I.Ds. of employees.
    /// 
    /// Output:
    /// Print the non repeated selected I.D. of employees in a new line in the same sequence they appear in Input.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 0<=N<=1000
    /// 
    /// Example:
    /// 
    /// Input:
    /// 5
    /// 5
    /// 8 8 6 2 1
    /// 6
    /// 7 6 7 4 2 7
    /// 9
    /// 1 9 6 7 4 8 1 4 5
    /// 3
    /// 1 1 1
    /// 5
    /// 0 1 0 1 2
    /// 40
    /// 7 3 4 2 6 9 6 8 7 8 5 8 1 9 5 0 8 7 5 3 2 8 7 4 6 0 1 5 1 2 0 1 7 5 0 3 1 9 2 5 
    /// 20
    /// 7 1 9 1 5 9 9 8 1 6 2 6 7 2 4 6 5 5 2 5
    /// 
    /// Output:
    /// 8 6 2 1
    /// 7 6 4 2
    /// 1 9 6 7 4 8 5
    /// 1
    /// 0 1 2
    /// 7 3 4 2 6 9 8 5 1 0 
    /// 7 1 9 5 8 6 2 4
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class DistinctAnother
    {
        /// <summary>
        /// The execution time is 0.09
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
                var digits = StringScanner.GetDigit(test[1], n);
                Console.WriteLine(string.Join(' ', digits.Distinct()));
            }
        }

        /// <summary>
        /// The execution time is 0.08
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
                var i = 0;
                var result = new[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
                var resultBuilder = new StringBuilder();
                while (scanner.HasNext)
                {
                    var digit = scanner.NextDigit();
                    if (Array.IndexOf(result, digit) != -1) continue;
                    result[i++] = digit;
                    resultBuilder.AppendFormat("{0} ", digit);
                }

                Console.WriteLine(resultBuilder.ToString());
            }
        }
    }
}