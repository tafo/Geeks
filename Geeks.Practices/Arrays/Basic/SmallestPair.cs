using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find the smallest and second smallest element in an array"
    /// 
    /// Given an array of integers, your task is to find the smallest and second smallest element in the array.
    /// If smallest and second smallest do not exist, print -1.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains an integer n denoting the size of the array.
    /// Then following line contains 'n' integers forming the array.
    /// 
    /// Output:
    /// Print the smallest and second smallest element if possible,else print -1.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=100
    /// 1<=a[i]<=1000
    /// 
    /// Example:
    /// Input :
    /// 3
    /// 5
    /// 2 4 3 5 6
    /// 6
    /// 1 2 1 3 6 7
    /// 2
    /// 1 1
    /// Output :
    /// 2 3
    /// 1 2
    /// -1
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SmallestPair
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunThis()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                tests[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var scanner = new StringScanner(test);
                var min = 1001;
                var secondMin = 1001;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number >= secondMin || number == min) continue;

                    if (number < min)
                    {
                        secondMin = min;
                        min = number;
                    }
                    else
                    {
                        secondMin = number;
                    }
                }

                Console.WriteLine(min != 1001 && secondMin != 1001 ? "{0} {1}" : "-1", min, secondMin);
            }
        }
    }
}