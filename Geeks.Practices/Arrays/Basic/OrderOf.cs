using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Searching a number"
    ///     >> Similar to IndexOf(Search an Element in an array)
    /// 
    /// Given an array of N elements and a integer K. Your task is to return the position of first occurence of K in the given array.
    /// Note: Position of first element is considered as 1.
    /// 
    /// Input:
    /// First line of input contains T denoting the number of test cases.
    /// For each test case there will be two space separated integer N and K denoting the size of array and the value of K respectively.
    /// The next line contains the N space separated integers denoting the elements of array.
    /// 
    /// Output:
    /// For each test case, print the index of first occurrence of given number K. Print -1 if the number is not found in array.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 106
    /// 1 <= K <= 106
    /// 1 <= A[i] <= 106
    /// 
    /// Example:
    /// Input :
    /// 2 
    /// 5 16
    /// 9 7 2 16 4
    /// 7 98
    /// 1 22 57 47 34 18 66
    /// 
    /// Output : 
    /// 4
    /// -1
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    internal class OrderOf
    {
        /// <summary>
        /// The execution time is 0.25
        /// </summary>
        internal static void Run()
        {
            var t = byte.Parse(Console.ReadLine());
            var input = new string[t][];
            
            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var key = int.Parse(split[1]);
                var scanner = new StringScanner(testCase[1]);
                var orderNumber = 1;

                while (scanner.HasNext)
                {
                    if (scanner.NextPositiveInt() == key)
                    {
                        break;
                    }

                    orderNumber++;
                }

                if (orderNumber == n + 1)
                {
                    Console.WriteLine("-1");
                }
                else
                {
                    Console.WriteLine(orderNumber);
                }
            }
        }
    }
}