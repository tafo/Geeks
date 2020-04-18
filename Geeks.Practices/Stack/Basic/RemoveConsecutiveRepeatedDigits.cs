using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Stack.Basic
{
    /// <summary>
    /// The title is "Remove repeated digits in a given number"
    /// 
    /// Given an integer N, remove consecutive repeated digits from it.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// The first line of each test case contains the integer N.
    /// 
    /// Output:
    /// Print the number after removing consecutive digits. Print the answer for each test case in a new line.
    /// 
    /// 
    /// Constraints:
    /// 1<= T <=100
    /// 1<= N <=10e18
    /// 
    /// Example:
    /// Input:
    /// 1
    /// 12224
    /// 
    /// Output:
    /// 124
    ///
    /// Remark:
    /// Use Stack
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class RemoveConsecutiveRepeatedDigits
    {
        /// <summary>
        /// The execution time is 0.17
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine(); // Skip the number of elements
                var digits = Console.ReadLine().TrimEnd();
                var stack = new Stack<char>();
                stack.Push(digits.Last());
                for (var i = digits.Length - 2; i >= 0; i--)
                {
                    if (stack.Peek() != digits[i])
                    {
                        stack.Push(digits[i]);
                    }
                }

                while (stack.Count > 0)
                {
                    Console.Write(stack.Pop());
                }

                Console.WriteLine();
            }
        }
    }
}