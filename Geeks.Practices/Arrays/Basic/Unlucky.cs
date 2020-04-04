using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Rahul lucky-unlucky"
    /// 
    /// Rahul is a geek.
    /// Head is the lucky call for him.
    /// You have to make him lucky.
    /// You are provided N coins.
    /// If the coin is heads facing upwards it means he is lucky else unlucky, your task is to do an operation to make him lucky.
    /// Operation allowed is as follows :
    /// Starting from first element, if you find any coin heads facing downwards (Tail), flip the coin at ith index and (i+1)th index.  
    /// 
    /// Input:
    /// The first line consists of T test cases.
    /// Each test case consists of 2 lines.
    /// The first line contains an integer N, denoting the number of coins.
    /// The second line contains N coins, represented by H or T (denoting head facing upwards and tail facing upwards respectively).
    /// 
    /// Output:
    /// For each test case, output two lines where first line should contain number of flips,
    ///     while next line contains indexes where coins have been flipped (starting index from 1).
    /// If no coin is flipped, second line prints "-1" (without quotes).
    /// 
    /// Constraints:
    /// 1 <= T <= 10e3
    /// 1 <= N <= 10e7
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 3
    /// H H H
    /// 5 
    /// H T H T H
    /// 10
    /// H H T H H H T H H H T
    /// Output: 
    /// 0
    /// -1
    /// 2
    /// 2 3
    /// 5
    /// 3 4 5 6 10
    /// 
    /// Explanation:
    /// Testcase2: Coins at index 2 and 3 needs to be flipped to make Rahul happy.
    /// Remarks:
    /// 1:
    /// The problem statement is not clear !!!
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Unlucky
    {
        /// <summary>
        /// The execution time is 1.27
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());

            while (testCount-- > 0)
            {
                Console.ReadLine();
                var input = Console.ReadLine().TrimEnd();
                var heads = input.Split(' ').Select((x, i) => new {C = x, Index = i});
                var flag = false;
                var flipped = heads.Where(x => x.C == "T" && (flag = !flag) || (x.C == "H" && flag)).Select(x => x.Index).ToArray();
                Console.WriteLine(flipped.Length);
                Console.WriteLine(string.Join(' ', flipped.DefaultIfEmpty(-1)));
            }
        }

        /// <summary>
        /// The execution time is 0.82
        /// </summary>
        public static void RunAnotherLoop()
        {
            var testCount = int.Parse(Console.ReadLine());

            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var counter = 0;
                var p = 1;
                var positions = new string[n];
                var flag = false;
                while (scanner.HasNext)
                {
                    var coin = scanner.NextChar();
                    if (coin == 'T' && (flag = !flag) || coin == 'H' && flag)
                    {
                        positions[counter++] = $"{p}";
                    }
                    p++;
                }

                Console.WriteLine(counter);
                Console.WriteLine(counter == 0 ? "-1" : string.Join(' ', positions, 0, counter));
            }
        }

        /// <summary>
        /// The execution time is 0.77
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());

            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var counter = 0;
                var p = 1;
                var positions = new string[n];
                var flag = false;
                while (scanner.HasNext)
                {
                    var coin = scanner.NextChar();
                    if (flag)
                    {
                        coin = coin == 'H' ? 'T' : 'H';
                        flag = false;
                    }
                    if (coin == 'T')
                    {
                        positions[counter++] = $"{p}";
                        flag = true;
                    }
                    p++;
                }

                Console.WriteLine(counter);
                Console.WriteLine(counter == 0 ? "-1" : string.Join(' ', positions, 0, counter));
            }
        }
    }
}