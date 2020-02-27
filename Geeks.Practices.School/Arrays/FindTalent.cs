using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// A and B are good friends and coders.
    /// They are always in a healthy competition with each other.
    /// Compare their three skills. 
    /// 
    /// Compare Kth skill of A with Kth skill of B
    /// if A[k] > B[k], score(A)+1
    /// if A[k] < B[k], score(B)+1
    /// 
    /// Input 
    /// The first line of input contains the number of test cases.
    /// For each test case there will be two lines.
    ///     The first line contains A's three skill levels.
    ///     The second line contains B's three skill levels.
    /// 
    /// Output
    /// For each test case print the score of A and B separated by space in a new line.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    internal class FindTalent
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            for (var i = 0; i < t; i++)
            {
                var first = Console.ReadLine().Split(' ');
                var second = Console.ReadLine().Split(' ');

                var firstScore = 0;
                var secondScore = 0;
                for (var k = 0; k < 3; k++)
                {
                    if (int.Parse(first[k]) > int.Parse(second[k]))
                    {
                        firstScore++;
                    }
                    else if (int.Parse(first[k]) < int.Parse(second[k]))
                    {
                        secondScore++;
                    }
                }

                results[i] = $"{firstScore} {secondScore}";
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}