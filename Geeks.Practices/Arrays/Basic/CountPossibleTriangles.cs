using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Form a Triangle"
    /// 
    /// Given an array of integers, we need to find out all possible ways construct non-degenerate triangle using array values as its sides.
    /// If no such triangle can be formed then return 0.
    /// 
    /// Input:
    /// The first line of input contains an integer T.
    /// Then T test cases follow.
    /// First line of each test case contains an integer N denoting the size of array.
    /// Next line of the test case contains N space separated integers.
    /// 
    /// Output:
    /// For each test case output the number of all possible triangles that can be formed using the values of the array.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e4
    /// 1 <= A[i] <= 10e4
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 5 4 3 1 2
    /// 3
    /// 10 15 30
    /// 
    /// Output:
    /// 3
    /// 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountPossibleTriangles
    {
        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var numbers = StringScanner.GetPositiveInt(input, n);
                Array.Sort(numbers);

                var result = 0;
                var c = n - 1;
                while (c > 1)
                {
                    var b = c - 1;
                    var a = 0;
                    while (a < b)
                    {
                        if (numbers[a] + numbers[b] > numbers[c])
                        {
                            result += b - a;
                            b--;
                        }
                        else
                        {
                            a++;
                        }
                    }

                    c--;
                }

                Console.WriteLine(result);
            }
        }
    }
}