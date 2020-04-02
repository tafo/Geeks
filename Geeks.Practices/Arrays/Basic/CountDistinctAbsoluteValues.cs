using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Absolute distinct count"
    /// 
    /// Given a sorted array of integers, return the number of distinct absolute values among the elements of the array. 
    /// 
    /// Input:
    /// 
    /// The first line of input contains an integer T denoting the number of test cases.
    /// The first line of each test case is N,N is the size of array.
    /// The second line of each test case contains N input C[i].
    /// 
    /// Output:
    /// 
    /// Print the number of distinct absolute values.
    /// 
    /// Constraints:
    /// 
    /// 1 ≤ T ≤ 50
    /// 1 ≤ N ≤ 100
    /// -5000 ≤ C[i] ≤ 5000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// -1 -1 0 1 2
    /// 4
    /// 0 0 0 0
    /// 
    /// Output:
    /// 3
    /// 1
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountDistinctAbsoluteValues
    {
        /// <summary>
        /// The execution time is 0.08 1
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                Console.WriteLine(Console.ReadLine().TrimEnd().Split(' ').Select(x => Math.Abs(int.Parse(x))).Distinct().Count());
            }
        }

        /// <summary>
        /// The execution time is 0.08
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                Console.WriteLine(StringScanner.GetAbsoluteInt(Console.ReadLine().TrimEnd(), n).Distinct().Count());
            }
        }

        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var numbers = StringScanner.GetAbsoluteInt(Console.ReadLine().TrimEnd(), n);
                Array.Sort(numbers);
                var left = numbers[0];
                var counter = 1;
                for (var x = 1; x < n; x++)
                {
                    if (numbers[x] > left)
                    {
                        counter++;
                    }

                    left = numbers[x];
                }

                Console.WriteLine(counter);
            }
        }
    }
}