using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find triplets with zero sum"
    /// 
    /// Given an array A[] of N elements.
    /// The task is to complete the function which returns true if triplets exists in array A whose sum is zero else returns false.
    /// 
    /// Input:
    /// The first line of input contains an integer T, denoting the number of test cases.
    /// Then T test cases follow. The first line of each test case contains an integer N, denoting the number of elements in array.
    /// The second line of each test case contains N space separated values of the array.
    /// 
    /// Output:
    /// For each test case, output will be 1 if triplet exists else 0.
    /// 
    /// Your Task:
    /// Your task is to complete the function findTriplets() which check if the triplet with sum 0 exists or not.
    /// This is of boolean type which returns either true of false.
    /// 
    /// Constrains:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e6
    /// -106 <= A <= 10e6
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 0 -1 2 -3 1
    /// 3
    /// 1 2 3
    /// Output:
    /// 1
    /// 0
    /// 
    /// Explanation:
    /// Testcase 1: 0, -1 and 1 forms a triplet with sum equal to 0.
    /// Testcase 2: No triplet exists which sum to 0.
    /// 
    /// Method Signature:
    /// public boolean findTriplets(int arr[] , int n) { }
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class ZeroSumTriple
    {
        /// <summary>
        /// The execution time is 0.23
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = new int[n];
                var scanner = new StringScanner(testCase[1]);
                var index = 0;
                while (scanner.HasNext)
                {
                    elements[index++] = scanner.NextInt();
                }

                Console.WriteLine(FindTriplets(elements, n));
            }
        }

        private static bool FindTriplets(int[] arr, int n)
        {
            if (n < 3)
            {
                return false;
            }

            Array.Sort(arr);
            var first = 0;
            while (arr[first] <= 0)
            {
                var second = first + 1;
                var third = n - 1;
                while (second < third && arr[third] >= 0)
                {
                    var total = arr[first] + arr[second] + arr[third];
                    if (total == 0)
                    {
                        return true;
                    }

                    if (total < 0)
                    {
                        second++;
                    }
                    else
                    {
                        third--;
                    }
                }

                first++;
            }

            return false;
        }
    }
}