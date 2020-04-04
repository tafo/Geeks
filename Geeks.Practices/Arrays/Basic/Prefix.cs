using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Longest Equal Prefix"
    /// 
    /// Given two positive integers x and y, and an array arr[] of positive integers.
    /// We need to find the longest prefix index which contains an equal number of x and y.
    /// Print the maximum index of largest prefix if exist otherwise print -1.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains three integers n, x, and y where n denotes the number of elements in the array a[].
    /// Next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Print an integer which denotes the required prefix (0 based indexing).
    /// 
    /// Constraints:
    /// 1<=T<=50
    /// 1<=n<=1000
    /// 1<=a[i]<=100
    /// 1<=x,y<=100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 11 7 42
    /// 7 42 5 6 42 8 7 5 3 6 7
    /// 5 2 3
    /// 2 2 3 3 1
    /// 
    /// Output:
    /// 9
    /// 4
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Prefix
    {
        /// <summary>
        /// The execution time is 0.17
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                // var n = int.Parse(split[0]);
                var x = int.Parse(split[1]);
                var y = int.Parse(split[2]);
                var input = Console.ReadLine().TrimEnd();
                var counter = 0;
                var element = input.Split(' ').Select(int.Parse)
                    .Select((a, i) => new {Counter = a == x ? ++counter : a == y ? --counter : counter, Index = i})
                    .SkipWhile(a => a.Counter == 0)
                    .LastOrDefault(a => a.Counter == 0);
                Console.WriteLine(element?.Index ?? -1);
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
                var split = Console.ReadLine().Split(' ');
                // var n = int.Parse(split[0]);
                var x = int.Parse(split[1]);
                var y = int.Parse(split[2]);
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var xCounter = 0;
                var yCounter = 0;
                var result = -1;
                var i = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number == x)
                    {
                        xCounter++;
                    }
                    else if (number == y)
                    {
                        yCounter++;
                    }

                    if (xCounter == yCounter && xCounter > 0)
                    {
                        result = i;
                    }

                    i++;
                }

                Console.WriteLine(result);
            }
        }
    }
}