using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Partition Point in the Array"
    /// 
    /// Given an unsorted array of integers.
    /// Find an element such that all the elements to its left are smaller and to its right are greater.
    /// Print -1 if no such element exists.
    /// Note that there can be more than one such element.
    /// In that case print the first such number occurring in the array. 
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains an integer n which denotes the number of elements in the array a[].
    /// Next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Print an integer which is the required partition point.(-1 if no such partition exists)
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=1000
    /// 1<=a[i]<=10000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 7
    /// 4 3 2 5 8 6 7
    /// 7
    /// 5 6 2 8 10 9 8
    /// 
    /// Output:
    /// 5
    /// -1
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public class PartitionNumber
    {
        /// <summary>
        /// The execution time is 0.18
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine();
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var max = scanner.NextPositiveInt();
                var result = max;
                var flag = false;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number > result)
                    {
                        if (flag)
                        {
                            result = number;
                            flag = false;
                        }

                        max = number;
                    }
                    else
                    {
                        flag = true;
                        result = max;
                    }
                }

                Console.WriteLine(flag ? -1 : result);
            }
        }
    }
}