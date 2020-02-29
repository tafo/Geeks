using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.School
{
    /// <summary>
    /// ToDo : Fix the original problem statement.
    /// (The original title of the problem is "Fascinating Number")
    ///
    /// Given a number N. Your task is to check whether it is fascinating or not.
    /// Fascinating Number : When a number(3 digit or more) is multiplied by 2 and 3,
    ///     and when both these products are concatenated with the original number,
    ///         then it results in all digits from 1 to 9 present exactly once.
    /// 
    /// Input:
    /// First line contains number of test cases T. Then following T lines contains a positive integer N.
    /// 
    /// Output:
    /// Print "1" (without quotes) if given number is fascinating else "0" (without quotes).
    ///
    /// ReSharper disable once CommentTypo
    /// Even if the above problem statement the submitted code is evaluated with below outputs
    ///     "Fascinating"
    ///     "Not Fascinating"
    ///     "Number should be atleast three digits"
    /// </summary>
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    internal class FascinatingNumber
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new string[t];

            // The character encodings for digits starts from 48 >> 48 ('0') to 57 ('9')
            const char sub = '0';
            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                if (n < 100)
                {
                    // Actually, "... atleast ..." should be "... at least ..."
                    results[i] = "Number should be atleast three digits";
                    continue;
                }

                var testNumber = string.Empty + n + n * 2 + n * 3;
                var digitList = new int[10];

                foreach (var digit in testNumber)
                {
                    digitList[digit - sub] += 1;
                }

                results[i] = "Fascinating";
                for (var k = 1; k <= 9; k++)
                {
                    if (digitList[k] == 1) continue;
                    results[i] = "Not Fascinating";
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