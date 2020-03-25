using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Pair array product sum"
    /// 
    /// Given a array a[] of non-negative integers.
    /// Count the number of pairs (i, j) in the array such that a[i] + a[j] < a[i]*a[j].
    ///     (the pair (i, j) and (j, i) are considered same and i should not be equal to j)
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains an integer n denoting the size of the array.
    /// The next line contains n space separated integers respectively forming the array.
    /// 
    /// Output:
    /// Print the total number of pairs possible in the array according to the problem statement.
    /// 
    /// Constraints:
    /// 1<=T<=10^5
    /// 1<=n<=10^5
    /// 1<=a[i]<=10^5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 3
    /// 3 4 5
    /// 3
    /// 1 1 1 
    /// 15
    /// 88 57 44 92 28 66 60 37 33 52 38 29 76 8 75 
    /// 22
    /// 59 96 30 38 36 94 19 29 44 12 29 30 77 5 44 64 14 39 7 41 5 19
    /// 
    /// Output:
    /// 3
    /// 0
    /// 105
    /// 231
    ///
    /// Remark:
    /// 
    /// We should find x denoting the number of elements that are greater than 1.
    ///     Then find A denoting the binomial coefficient of (x / 2)
    /// We should also find y denoting the number of elements that are equal to 2.
    ///     Then find B denoting the binomial coefficient of (y / 2)
    /// The result is (A - B).
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SumIsSmallerThanProduct
    {
        /// <summary>
        /// The execution time is 0.13
        /// * The result is better than my expectation !!!
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                Console.ReadLine();
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).Where(x => x > 1).ToArray();
            }

            foreach (var test in tests)
            {
                var twoCount = test.Count(x => x == 2);
                Console.WriteLine(test.Length * (test.Length - 1) / 2 - twoCount * (twoCount - 1) / 2);
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// * The result is better than my expectation !!!
        /// </summary>
        public static void RunMix()
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
                var numbers = StringScanner.GetPositiveInt(test[1], n).Where(x => x > 1).ToArray();
                var counter = numbers.Length;
                var twoCount = numbers.Count(x => x == 2);
                Console.WriteLine(counter * (counter - 1) / 2 - twoCount * (twoCount - 1) / 2);
            }
        }

        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void RunLoop()
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
                // var n = int.Parse(test[0]); Skip the number of elements
                var scanner = new StringScanner(test[1]);
                var counter = 0;
                var twoCount = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number < 2) continue;
                    counter++;
                    if (number == 2)
                    {
                        twoCount++;
                    }
                }

                Console.WriteLine(counter * (counter - 1) / 2 - twoCount * (twoCount - 1) / 2);
            }
        }
    }
}