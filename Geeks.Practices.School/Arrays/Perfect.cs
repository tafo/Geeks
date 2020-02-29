using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// ToDo : Fix the original problem statement.
    /// (the original title of the problem is "Perfect Arrays")
    ///
    /// Given an array of size N and you have to tell whether the array is perfect or not.
    ///     An array is said to be perfect if it's reverse array matches the original array.
    /// If the array is perfect then print "PERFECT" else print "NOT PERFECT".
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    ///     First line of each test case contains an integer N (size of the array).
    ///     And the second line contains N elements a0,a1,......aN-1 of an array.
    /// 
    /// Output:
    /// For each test case, print either "PERFECT" or "NOT PERFECT" in new line as your answer.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class Perfect
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                var elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                results[i] = "PERFECT";
                for (var k = 0; k < n / 2; k++)
                {
                    if (elements[k] == elements[^(k + 1)]) continue;
                    results[i] = "NOT PERFECT";
                    break;
                }
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}