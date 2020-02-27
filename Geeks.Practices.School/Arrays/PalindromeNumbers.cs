using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    ///
    /// A palindromic number is a number that remains the same when its digits are reversed. Like 16461. It is "symmetrical".
    /// 233 is not a palindromic number. Because, when its digits are reversed the result will be different than 233 (!= 322).
    /// 
    /// Given a Integer array A[] of n elements.
    /// Print TRUE if all the elements of the Array are palindrome otherwise print FALSE.
    /// 
    /// Input:
    /// The first line of input contains an integer denoting the no of test cases.
    /// Then T test cases follow. Each test case contains two lines.
    /// The first line of input contains an integer n denoting the size of the arrays.
    /// In the second line are N space separated values of the array A[].
    /// 
    /// Output:
    /// For each test case in a new line print the required result.
    /// </summary>
    public class PalindromeNumbers
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new int[t][];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                input[i] = new int[n];
                var elements = Console.ReadLine().Trim().Split(' ');
                for (var k = 0; k < elements.Length; k++)
                {
                    input[i][k] = int.Parse(elements[k]);
                }
            }

            foreach (var elements in input)
            {
                var isPalindromic = true;
                // ReSharper disable once ForCanBeConvertedToForeach
                for (var i = 0; i < elements.Length; i++)
                {
                    var number = elements[i];
                    double reversedNumber = 0;
                    while (number > 0)
                    {
                        reversedNumber = reversedNumber * 10 + (number % 10);
                        number /= 10;
                    }

                    if (elements[i] == (int)reversedNumber)
                    {
                        continue;
                    }

                    isPalindromic = false;
                    break;
                }
                Console.WriteLine("Is palindromic array? = {0}", isPalindromic);
            }

            Console.ReadKey();
        }
    }
}