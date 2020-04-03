using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimum sum of two elements from two arrays"
    /// 
    /// Given two arrays a[] and b[] of same size.
    /// Your task is to find minimum sum of two elements such that they belong to different arrays and are not at same index in their arrays.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains an integer n denoting the size of the array.
    /// Then next two lines contains n space separated integers forming the arrays.
    /// 
    /// Output:
    /// Output the minimum sum.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=100
    /// 1<=a[i]<=1000
    /// 1<=b[i]<=1000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 5 4 3 2
    /// 2 1 4  5 3
    /// 4
    /// 1 2 3 4
    /// 1 3 5 6
    /// 
    /// Output:
    /// 2
    /// 3
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinPairSum
    {
        /// <summary>
        /// The execution time is 0.10
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine();
                var firstInput = Console.ReadLine().TrimEnd();
                var secondInput = Console.ReadLine().TrimEnd();
                var firstList = firstInput.Split(' ').Select((x, i) => new {Index = i, Number = int.Parse(x)})
                    .OrderBy(x => x.Number).Take(2).ToArray();
                var secondList = secondInput.Split(' ').Select((x, i) => new {Index = i, Number = int.Parse(x)})
                    .OrderBy(x => x.Number).Take(2).ToArray();
                Console.WriteLine(firstList.First().Index == secondList.First().Index
                    ? Math.Min(firstList.First().Number + secondList.Last().Number, firstList.Last().Number + secondList.First().Number)
                    : firstList.First().Number + secondList.First().Number);
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var firstInput = Console.ReadLine().TrimEnd();
                var secondInput = Console.ReadLine().TrimEnd();
                var firstList = new int[n][];
                var secondList = new int[n][];
                var firstScanner = new StringScanner(firstInput);
                var secondScanner = new StringScanner(secondInput);
                var i = 0;
                while (firstScanner.HasNext)
                {
                    firstList[i] = new int[2];
                    secondList[i] = new int[2];
                    firstList[i][0] = firstScanner.NextPositiveInt();
                    secondList[i][0] = secondScanner.NextPositiveInt();
                    firstList[i][1] = secondList[i][1] = i;
                    i++;
                }

                Array.Sort(firstList, (x, y) => x[0].CompareTo(y[0]) == 0 ? x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));
                Array.Sort(secondList, (x, y) => x[0].CompareTo(y[0]) == 0 ? x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));
                int result;
                if (firstList[0][0] != secondList[0][0])
                {
                    result = firstList[0][0] + secondList[0][0];
                }
                else
                {
                    result = Math.Min(firstList[0][0] + secondList[1][0], firstList[1][0] + secondList[0][0]);
                }

                Console.WriteLine(result);
            }
        }
    }
}