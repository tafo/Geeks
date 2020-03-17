using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Count triplets with sum smaller than X"
    /// 
    /// Given an array A of distinct integers and a sum value X.
    /// Find count of triplets with sum smaller than given sum value X.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// First line of every test case consists of N and X, denoting the number of elements in array and Sum Value respectively.
    /// Second line consists of array elements.
    /// 
    /// Output:
    /// For each test case, output the count of Triplets.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= Ai <= 10e8
    /// 1 <= X <= 10e10
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 4 2
    /// -2 0 1 3
    /// 5 12
    /// 5 1 4 3 7
    /// 
    /// Output:
    /// 2
    /// 4
    /// 
    /// Explanation:
    /// Testcase 1: -2, 0, 1 and -2, 3, 0 makes triplets with sum less than 2.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class TripleSum
    {
        /// <summary>
        /// The execution time is 0.19
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var key = int.Parse(split[1]);
                var numbers = StringScanner.GetIntegers(test[1], n);
                Array.Sort(numbers);
                var count = 0;
                var a = 0;
                while (a < n - 2)
                {
                    var b = a + 1;
                    while (b < n - 1)
                    {
                        var c = b + 1;
                        while (c < n)
                        {
                            if (numbers[a] + numbers[b] + numbers[c] < key)
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }

                            c++;
                        }

                        b++;
                    }

                    a++;
                }
                Console.WriteLine(count);
            }
        }
    }
}