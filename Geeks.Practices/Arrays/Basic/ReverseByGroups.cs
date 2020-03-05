using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title of the practice is "Reverse array in groups"
    /// 
    /// Given an array arr[] of positive integers of size N. Reverse every sub-array of K group elements.
    /// 
    /// Input:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of two lines of input.
    ///     The first line of each test case consists of an integer N(size of array) and an integer K separated by a space.
    ///     The second line of each test case contains N space separated integers denoting the array elements.
    /// 
    /// Output:
    /// For each test case, print the modified array.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 200
    /// 1 ≤ N, K ≤ 10e7
    /// 1 ≤ A[i] ≤ 10e18
    /// 
    /// Example:
    /// Input
    /// 2
    /// 5 3
    /// 1 2 3 4 5
    /// 6 2
    /// 10 20 30 40 50 60
    /// 
    /// Output
    /// 3 2 1 5 4
    /// 20 10 40 30 60 50
    /// 
    /// Test case 1:
    /// Reversing groups in size 3,
    ///     The first group consists of elements 1, 2, 3. Reversing this group, we have elements in order as 3, 2, 1.
    ///     The second group consists of elements 4, 5. Reversing this group, we have elements in order as 5,4.
    ///     So, the result will be 3, 2, 1, 5, 4
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class ReverseByGroups
    {
        /// <summary>
        /// For fun
        /// The execution time is 0.58
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
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var elements = new long[n];
                var k = int.Parse(split[1]);
                var scanner = new StringScanner(testCase[1]);
                var group = n / k;

                for (var i = 0; i < group; i++)
                {
                    var step = i * k;
                    for (var j = k - 1; j >= 0; j--)
                    {
                        elements[step + j] = scanner.NextInt64();
                    }
                }

                for (var i = n - 1; i >= k * group; i--)
                {
                    elements[i] = scanner.NextInt64();
                }

                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// For fun
        /// The execution time is 0.57 !!!
        /// </summary>
        internal static void Run6()
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
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var elements = new long[n];
                var k = int.Parse(split[1]);
                var scanner = new StringScanner(testCase[1]);
                var step = 0;
                while (scanner.HasNext)
                {
                    var sub = 0;
                    step += k;
                    if (step > n)
                    {
                        step = n;
                    }
                    do
                    {
                        elements[step - ++sub] = scanner.NextInt64();
                    } while (sub < k && scanner.HasNext);
                }

                Console.WriteLine(string.Join(' ', elements));
            }
        }

        /// <summary>
        /// For fun
        /// </summary>
        internal static void Run5()
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
                var resultBuilder = new StringBuilder();
                var k = int.Parse(testCase[0].Split(' ')[1]);
                var group = new long[k];
                var scanner = new StringScanner(testCase[1]);
                var g = 0;

                while (scanner.HasNext)
                {
                    do
                    {
                        group[g++] = scanner.NextInt64();
                    } while (g < k && scanner.HasNext);

                    do
                    {
                        resultBuilder.Append(group[--g]);
                        resultBuilder.Append(" ");
                    } while (g > 0);
                }

                Console.WriteLine(resultBuilder.ToString().TrimEnd());
            }
        }

        /// <summary>
        /// For fun
        /// The execution time is 0.78
        /// </summary>
        internal static void Run4()
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
                var resultBuilder = new StringBuilder();
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var group = new string[k];
                var elements = testCase[1].Split(' ');
                var g = 0;
                var i = 0;

                while (i < n)
                {
                    do
                    {
                        group[g++] = elements[i++];
                    } while (g < k && i < n);

                    do
                    {
                        resultBuilder.Append(group[--g]);
                        resultBuilder.Append(" ");
                    } while (g > 0);
                }

                Console.WriteLine(resultBuilder.ToString().TrimEnd());
            }
        }

        /// <summary>
        /// For fun
        /// The execution time is 0.65
        /// </summary>
        internal static void Run3()
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
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var elements = testCase[1].Split(' ');
                var reversedElements = new string[n];
                var step = k;
                var sub = 0;

                foreach (var element in elements)
                {
                    if (step > n)
                    {
                        step = n;
                    }

                    reversedElements[step - ++sub] = element;

                    if (sub != k) continue;

                    step += k;
                    sub = 0;
                }

                Console.WriteLine(string.Join(' ', reversedElements));
            }
        }

        /// <summary>
        /// This is not the best solution!
        /// The execution time is 0.67
        /// </summary>
        internal static void Run2()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine().Split(' ')[1];
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var k = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ');
                var resultBuilder = new StringBuilder();

                var n = elements.Length;
                var x = n / k;
                for (var i = 0; i < x; i++)
                {
                    Array.Reverse(elements, i * k, k);
                }

                var position = x * k;

                if (n > position)
                {
                    Array.Reverse(elements, position, n - position);
                }

                foreach (var element in elements)
                {
                    resultBuilder.Append(element);
                    resultBuilder.Append(" ");
                }

                Console.WriteLine(resultBuilder.ToString().TrimEnd());
            }
        }

        /// <summary>
        /// This is not the best solution!
        /// The execution time is 0.69
        /// </summary>
        internal static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine().Split(' ')[1];
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var k = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ');
                var resultBuilder = new StringBuilder();

                var n = elements.Length;
                var x = n / k;

                for (var i = 0; i < x; i++)
                {
                    for (var j = k - 1; j >= 0; j--)
                    {
                        resultBuilder.Append(elements[k * i + j]);
                        resultBuilder.Append(" ");
                    }
                }

                if (n > x * k)
                {
                    for (var i = n - 1; i >= x * k; i--)
                    {
                        resultBuilder.Append(elements[i]);
                        resultBuilder.Append(" ");
                    }
                }

                Console.WriteLine(resultBuilder.ToString().TrimEnd());
            }
        }
    }
}