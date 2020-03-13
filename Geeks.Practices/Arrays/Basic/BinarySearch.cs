using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Binary Search"
    ///     C# option is not available @ "06 Mar 2020"
    /// 
    /// Given a sorted array A[](0 based index) and a key "k" you need to determine the position of the key if the key is present in the array.
    /// If the key is not present then you have to return -1.
    /// The arguments left and right denotes the left most index and right most index of the array A[].
    /// There are multiple test cases. For each test case, this function will be called individually.
    /// 
    /// Implement following method (C++)
    ///     int bin_search(int A[], int left, int right, int k)
    /// 
    /// Input:
    /// The first line contains an integer 'T' denoting the number of test cases.
    /// Then 'T' test cases follow.
    /// Each test case consists of 3 lines.
    ///     The first line of each test case contains an integer N denoting the size of the array.
    ///     The second line of each test case consists of 'N' space separated integers denoting the elements of the array A[].
    ///     The third line contains a key 'k' .
    /// 
    /// Output:
    /// Prints the position of the key if its present in the array else print -1 if the key is not present in the array.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 200
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 2 3 4 5 
    /// 4
    /// 5
    /// 11 22 33 44 55
    /// 445
    /// 
    /// Output:
    /// 3
    /// -1
    ///
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// Implementation with C++
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// //int bin_search(int A[], int left, int right, int k)
    /// //{
    /// //    while (true)
    /// //    {
    /// //        if (left == right)
    /// //        {
    /// //            if (k == A[left])
    /// //            {
    /// //                return left;
    /// //            }
    /// 
    /// //            return -1;
    /// //        }
    /// 
    /// //        int index = (left + right) / 2;
    /// //        if (k == A[index])
    /// //        {
    /// //            return index;
    /// //        }
    /// 
    /// //        if (k > A[index])
    /// //        {
    /// //            left = index + 1;
    /// //            continue;
    /// //        }
    /// 
    /// //        right -= 1;
    /// //    }
    /// //}
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    internal class BinarySearch
    {
        /// <summary>
        /// The execution time is 0.01
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[3];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
                input[i][2] = Console.ReadLine();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = new int[n];
                var key = int.Parse(testCase[2]);
                var scanner = new StringScanner(testCase[1]);

                var index = 0;
                while (scanner.HasNext)
                {
                    elements[index++] = scanner.NextPositiveInt();
                }

                Console.WriteLine(BinSearch(elements, 0, n - 1, key));
            }
        }

        private static int BinSearch(IReadOnlyList<int> elements, int left, int right, int key)
        {
            while (true)
            {
                if (left == right)
                {
                    if (key == elements[left])
                    {
                        return left;
                    }

                    return -1;
                }

                var index = (left + right) / 2;
                if (key == elements[index])
                {
                    return index;
                }

                if (key > elements[index])
                {
                    left = index + 1;
                    continue;
                }

                right -= 1;
            }
        }
    }
}