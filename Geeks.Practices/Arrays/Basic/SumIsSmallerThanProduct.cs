using System;
using System.Diagnostics.CodeAnalysis;
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
    /// 
    /// Output:
    /// 3
    /// 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SumIsSmallerThanProduct
    {
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