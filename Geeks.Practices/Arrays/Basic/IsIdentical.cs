using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "The problem of identical arrays"
    /// 
    /// Two arrays of size N are called identical arrays if they contain the same elements.
    /// The order of elements in both arrays could be different; however, both the arrays must contain same elements.
    /// You are given two arrays of size N.
    /// 
    /// You need to determine if the arrays are identical or not.
    /// 
    /// Input:
    /// The first line of the input contains a single integer T, denoting the number oftest cases.
    /// Then T test case follows.
    /// Each test case contains 3 lines:-
    /// size of array N
    /// elements of array1
    /// elements of array2
    /// 
    /// Output:
    /// Print 1 if the arrays are identical, and print 0 if they are not identical.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=1000
    /// 0<=A[i]<=9
    /// 
    /// Example:
    /// 
    /// Input:
    /// 5
    /// 5
    /// 1 2 3 4 5
    /// 3 4 1 2 5
    /// 4
    /// 1 2 3 4
    /// 1 2 3 9
    /// 1
    /// 8
    /// 8
    /// 9
    /// 1 2 3 4 5 6 7 8 9
    /// 9 8 7 6 5 4 3 2 1
    /// 1
    /// 9
    /// 9
    /// 
    /// Output:
    /// 1
    /// 0
    /// 1
    /// 1
    /// 1
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class IsIdentical
    {
        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var firstNumbers = StringScanner.GetDigit(test[1], n);
                var secondNumbers = StringScanner.GetDigit(test[2], n);
                Array.Sort(firstNumbers);
                Array.Sort(secondNumbers);

                var result = 1;
                for (var i = 0; i < n; i++)
                {
                    if(firstNumbers[i] == secondNumbers[i]) continue;
                    result = 0;
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}