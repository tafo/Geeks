using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Count the numbers"
    /// 
    /// Given a number N, count the numbers from 1 to N which comprise of digits, only in set 1, 2, 3, 4 and 5. 
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of one line.
    /// Each line of each test case is N, where N is the range from 1 to N.
    /// 
    /// Output:
    /// Print the count of numbers in the given range from 1 to N.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 10e3
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 100
    /// 10
    /// Output:
    /// 30
    /// 5
    /// 
    /// Explanation:
    /// When N is 20 then answer is 10 because 1 2 3 4 5 11 12 13 14 15 are only in given set.
    /// 16 is not because 6 is not in given set, only 1 2 3 4 5 in set.
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountQualifiedNumbers
    {
        /// <summary>
        /// The execution time is 0.12
        /// * Compare this solution with RunThis
        /// </summary>
        public static void RunCompare()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = int.Parse(Console.ReadLine());
            }

            foreach (var test in tests)
            {
                var count = 0;
                for (var i = 1; i <= test; i++)
                {
                    var k = i;
                    do
                    {
                        var d = k % 10;
                        if (d == 1 || d == 2 || d == 3 || d == 4 || d == 5)
                        {
                            k /= 10;
                        }
                        else
                        {
                            count++;
                            break;
                        }

                    } while (k > 0);
                }

                Console.WriteLine(test - count);
            }
        }

        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void RunThis()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = int.Parse(Console.ReadLine());
            }

            foreach (var test in tests)
            {
                var count = 0;
                for (var i = 1; i <= test; i++)
                {
                    var k = i;
                    var result = 1;
                    do
                    {
                        var d = k % 10;
                        if (d == 1 || d == 2 || d == 3 || d == 4 || d == 5)
                        {
                            k /= 10;
                        }
                        else
                        {
                            result = 0;
                            break;
                        }

                    } while (k > 0);
                    count += result;
                }

                Console.WriteLine(count);
            }
        }

        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunSingleLine()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = int.Parse(Console.ReadLine());
            }

            foreach (var test in tests)
            {
                Console.WriteLine(Enumerable.Range(1, test).Count(x => x.ToString().Select(c => c - '0').All(d => d > 0 && d < 6)));
            }
        }

        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = int.Parse(Console.ReadLine());
            }

            foreach (var test in tests)
            {
                var set = Enumerable.Range(1, 5).ToArray();
                var result = 0;
                foreach (var n in Enumerable.Range(1, test))
                {
                    var k = n;
                    var i = 1;
                    do
                    {
                        if (!set.Contains(k % 10))
                        {
                            i = 0;
                            break;
                        }

                        k /= 10;
                    } while (k > 0);

                    result += i;
                }

                Console.WriteLine(result);
            }
        }
    }
}