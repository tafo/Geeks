using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Balance with respect to an array"
    /// 
    /// As a programmer, it is very necessary to maintain balance in the things you work upon.
    /// Here is task for you to maintain this balance.
    /// Your task is to find whether a given number x is balanced with respect to a given array a[] which is sorted in a non-decreasing order.
    /// Given a sorted array,
    ///     the ceiling of x is the smallest element in array greater than or equal to x,
    ///     and the floor is the greatest element smaller than or equal to x.
    /// The number 'x' is said to be balanced if the floor is equal to ceil of the number in the array a[].
    /// ie. if (x - floor(x,a)) == (ceil(x,a) - x)
    /// Assume one of floor or ceil does not exist assume 'x' to be balanced.
    /// If Key exists in the array so it is Balanced.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains the number of elements in the array a[] as n and next line contains space separated n elements in the array.
    /// The following line consists of the number 'x' for which balance is to be checked.
    /// 
    /// Output:
    /// Output "Balanced" if the number 'x' is balanced otherwise output "Not Balanced".
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=100000
    /// 1<=a[i]<=100000
    /// 1<=x<=100000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 7
    /// 1 2 8 10 10 12 19
    /// 5
    /// 8
    /// 1 2 5 7 8 11 12 15
    /// 9
    /// 
    /// Output:
    /// Balanced
    /// Not Balanced
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CheckBalance
    {
        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine();
                var input = Console.ReadLine().TrimEnd();
                var x = int.Parse(Console.ReadLine());
                var scanner = new StringScanner(input);
                var floor = 0;
                var result = "Balanced";
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number < x)
                    {
                        floor = number;
                    }
                    else if (number == x)
                    {
                        break;
                    }
                    else
                    {
                        if (floor > 0 && floor + number != 2 * x)
                        {
                            result = "Not Balanced";
                        }

                        break;
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}