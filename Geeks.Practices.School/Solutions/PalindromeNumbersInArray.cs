using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Solutions
{
    public class PalindromeNumbersInArray
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