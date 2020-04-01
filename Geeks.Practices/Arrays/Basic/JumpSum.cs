using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Total distance traveled in an array"
    /// 
    /// You are given an array A of size N.
    /// The array A consists of a permutation of the set {1, 2, 3, … , N} for some positive integer N.
    /// You have to start at the position which has 1 in the array and then travel to the position which has 2.
    /// Then from 2, you travel to 3 and so on till you reach the position which has N.
    /// When you travel from A[i] to A[j], the distance traveled is |i– j|.
    /// Your aim is to find the total distance you have to travel to reach N when you start from 1.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains two lines of input.
    /// The first line contains an integer N, where N is the size of the array A[].
    /// The second line contains N space separated integers which denote a permutation of the set  {1, 2, 3, … , N}.
    /// 
    /// Output:
    /// For each test case, print the total distance traveled.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e7
    /// 1 <= Ai <= 10e7
    /// 
    /// Example :
    /// Input:
    /// 2
    /// 5
    /// 5 1 4 3 2 
    /// 6
    /// 6 5 1 2 4 3
    /// 5
    /// 4 1 2 3 5 
    /// 24
    /// 1 10 17 20 9 12 11 15 16 23 7 19 14 3 4 5 18 8 22 21 6 2 13 24
    /// 
    /// Output : 
    /// 7
    /// 8
    /// 9
    /// 181
    /// 
    /// Explanation:
    /// Testcase1: The numbers and their respective indices are given below:
    /// 1->1
    /// 2->4
    /// 3->3
    /// 4->2
    /// 5->0
    /// Total distance =|4-1|+|3-4|+|2-3|+|0-2| = 3+1+1+2 = 7
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class JumpSum
    {
        /// <summary>
        /// The execution time is 0.49
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
                var numbers = StringScanner.GetPositiveInt(test[1], n).Select((x,i) => new{Number = x, Index = i}).OrderBy(x => x.Number).ToArray();
                Console.WriteLine(numbers.Skip(1).Select((x, i) => Math.Abs(x.Index - numbers[i].Index)).Sum());
            }
        }

        /// <summary>
        /// The execution time is 0.45
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
                var n = int.Parse(test[0]);
                var scanner = new StringScanner(test[1]);
                var numbers = new int[n][];
                var i = 0;
                while (scanner.HasNext)
                {
                    numbers[i] = new int[2];
                    numbers[i][0] = scanner.NextPositiveInt();
                    numbers[i++][1] = i;
                }

                Array.Sort(numbers, (x,y) => x[0].CompareTo(y[0]));

                var result = 0;
                for (var a = 1; a < n; a++)
                {
                    result += Math.Abs(numbers[a][1] - numbers[a - 1][1]);
                }

                Console.WriteLine(result);
            }
        }
    }
}