using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Make Co-prime Array"
    /// 
    /// Given an array of N elements, find the minimum number of insertions to convert the given array into a co-prime array pair-wise.
    /// 
    /// Input:
    /// The first line of the input contains an integer T, denoting number of test cases.
    /// The first line of each test case contains an integer N denoting the size of the array.
    /// The second line of each test cases N space separated integers.
    /// 
    /// Output:
    /// For each test case, print a single line of output containing minimum no. of insertions.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=100
    /// 1<=arr<=1000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 3
    /// 2 7 28
    /// 3
    /// 5 10 20
    /// 15
    /// 988 857 744 492 228 366 860 937 433 552 438 229 276 408 475 
    /// 22
    /// 859 396 30 238 236 794 819 429 144 12 929 530 777 405 444 764 614 539 607 841 905 819
    /// 
    /// Output:
    /// 1
    /// 2
    /// 6
    /// 11
    /// 
    /// Explanation:
    /// Testcase 1:
    /// Here, 1st pair = {2, 7} are co-primes( gcd(2, 7) = 1).
    /// 2nd pair = {7, 28} are not co-primes, insert 9
    /// between them. gcd(7, 9) = 1 and gcd(9, 28) = 1.
    /// 
    /// Testcase 2:
    /// Here, there is no pair which are co-primes.
    /// Insert 7 between (5, 10) and 1 between (10, 20).
    ///
    /// Remarks:
    /// 1:
    /// If we insert 1 between two numbers that are not coprime, we get coprime adjacent pairs.
    /// So the result is the number of pairs whose greatest common divisor is greater than 1.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountNotCoPrimeAdjacentPairs
    {
        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine(); // Skip the number of elements
                var input = Console.ReadLine().TrimEnd();
                var numbers = input.Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine(numbers.Skip(1).Where((x,i) => x.GCD(numbers[i]) > 1).Count());
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine(); // Skip the number of elements
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var previous = scanner.NextPositiveInt();
                var counter = 0;
                while (scanner.HasNext)
                {
                    var current = scanner.NextPositiveInt();
                    if (current.GCD(previous) > 1)
                    {
                        counter++;
                    }

                    previous = current;
                }

                Console.WriteLine(counter);
            }
        }
    }
}