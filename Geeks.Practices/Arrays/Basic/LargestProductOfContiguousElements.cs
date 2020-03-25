using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Largest product"
    /// 
    /// Given an array consisting of N positive integers, and an integer k.
    /// You have to find the maximum product of k contiguous elements in the array.
    /// Your task is to complete the function which takes three arguments.
    /// 
    /// Function:
    ///     The first argument is the array A[]
    ///     And second argument is an integer N denoting the size of the array A[]
    ///     And the third argument is an integer k.
    /// The function will return and value denoting the largest product of sub-array of size k.
    /// 
    /// Input:
    /// The first line of input is an integer T denoting the no of test cases.
    /// Then T test cases follow.
    /// The first line of each test case are two integer N and K separated by space.
    /// The next line contains N space separated values of the array A[].
    /// 
    /// Output:
    /// Output of each test case will be an integer denoting the largest product of sub array of size k.
    /// 
    /// Constraints:
    /// 1 <=T<= 100
    /// 1 <=N<= 10
    /// 1 <=K<= N
    /// 1<=A[]<=10
    /// 
    /// Example:
    /// 
    /// Input:
    /// 3
    /// 4 2
    /// 1 2 3 4
    /// 4 3
    /// 8 6 4 6 
    /// 7 3
    /// 10 2 3 8 1 10 4
    /// 
    /// Output:
    /// 12 
    /// 192
    /// 80
    /// 
    /// Explanation:
    /// The sub-array of size 2 will be 3 4 and the product is 12.
    /// 
    /// Note:
    ///     The Input/Ouput format and Example given are used for system's internal purpose,
    ///     And should be used by a user for Expected Output only.
    ///     As it is a function problem, hence a user should not read any input from stdin/console.
    ///     The task is to complete the function specified, and not to write the full code.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class LargestProductOfContiguousElements
    {
        /// <summary>
        /// The execution time is 0.16
        /// </summary>
        public static void RunLoop()
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Console.WriteLine(FindMaxProduct(numbers, n, k));
            }
        }

        /// <summary>
        /// The signature of this method is given by GfG
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static long FindMaxProduct(int[] numbers, int n, int k)
        {
            long product = 1;
            for (var i = 0; i < k; i++)
            {
                product *= numbers[i];
            }

            var result = product;

            var c = 0;
            for (var i = k; i < n; i++)
            {
                product = product / numbers[c++] * numbers[i];
                if (product > result)
                {
                    result = product;
                }
            }

            return result;
        }
    }
}