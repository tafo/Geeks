using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Java 1-d and 2-d Array"
    ///  
    /// Given a integer n.
    /// We have n*n values of a 2-d array, and  n values of 1-d array.
    /// Task is to find the sum of the diagonal values of the 2-d array and the max element of the 1-d array and print them with space in between.
    /// 
    /// Input:
    /// First line of input contains a single integer T which denotes the number of test cases.
    /// T test cases follows, first line of each test case contains a integer n.
    /// Second line consists of n*n spaced integers.
    /// Third and last line consists of n spaced integers.
    /// 
    /// Output:
    /// Print the sum of the diagonal elements and the maximum number of the 1-d array with spaces in between.
    /// 
    /// Constraints:
    /// 
    /// 1<=T<=100
    /// 1<= n <=100
    /// 1<=element<=10e3
    /// 
    /// 
    /// Example:
    /// 
    /// Input:
    /// 1
    /// 3
    /// 1 2 3 4 5 6 7 8 9
    /// 3 6 9
    /// 
    /// Output:
    /// 15 9
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SumOfDiagonalNumbers
    {
        /// <summary>
        /// The execution time of the equivalent JAVA solution is 0.69
        /// * But, the C# solution has a better performance
        /// </summary>
        public static void Run()
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
                var sum = 0;
                var scanner = new StringScanner(test[1]);
                var i = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (i++ % (n + 1) == 0)
                    {
                        sum += number;
                    }
                }

                Console.WriteLine("{0} {1}", sum, StringScanner.MaxPositiveInt(test[2]));
            }
        }
    }
}