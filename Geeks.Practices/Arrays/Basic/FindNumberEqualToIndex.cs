using System;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Magical Number"
    /// 
    /// Your friend loves magic and he has coined a new term - "Magical number".
    /// To perform his magic, he needs that Magic number.
    /// There are N number of people in the magic show, seated according to their ages in an ascending order.
    /// Magical number is that seat no. where the person has the same age as that of the given seat number.
    /// Help your friend in finding out that "Magical number"
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// The first line of each test case is N, size of an array.
    /// The second line of each test case contains N input A[].
    /// 
    /// Output:
    /// 
    /// Print "Magical Number"
    /// Print "-1" when index value does not match with value. 
    /// 
    /// Constraints:
    /// 
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 1000
    /// -1000 ≤ A[i] ≤ 1000
    /// 
    /// Example:
    /// 
    /// Input:
    /// 1
    /// 10
    /// -10 -1 0 3 10 11 30 50 100 150
    /// 
    /// Output:
    /// 3
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindNumberEqualToIndex
    {
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
                // Skip the number of elements
                // var n = int.Parse(test[0]);

                var scanner = new StringScanner(test[1]);
                var i = 0;
                var result = -1;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number != i++) continue;
                    result = number;
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}