using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sum Array Puzzle"
    /// 
    /// Given an array A of size N, construct a Sum Array S(of same size) such that S is equal to the sum of all the elements of A except A[i].
    /// Your task is to complete the function SumArray(A, N) which accepts the array A and N(size of array).
    /// 
    /// Input :
    /// The first line of input is the number of test cases T.
    /// Each of the test case contains two lines.
    /// The first line of which is an integer N(size of array).
    /// The second line contains N space separated integers.
    /// 
    /// Output :
    /// For each test case print the sum array in new line.
    /// 
    /// User Task:
    /// Since this is a functional problem you did not have to worry about the input and output.
    /// You just have to complete the function SumArray() by storing arr[i]=S-arr[i]
    /// 
    /// Constraint :
    /// 1 <= T <= 10
    /// 1 <= N <= 10e4
    /// 1 <= Ai <= 10e4
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 5
    /// 3 6 4 8 9
    /// 6
    /// 4 5 7 3 10 1
    /// 
    /// Output:
    /// 27 24 26 22 21
    /// 26 25 23 27 20 29
    /// 
    /// Explanation:
    /// Testcase 1:
    /// For the sum array S, at i=0 we have 6+4+8+9.
    /// At i=1, 3+4+8+9. At i=2, we have 3+6+8+9.
    /// At i=3, we have 3+6+4+9.
    /// At i = 4, we have 3+6+4+8.
    /// So S is 27 24 26 22 21.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SubtractNumberFromSum
    {
        /// <summary>
        /// The execution time of the equivalent JAVA solution is 0.98
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
                SumArray(StringScanner.GetPositiveInt(test[1], n), n);
            }
        }

        /// <summary>
        /// The signature of the method is given by GfG
        /// * It should print the result
        /// </summary>
        [SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
        public static void SumArray(int[] arr, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = sum - arr[i];
            }

            Console.WriteLine(string.Join(' ', arr));
        }

        public static void RunThis()
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
                var sum = 0;
                var result = new int[n];
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    sum += result[i++] = number;
                }

                for (var k = 0; k < n; k++)
                {
                    result[k] = sum - result[k];
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}