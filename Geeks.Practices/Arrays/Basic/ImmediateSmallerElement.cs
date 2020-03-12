using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The original title of the problem is "Immediate Smaller Element"
    /// 
    /// Given an integer array of size N. For each element in the array, check whether the right adjacent element of the array is smaller.
    ///     If next element is smaller, print that element. If not, then print -1 instead of it.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains 2 lines of input:
    ///     The first line contains an integer N, where N is the size of array.
    ///     The second line contains N integers(elements of the array) separated with spaces.
    /// 
    /// Output:
    /// For each test case, print the next immediate smaller elements for each element in the array.
    ///
    /// Example Output :
    /// 4 2 1 5 3
    /// >>
    /// 2 1 -1 3 -1
    ///
    /// Note :
    /// For last element, output is always going to be -1 because there is no element on right.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "UseIndexFromEndExpression")]
    internal class ImmediateSmallerElement
    {
        /// <summary>
        /// The execution time of this solution is 0.42
        /// </summary>
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new string[t];

            for (var i = 0; i < t; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                input[i] = Console.ReadLine();
            }

            foreach (var elements in input)
            {
                var stringBuilder = new StringBuilder();
                var scanner = new StringScanner(elements);
                var left = scanner.NextUInt();
                do
                {
                    var right = scanner.NextUInt();
                    if (right < left)
                    {
                        stringBuilder.Append(right);
                    }
                    else
                    {
                        stringBuilder.Append("-1");
                    }

                    stringBuilder.Append(" ");
                    left = right;
                } while (scanner.HasNext);

                stringBuilder.Append("-1");
                Console.WriteLine(stringBuilder.ToString());
            }
        }

        internal static void Run2()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new string[t];

            for (var i = 0; i < t; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                input[i] = Console.ReadLine();
            }

            foreach (var elements in input)
            {
                var stringBuilder = new StringBuilder();
                var reader = new IntegerReader(elements);
                var left = reader.Next();
                do
                {
                    var right = reader.Next();
                    if (right < left)
                    {
                        stringBuilder.Append(right);
                    }
                    else
                    {
                        stringBuilder.Append("-1");
                    }

                    stringBuilder.Append(" ");
                    left = right;
                } while (reader.CurrentPosition != -1);

                stringBuilder.Append("-1");
                Console.WriteLine(stringBuilder.ToString());
            }
        }
    }
}