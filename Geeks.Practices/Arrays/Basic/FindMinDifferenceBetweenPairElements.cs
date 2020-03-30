using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Tough Competitors"
    /// 
    /// There are N competitors in an exam.
    /// Each competitor has his own skill value which is given by the array s=s1,s2,....sN
    ///     where s1 is the skill of the first competitor, s2 is the skill of second competitor and so on.
    /// Two competitors are said to be tough competitors if their skill difference is least
    ///     i.e. they are very close in their skill values.
    /// Given N and an array s as input,
    /// Find the tough competitors among the N competitors and print the absolute of the difference of their skill values.
    /// 
    /// Input:
    /// First line of the input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// First line of every test case consists of an integer N, denoting number of competitors.
    /// Second line of every test case consists of N spaced separated integers, denoting the skill values of the competitors.
    /// 
    /// Output:
    /// Corresponding to each test case, print the difference of the skill values of the tough competitors in a new line.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 2<=N<=100
    /// 1<=Si<=10000
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 4
    /// 9 4 12 6
    /// 5
    /// 4 9 1 32 12
    /// 2
    /// 8661 6623 
    /// 5
    /// 2868 7446 3209 5808 3487
    /// 
    /// Output:
    /// 2
    /// 3
    /// 2038
    /// 278
    /// 
    /// Explanation:
    /// In the first case |9-4|=5 ,|9-12|=3,|9-6|=3,|4-12|=8,|4-6|=2,|12-6|=6
    ///     The tough competitors are competitors having skill values 4,6 having their skill difference as 2.
    /// In the second case tough competitors are competitors having skill values (4,1) and (9,12)  having their skill difference as 3.
    ///
    ///  Remarks:
    /// 1) The problem statement is not clear. Solutions are fixed. 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindMinDifferenceBetweenPairElements
    {
        /// <summary>
        /// The execution time is 0.13
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
                var numbers = new int[n];
                var i = 0;
                numbers[i++] = scanner.NextPositiveInt();
                numbers[i++] = scanner.NextPositiveInt();
                var min = Math.Abs(numbers[1] - numbers[0]);
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    for (var a = 0; a < i; a++)
                    {
                        min = Math.Min(min, Math.Abs(number - numbers[a]));
                    }

                    numbers[i++] = number;
                }

                Console.WriteLine(min);
            }
        }
    }
}