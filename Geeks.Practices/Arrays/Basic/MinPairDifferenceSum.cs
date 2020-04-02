using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Friendly Array"
    /// 
    /// Like people, numbers are also friends with each other.
    /// Friendliness between any two numbers a and b is defined as the absolute difference between the two.
    /// Lower is this number more friendly the numbers are.
    /// Now you are given an array of numbers and you are required to find the friendliness of this array.
    /// This can be calculated as the sum of the friendliness of each element in the array with its closest friend in the same array. 
    /// Output the value of friendliness for the given array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains the number of elements in the array a[] as n and next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Print an integer which denotes the friendliness in the array.
    /// 
    /// Constraints:
    /// 1<=T<=10
    /// 2<=n<=10000
    /// 1<=a[i]<=100000
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 3
    /// 4 1 5
    /// 6
    /// 5 10 1 4 8 7
    /// 9
    /// 12 10 15 22 21 20 1 8 9
    /// 
    /// Output:
    /// 5
    /// 9
    /// 18
    /// 
    /// Explanation:
    /// 
    /// For test-case 1:
    /// 3
    /// 4 1 5
    /// Here the elements are 4, 1, and 5.
    /// The friendliness of 4 with other elements are
    /// F(4,1) = |4-1| = 3
    /// F(4,5) = |4-5| = 1
    /// Min(F(4,1),F(4,5)) = 1 =&gt; This means 4 is closet friend to 5
    /// The friendliness of 1 with other elemnts are
    /// F(1,4) = |1-4| = 3
    /// F(1,5) = |1-5| = 4
    /// Min(F(1,4),F(1,5)) = 3 =&gt; This means 1 is closet friend to 4
    /// The friendliness of 5 with other elemnts are
    /// F(5,1) = |5-1| = 4
    /// F(5,4) = |5-4| = 1
    /// Min(F(5,1),F(5,4)) = 1 =&gt; This means 5 is closet friend to 4
    /// So, the total friendliness of the array is Min(F(4,1),F(4,5)) + Min(F(1,4),F(1,5)) + Min(F(5,1),F(5,4)) =&gt;1+3+1 =&gt; 5
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinPairDifferenceSum
    {
        /// <summary>
        /// The execution time is 0.54
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var list = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).OrderBy(x => x).Prepend(-100000).Append(200000).ToArray();
                Console.WriteLine(Enumerable.Range(1, n).Select(x => Math.Min(list[x] - list[x - 1], list[x + 1] - list[x])).Sum());
            }
        }

        /// <summary>
        /// The execution time is 0.26
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var numbers = StringScanner.GetPositiveInt(Console.ReadLine().TrimEnd(), n);
                Array.Sort(numbers);
                numbers = numbers.Prepend(-100000).Append(200000).ToArray();
                Console.WriteLine(Enumerable.Range(1, n).Select(x => Math.Min(numbers[x] - numbers[x - 1], numbers[x + 1] - numbers[x])).Sum());
            }
        }

        /// <summary>
        /// The execution time is 0.25
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var numbers = StringScanner.GetPositiveInt(Console.ReadLine().TrimEnd(), n);
                Array.Sort(numbers);
                var result = numbers[1] - numbers[0];
                if (n > 2)
                {
                    result += numbers[n - 1] - numbers[n - 2];
                    for (var x = 1; x < n - 1; x++)
                    {
                        result += Math.Min(numbers[x] - numbers[x - 1], numbers[x + 1] - numbers[x]);
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}