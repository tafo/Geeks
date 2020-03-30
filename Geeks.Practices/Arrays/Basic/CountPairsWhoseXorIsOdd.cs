using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Count Pairs Odd Xor"
    /// 
    /// Given an array Arr[] of N integers.
    /// Write a program to find out number of pairs in array whose XOR is odd.
    /// 
    /// Input:
    /// First line of input contains a single integer T which denotes the number of test cases.
    /// Then T test cases follows.
    /// First line of each test case contains a single integer N which denotes the size of array.
    /// Second line of each test case contains N space separated integers which denotes the elements of the array.
    /// 
    /// Output:
    /// For each test case print the number of pairs in array whose XOR is odd.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=1000
    /// 1<=Arr[i]<=1000
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 3
    /// 1 2 3
    /// 4
    /// 1 2 3 4
    /// 18
    /// 935 200 141 771 73 328 452 197 883 611 495 99 393 583 954 54 803 848 
    /// 1
    /// 617
    /// 
    /// Output:
    /// 2
    /// 4
    /// 72
    /// 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountPairsWhoseXorIsOdd
    {
        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var scanner = new StringScanner(test[1]);
                var numbers = new int[n - 1];
                numbers[0] = scanner.NextPositiveInt();
                var i = 1;
                var counter = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    for (var k = 0; k < i; k++)
                    {
                        if (((number ^ numbers[k]) & 1) == 1)
                        {
                            counter++;
                        }
                    }

                    numbers[i++] = number;
                }

                Console.WriteLine(counter);
            }
        }
    }
}