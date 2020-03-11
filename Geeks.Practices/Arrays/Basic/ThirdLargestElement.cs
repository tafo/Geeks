using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Third largest element"
    /// 
    /// Given an array of distinct elements.
    /// Your task is to find the third largest element in it.
    /// You have to complete the function thirdLargest which takes two argument.
    /// The first argument is the array a[] and the second argument is the size of the array (n).
    /// The function returns an integer denoting the third largest element in the array a[].
    /// The function should return -1 if there are less than 3 elements in input.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow. The first line of each test case is N, size of array.
    /// The second line of each test case contains N space separated values of the array a[].
    /// 
    /// Output:
    /// Output for each test case will be the third-largest element of the array.
    /// 
    /// Your Task:
    /// You don't need to read input or print anything.
    /// Complete the function thirdLargest()
    ///     * accepts the array and number of elements as arguments
    ///     * returns the third largest element of the array
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 10e5
    /// 1 ≤ A[i] ≤ 10e5
    /// 
    /// Example(To be used for only expected output):
    /// Input:
    /// 2
    /// 5
    /// 2 4 1 3 5
    /// 2
    /// 10 2
    /// Output:
    /// 3
    /// -1
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ThirdLargestElement
    {
        /// <summary>
        /// * Using LINQ
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var result = -1;
                if (int.Parse(test[0]) > 2)
                {
                    result = test[1].Split(' ').Select(int.Parse).OrderByDescending(x => x).Skip(2).First();
                }
                Console.WriteLine(result);
            }
        }

        public static void RunForTest()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                // var n = int.Parse(test[0]); Skip the number of elements. Because argument "n" does not exists for JAVA
                var numbers = test[1].Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine(ThirdLargest(numbers));
            }
        }

        /// <summary>
        /// The execution time of the equivalent JAVA function is 1.44
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        // ReSharper disable once SuggestBaseTypeForParameter
        private static int ThirdLargest(int[] array)
        {
            var third = -1;
            if (array.Length < 3) return third;

            var first = array[0];
            var second = 0;

            for (var i = 1; i < array.Length; i++)
            {
                if (array[i] <= third) continue;

                if (array[i] > second)
                {
                    third = second;
                    if (array[i] > first)
                    {
                        second = first;
                        first = array[i];
                    }
                    else
                    {
                        second = array[i];
                    }
                }
                else
                {
                    third = array[i];
                }
            }

            return third;
        }
    }
}