using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Finding-Pairs"
    /// 
    /// For N number of alphabet pairs(in upper or lower case),
    ///     count the occurrence of the given alphabet pairs in a string S of size M.
    /// Output the number of pairs found in the string S, out of total N pairs.
    /// Note: Finding the pair means finding both the characters in a particular pair in the string.
    /// 
    /// Input:
    /// First line of input is an integer T, denoting the number of test cases.
    /// For each test case,
    ///     enter two integers N and M on the same line, denoting the number of pairs of alphabets to be searched for
    ///     And the size of the string S, respectively.
    ///     Next line of input comprises of the N alphabet pairs separated by a single space in between.
    ///     The last line of input comprises of the string S of size M.
    /// 
    /// Output:
    /// The output for each test case is an integer that tells the number of pairs (<=N) that occured in the string S.
    /// If no pair is found, the output will be zero.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10
    /// 2<=M<=20
    /// 
    /// Example:
    /// Input:
    /// 5
    /// 3 5
    /// A G d i P o
    /// APiod
    /// 1 3
    /// r e
    /// ghe
    /// 3 6
    /// F E n O F s
    /// FOrnEs
    /// 4 17
    /// r b Q h D R o K 
    /// YidSDrmWrsylbFAcy
    /// 2 7
    /// D G X p 
    /// LRLnPPF
    /// 
    /// Output:
    /// 2
    /// 0
    /// 3
    /// 1
    /// 0
    /// 
    /// Remark:
    /// 1:
    /// The problem statement is not clear !!!
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountQualifiedPairs
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine();
                var pairInput = Console.ReadLine().TrimEnd();
                var text = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(pairInput);
                var counter = 0;
                while (scanner.HasNext)
                {
                    if (text.Contains(scanner.NextChar()) & text.Contains(scanner.NextChar()))
                    {
                        counter++;
                    }
                }

                Console.WriteLine(counter);
            }
        }
    }
}