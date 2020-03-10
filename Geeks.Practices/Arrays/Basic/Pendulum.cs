using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Print an array in Pendulum Arrangement"
    /// 
    /// Write a program to input a list of n integers in an array and arrange them in a way similar to the to-and-fro movement of a Pendulum.
    /// 
    /// The minimum element out of the list of integers, must come in center position of array.
    /// If there are even elements, then minimum element should be moved to (n-1)/2 index (considering that indexes start from 0)
    /// The next number (next to minimum) in the ascending order, goes to the right,
    ///     the next to next number goes to the left of minimum number and it continues like a Pendulum.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case contains an integer n denoting the size of the array.
    /// Then next line contains N space separated integers forming the array.
    /// 
    /// Output:
    /// Output the array in Pendulum Arrangement.
    /// 
    /// Constraints:
    /// 1<=T<=500
    /// 1<=N<=100
    /// 1<=a[i]<=1000
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 3 2 5 4
    /// 5
    /// 11 12 31 14 5
    /// 
    /// Output:
    /// 5 3 1 2 4
    /// 31 12 5 11 14
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Pendulum
    {
        /// <summary>
        /// The execution time is 0.11
        /// </summary>
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ').Select(int.Parse).OrderByDescending(x => x).ToArray();
                var pendulum = new int[n];
                var index = 0;
                var flag = (n & 1) == 1;
                foreach (var element in elements)
                {
                    if (flag)
                    {
                        pendulum[index++] = element;
                        
                    }
                    else
                    {
                        pendulum[--n] = element;
                    }
                    flag = !flag;
                }

                Console.WriteLine(string.Join(' ', pendulum));
            }
        }
    }
}