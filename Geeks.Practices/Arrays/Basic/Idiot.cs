using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Countries at war"
    /// THE AUTHOR OF THIS PROBLEM IS PROBABLY AN IDIOT !!!
    ///     No winner in battle :(
    /// 
    /// The two countries of A and B are at war against each other.
    /// Both countries have N number of soldiers.
    /// The power of these soldiers are given by A[i]...A[N] and B[i]....B[N].
    /// These soldiers have a peculiarity.
    /// They can only attack their counterpart enemies, like A[i] can attack only B[i] and not anyone else.
    /// A soldier with higher power can kill the enemy soldier.
    /// If both soldiers have same power, they both die.
    /// You need to find the count of remaining soldiers of A and B at the end of the war.
    /// Also, print the winner country.
    /// 
    /// Input:
    /// The first line of the input contains a single integer T, denoting the number of test cases.
    /// Then T test case follows.
    /// Each test case contains three lines of input:-
    /// The number of soldiers N.
    /// Powers of A country's soldiers Ai ... AN separated by spaces
    /// Powers of B country's soldiers Bi ... BN separated by spaces
    /// 
    /// Output:
    /// For each test case, print the remaining soldiers of both A and B, and the winner country.
    /// If the remaining soldiers are equal for both countries, the war ends up draw.
    /// See examples for more clarity.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 2000
    /// 0 <= Ai <= 1000
    /// 
    /// Example:
    /// 
    /// Input:
    /// 5
    /// 6
    /// 1 2 3 4 5 6
    /// 6 5 4 3 2 1
    /// 1
    /// 9
    /// 8
    /// 2
    /// 2 2
    /// 5 5
    /// 1
    /// 0
    /// 4
    /// 6
    /// 0 0 0 0 0 0
    /// 0 0 0 0 0 0
    /// 
    /// Output:
    /// 
    /// 3 3 DRAW
    /// 1 0 A
    /// 0 2 B
    /// 0 1 B
    /// 0 0 DRAW
    /// 
    /// Explanation:
    /// Testcase3:
    ///     Both countries have 2 soldiers.
    ///     B[0] kills A[0], B[1] kills A[1].
    ///     A has 0 soldiers alive at the end.
    ///     B has both soldiers alive at the end.
    ///     We print the results and B as winner.
    ///
    /// Remark:
    /// I FEEL SICK WHEN I SEE SUCH A SENTENCE LIKE "A KILLS B" :P
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Idiot
    {
        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                // var n = int.Parse(test[0]); Skip the number of elements
                var leftScanner = new StringScanner(test[1]);
                var rightScanner = new StringScanner(test[2]);
                var a = 0;
                var b = 0;
                while (leftScanner.HasNext)
                {
                    var left = leftScanner.NextPositiveInt();
                    var right = rightScanner.NextPositiveInt();
                    if (left > right)
                    {
                        a++;
                    }
                    else if (left < right)
                    {
                        b++;
                    }
                }

                Console.WriteLine("{0} {1} {2}", a, b, a > b ? "A" : a < b ? "B" : "DRAW");
            }
        }
    }
}