using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Intersection of two arrays"
    /// 
    /// Given two arrays A and B respectively of size N and M.
    /// The task is to print the count of elements in the intersection (or common elements) of the two arrays.
    /// 
    /// For this question,
    ///     Intersection of two arrays can be defined as the set containing distinct common elements between the two arrays.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// The first line of each test case is N and M, N is the size of array A and M is size of array B.
    /// The second line of each test case contains N input A[i].
    /// The third line of each test case contains M input B[i].
    /// 
    /// Output:
    /// Print the count of intersecting elements.
    /// 
    /// User Task:
    /// The task is to complete the function NumberOfElementsInIntersection which takes 4 inputs
    ///     ie- array a, array b, n which is the size of array a, m which is the size of array b.
    /// The function should return the count of the number of elements in the intersection.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N, M ≤ 10e5
    /// 1 ≤ A[i], B[i] ≤ 10e5
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 5 3
    /// 89 24 75 11 23
    /// 89 2 4
    /// 6 5
    /// 1 2 3 4 5 6
    /// 3 4 5 6 7
    /// 4 4
    /// 10 10 10 10
    /// 20 20 20 20
    /// 3 3
    /// 10 10 10
    /// 10 10 10
    /// 
    /// Output:
    /// 1
    /// 4
    /// 0
    /// 1
    /// Explanation:
    /// Test case 1: 89 is the only element in the intersection of two arrays.
    /// Test case 2: 3 4 5 and 6 are the elements in the intersection of two arrays.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountIntersection
    {
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine();
                var firstInput = Console.ReadLine().TrimEnd();
                var secondInput = Console.ReadLine().TrimEnd();
                var a = firstInput.Split(' ').Select(int.Parse).Distinct();
                var b = secondInput.Split(' ').Select(int.Parse).Distinct();
                Console.WriteLine(a.Intersect(b).Count());
            }

        }

        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var firstInput = Console.ReadLine().TrimEnd();
                var secondInput = Console.ReadLine().TrimEnd();
                var n = int.Parse(split[0]);
                var m = int.Parse(split[1]);
                var a = StringScanner.GetPositiveInt(firstInput, n);
                var b = StringScanner.GetPositiveInt(secondInput, m);
                Console.WriteLine(NumberOfElementsInIntersection(a, b, n, m));
            }
        }

        /// <summary>
        /// The signature of this method is specified by GfG
        /// </summary>
        public static int NumberOfElementsInIntersection(int[] a, int[] b, int n, int m)
        {
            Array.Sort(a);
            Array.Sort(b);

            n--;
            m--;
            var result = 0;
            var previousIntersection = 0;
            while (n >= 0 && m >= 0)
            {
                if (a[n] > b[m])
                {
                    n--;
                }
                else if (a[n] == b[m] && a[n] != previousIntersection)
                {
                    result++;
                    previousIntersection = a[n];
                    n--;
                    m--;
                }
                else
                {
                    m--;
                }
            }

            return result;
        }
    }
}