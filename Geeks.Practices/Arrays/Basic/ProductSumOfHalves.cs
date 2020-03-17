using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Multiply left and right array sum."
    /// 
    /// Pitsy needs help in the given task by her teacher.
    /// The task is to divide a array into two sub array containing n/2 elements each
    ///     and do the sum of the sub arrays and then multiply both the sub arrays.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// Only line of every test case consists of an integer N.​
    /// 
    /// Output:
    /// Print the answer by dividing array into left and right array and add their elements individually and then multiply both the array
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=1000
    /// 1<=Ai<=100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 4
    /// 1 2 3 4
    /// 3
    /// 4 5 6
    /// Output:
    /// 21
    /// 44
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    public class ProductSumOfHalves
    {
        /// <summary>
        /// The execution time is 0.18
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var elements = test[1].Split(' ').Select(int.Parse).ToArray();
                var h = int.Parse(test[0]) / 2;
                Console.WriteLine(elements.Take(h).Sum() * elements.Skip(h).Sum());
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var scanner = new StringScanner(test[1]);
                var i = 0;
                var half = n / 2;
                var leftSum = 0;
                var rightSum = 0;
                while (scanner.HasNext && i++ < half)
                {
                    leftSum += scanner.NextPositiveInt();
                }

                while (scanner.HasNext)
                {
                    rightSum += scanner.NextPositiveInt();
                }

                Console.WriteLine(leftSum * rightSum);
            }
        }
    }
}