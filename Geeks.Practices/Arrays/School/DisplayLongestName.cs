using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.School
{
    /// <summary>
    /// Given a list of names, display the longest name.
    /// 
    /// Input:
    /// First line of input contains an integer T, the number of test cases.
    ///
    /// For each test case, there will be (1+N) lines.
    /// First line contains integer N i.e. the total number of names.
    /// Then names will be entered in different lines. 
    /// 
    /// Output:
    /// Longest name in the list of names.
    ///
    /// Anyway!!! ...
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    internal class DisplayLongestName
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new string[t][];
            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                input[i] = new string[n];
                for (var k = 0; k < n; k++)
                {
                    input[i][k] = Console.ReadLine();
                }
            }

            foreach (var elements in input)
            {
                var longestName = elements[0];
                for (var c = 1; c < elements.Length; c++)
                {
                    if (elements[c].Length > longestName.Length)
                    {
                        longestName = elements[c];
                    }
                }
                Console.WriteLine(longestName);
            }

            Console.ReadKey();
        }
    }
}