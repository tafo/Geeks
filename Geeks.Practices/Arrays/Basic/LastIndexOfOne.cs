using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Last index of One"
    /// 
    /// Given a string S consisting only '0's and '1's,  print the last index of the '1' present in it.
    /// 
    /// Input:
    /// First line of the input contains the number of test cases T, T lines follow each containing a stream of characters.
    /// 
    /// Output:
    /// Corresponding to every test case, output the last index of 1. If 1 is not present, print "-1" (without quotes).
    /// 
    /// Constraints:
    /// 1 <= T <= 110
    /// 1 <= |S| <= 10e6
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 00001
    /// 0
    /// Output:
    /// 4
    /// -1
    /// 
    /// Explanation:
    /// Testcase 1: Last index of  1 in given string is 4.
    /// Testcase 2: Since, 1 is not present, so output is -1.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class LastIndexOfOne
    {
        /// <summary>
        /// The execution time is 0.23
        ///     !!! >> When test cases change the execution time will be better than Run1
        /// </summary>
        public static void Run()
        {
            var x = int.Parse(Console.ReadLine());
            var input = new string[x];

            for (var i = 0; i < x; i++)
            {
                input[i] = Console.ReadLine().Trim();
            }

            foreach (var elements in input)
            {
                int index;
                for (index = elements.Length - 1; index >= 0; index--)
                {
                    if (elements[index] == '1')
                    {
                        break;
                    }
                }
                
                Console.WriteLine(index);
            }
        }

        /// <summary>
        /// The execution time is 0.23
        /// </summary>
        public static void Run1()
        {
            var x = int.Parse(Console.ReadLine());
            var input = new string[x];

            for (var i = 0; i < x; i++)
            {
                input[i] = Console.ReadLine().Trim();
            }

            foreach (var elements in input)
            {
                var result = -1;
                
                for (var i = 0; i < elements.Length; i++)
                {
                    if (elements[i] == '1')
                    {
                        result = i;
                    }
                }
                
                Console.WriteLine(result);
            }
        }
    }
}