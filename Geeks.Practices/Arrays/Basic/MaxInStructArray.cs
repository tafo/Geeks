using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Maximum in Struct Array"
    /// 
    /// Given a struct array of type Height, having two elements feet and inches.
    /// Find the maximum height, where height is calculated sum of feet and inches after converting feet into inches.
    /// 
    /// Input:
    /// First line of input contains number of test cases.
    /// For each test case, first line of input contains N, number of given heights.
    /// Next line contains 2*N number of elements (feet and inches for each N).
    /// 
    /// Output:
    /// Output maximum height from array.
    /// 
    /// Your Task: Your task is to only complete the function of find maximum height from given array.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10e5
    /// 0<=Feet, Inches<=10e5
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 2
    /// 1 2 2 1
    /// 4
    /// 3 5 7 9 5 6 5 5
    /// Output:
    /// 25
    /// 93
    /// 
    /// Explanation:
    /// Testcase 1:
    /// (1, 2) and (2, 1) are respective given heights.
    /// After converting both heigths in to inches, we get 14 and 25 as respective heights.
    /// So, 25 is the maximum height.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MaxInStructArray
    {
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
                var elements = new Height[n];
                var i = 0;
                while (scanner.HasNext)
                {
                    elements[i++] = new Height(scanner.NextPositiveInt(), scanner.NextPositiveInt());
                }

                Console.WriteLine(FindMax(elements, n));
            }
        }

        /// <summary>
        /// The execution time of the equivalent JAVA function is 0.47
        /// </summary>
        // ReSharper disable once SuggestBaseTypeForParameter
        private static int FindMax(Height[] array, int n)
        {
            var max = 0;

            for (var i = 0; i < n; i++)
            {
                var total = array[i].Feet * 12 + array[i].Inches;
                if (total > max)
                {
                    max = total;
                }
            }

            return max;
        }
    }

    internal struct Height
    {
        public int Feet;
        public int Inches;
        public Height(int ft, int inc)
        {
            Feet = ft;
            Inches = inc;
        }
    }
}