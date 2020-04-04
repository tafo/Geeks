using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Learning Output"
    /// 
    /// Being a Programmer you have to learn how to make your output looks better.
    /// According to the company, its company programmers have to present its output in a different manner as :
    /// If your output is 10.000000 you can save the decimal places and thus your output becomes 10.
    /// Now u have the learn the way to output.
    /// You are given elements of an array A[N]
    /// And you have to divide N by total no. of +ve integers,
    /// N by total no. of -ve integers
    /// And N by total no. of zero value integers.
    /// 
    /// Input : 
    /// The first line of input contains an integer T denoting the no of test cases.
    /// Then T test cases follow. 
    /// Second line contains N - array size.
    /// Third line contains the elements of array.
    /// 
    /// Output : 
    /// For each test case in a new line print the division value of
    /// N by Total no. of +ve integers
    /// N by Total no. of -ve integers
    /// N by Total no. of zero value integers
    /// 
    /// Constraints :
    /// 1 ≤ T ≤ 50
    /// 1 ≤ N ≤ 100
    /// 1 ≤ A[i] ≤ 1000
    /// 
    /// Input : 
    /// 1
    /// 10
    /// 7 7 7 7 7 7 -9 -9 -9 0
    /// 
    /// Output : 
    /// 1.66667
    /// 3.33333
    /// 10
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CompareSizeToCount
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunAnotherLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = double.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var positiveCounter = 0;
                var negativeCounter = 0;
                var zeroCounter = 0;
                var scanner = new StringScanner(input);
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt();
                    if (number < 0)
                    {
                        negativeCounter++;
                    }
                    else if (number == 0)
                    {
                        zeroCounter++;
                    }
                    else
                    {
                        positiveCounter++;
                    }
                }

                var positiveRatio = n / positiveCounter;
                var negativeRatio = n / negativeCounter;
                var zeroRatio = n / zeroCounter;
                Console.WriteLine(positiveRatio - (int)positiveRatio < double.Epsilon
                    ? $"{(int)positiveRatio}"
                    : positiveRatio.ToString("#.#####"));
                Console.WriteLine(negativeRatio - (int)negativeRatio < double.Epsilon
                    ? $"{(int)negativeRatio}"
                    : negativeRatio.ToString("#.#####"));
                Console.WriteLine(zeroRatio - (int)zeroRatio < double.Epsilon
                    ? $"{(int)zeroRatio}"
                    : zeroRatio.ToString("#.#####"));
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
                var n = double.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var positiveCounter = 0;
                var negativeCounter = 0;
                var zeroCounter = 0;
                var scanner = new StringScanner(input);
                while (scanner.HasNext)
                {
                    var number = scanner.NextInt();
                    if (number < 0)
                    {
                        negativeCounter++;
                    }
                    else if (number == 0)
                    {
                        zeroCounter++;
                    }
                    else
                    {
                        positiveCounter++;
                    }
                }

                var positiveRatio = n / positiveCounter;
                var negativeRatio = n / negativeCounter;
                var zeroRatio = n / zeroCounter;
                Console.WriteLine(positiveRatio - (int)positiveRatio < double.Epsilon
                    ? (int)positiveRatio
                    : decimal.Round((decimal)positiveRatio, 5));
                Console.WriteLine(negativeRatio - (int)negativeRatio < double.Epsilon
                    ? (int)negativeRatio
                    : decimal.Round((decimal)negativeRatio, 5));
                Console.WriteLine(zeroRatio - (int)zeroRatio < double.Epsilon
                    ? (int)zeroRatio
                    : decimal.Round((decimal)zeroRatio, 5));
            }
        }
    }
}