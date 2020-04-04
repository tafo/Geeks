using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Equalization of an array"
    /// 
    /// Given an array of integers, the task is to count minimum number of operations to equalize the array
    ///     i.e., to make all array elements same.
    /// To equalize an array, we need to move values from higher numbers to smaller numbers.
    /// Number of operations is equal to number of movements.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow. Each test case consists of two lines.
    /// First line of each test case contains an Integer N denoting size of array.
    /// And the second line contains N space separated elements.
    /// 
    /// Output:
    /// For each test case, print the minimum number of operations.
    /// And print "-1", if it is not possible to equalize the array.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10e5
    /// 0<=A[i]<=10e5
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 3 2 0 4
    /// 3
    /// 1 7 1
    /// 
    /// Output:
    /// 3
    /// 4
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MakeEveryElementSame
    {
        /// <summary>
        /// The execution time is 0.19
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = double.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var numbers = input.Split(' ').Select(int.Parse).ToArray();
                var sum = numbers.Sum();
                var average = sum / n;
                var avg = (int)average;
                var result = -1;
                if (average - avg < double.Epsilon)
                {
                    result = numbers.Sum(x => Math.Abs(avg - x)) / 2;
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                double sum = 0;
                var numbers = new int[n];
                var i = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    sum += number;
                    numbers[i++] = number;
                }

                var average = sum / n;

                var result = -1;
                if (Math.Abs(average % 1) <= double.Epsilon)
                {
                    var avg = (int)average;
                    int missingSum = 0;
                    foreach (var number in numbers)
                    {
                        missingSum += Math.Abs(avg - number);
                    }

                    result = missingSum / 2;
                }

                Console.WriteLine(result);
            }
        }
    }
}