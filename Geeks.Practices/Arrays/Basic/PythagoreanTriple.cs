using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The original title of the practice is "Pythagorean Triplet"
    /// 
    /// Given an array of integers, write a function that returns true if there is a triplet (a, b, c) that satisfies a2 + b2 = c2.
    /// 
    /// Input:
    /// The first line contains T, denoting the number of test cases. Then follows description of test cases.
    /// Each case begins with a single positive integer N denoting the size of array.
    /// The second line contains the N space separated positive integers denoting the elements of array A.
    /// 
    /// Output:
    /// For each test case, print "Yes" or  "No" whether it is Pythagorean Triplet or not (without quotes).
    ///
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= A[i] <= 1000
    ///
    /// Sample Input:
    /// 2
    /// 19
    /// 93 39 80 91 58 59 92 16 89 57 12 3 35 73 56 29 47 63 87 
    /// 94
    /// 67 50 94 96 98 17 87 6 89 83 56 35 15 2 17 72 87 64 14 56 86 54 13 9 33 46 14 57 22 59 47 83 82 45 97 23 30 62 36 51 74 67 45 60 93 40 54 25 55 11 46 50 87 14 75 23 69 19 88 6 59 92 3 26 78 15 15 25 35 75 73 60 34 71 88 98 19 78 74 71 64 69 93 86 3 81 14 28 3 100 28 26 44 25
    /// Yes
    /// Yes
    /// 
    /// Check :
    ///  https://en.wikipedia.org/wiki/Pythagorean_triple
    ///  https://en.wikipedia.org/wiki/Formulas_for_generating_Pythagorean_triples
    ///
    /// I really liked this practice :)
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "InvertIf")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class PythagoreanTriple
    {
        /// <summary>
        /// If the elements of the array are not unique.
        /// The solution without using Euclid's formula
        /// </summary>
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t];

            for (var i = 0; i < t; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                input[i] = Console.ReadLine(); // The elements
            }

            foreach (var testCase in input)
            {
                var elements = testCase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var numbers = new int[elements.Length];

                for (var i = 0; i < elements.Length; i++)
                {
                    var number = int.Parse(elements[i]);
                    numbers[i] = number * number;
                }

                Array.Sort(numbers);

                var result = "No";
                var n = numbers.Length;
                var c = n - 1;
                while (c > 1)
                {
                    var b = c - 1;
                    var a = 0;
                    while (a < b)
                    {
                        var total = numbers[a] + numbers[b];
                        if (total == numbers[c])
                        {
                            result = "Yes";
                            goto endLoop;
                        }

                        if (total < numbers[c])
                        {
                            a++;
                        }
                        else
                        {
                            b--;
                        }
                    }

                    c--;
                }
                endLoop:
                Console.WriteLine(result);
            }
        }
        /// <summary>
        /// If the elements of the array are not unique.
        /// The execution time of this solution is 0.31
        /// </summary>
        internal static void Run2()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t];

            for (var i = 0; i < t; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                input[i] = Console.ReadLine(); // The elements
            }

            var triples = new int[1000, 6];
            var k = 0;
            const int upperLimit = 1000;
            for (var m = (int)Math.Sqrt(upperLimit); m > 1; m--)
            {
                for (var n = 1; n < m; n++)
                {
                    var c = m * m + n * n;
                    if (c > upperLimit)
                    {
                        break;
                    }
                    if (n.GCD(m) == 1 && (n & 1) + (m & 1) < 2)
                    {
                        var factor = 1;
                        while (c * factor <= upperLimit)
                        {
                            triples[k, 0] = factor * (m * m - n * n);
                            triples[k, 1] = factor * 2 * m * n;
                            triples[k++, 2] = factor++ * c;
                        }
                    }

                }
            }

            // Now, k is equal to the number of triples whose integers are less than 1000
            // Check http://mathworld.wolfram.com/PythagoreanTriple.html
            // >> the number of triples with hypotenuse <=1000 is 881. And k = 881

            for (var index = 0; index < input.Length; index++)
            {
                var result = "No";
                var scanner = new StringScanner(input[index]);
                while (scanner.HasNext)
                {
                    var number = scanner.NextUInt();
                    for (var i = 0; i < k; i++)
                    {
                        if (triples[i, 0] == number)
                        {
                            triples[i, 3] = 1;
                        }
                        else if (triples[i, 1] == number)
                        {
                            triples[i, 4] = 1;
                        }
                        else if (triples[i, 2] == number)
                        {
                            triples[i, 5] = 1;
                        }

                        if (triples[i, 3] + triples[i, 4] + triples[i, 5] == 3)
                        {
                            scanner.HasNext = false;
                            result = "Yes";
                            break;
                        }
                    }
                }

                if (index < input.Length - 1)
                {
                    for (var i = 0; i < k; i++)
                    {
                        triples[i, 3] = triples[i, 4] = triples[i, 5] = 0;
                    }
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// If the elements of the array are unique
        /// </summary>
        internal static void Run1()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t];

            for (var i = 0; i < t; i++)
            {
                Console.ReadLine(); // Skip the number of elements
                input[i] = Console.ReadLine(); // The elements
            }

            var triples = new int[1000, 4];
            var k = 0;
            const int upperLimit = 1000;
            for (var m = (int)Math.Sqrt(upperLimit); m > 1; m--)
            {
                for (var n = 1; n < m; n++)
                {
                    var c = m * m + n * n;
                    if (c > upperLimit)
                    {
                        break;
                    }
                    if (n.GCD(m) == 1 && (n & 1) + (m & 1) < 2)
                    {
                        var factor = 1;
                        while (c * factor <= upperLimit)
                        {
                            triples[k, 0] = factor * (m * m - n * n);
                            triples[k, 1] = factor * 2 * m * n;
                            triples[k++, 2] = factor++ * c;
                        }
                    }

                }
            }

            // Now, k is equal to the number of triples whose integers are less than 1000
            // Check http://mathworld.wolfram.com/PythagoreanTriple.html
            // >> the number of triples with hypotenuse <=1000 is 881. And k = 881

            foreach (var elements in input)
            {
                var scanner = new StringScanner(elements);
                var result = "No";
                while (scanner.HasNext)
                {
                    var number = scanner.NextUInt();
                    for (var i = 0; i < k; i++)
                    {
                        if (triples[i, 0] == number || triples[i, 1] == number || triples[i, 2] == number)
                        {
                            if (triples[i, 3] == 2)
                            {
                                result = "Yes";
                                scanner.HasNext = false;
                                break;
                            }
                            triples[i, 3] += 1;
                        }
                    }
                }

                for (var i = 0; i < k; i++)
                {
                    triples[i, 3] = 0;
                }

                Console.WriteLine(result);
            }
        }
    }
}