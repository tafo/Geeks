using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Check Arithmetic Progression"
    /// 
    /// Given an array of N integers.
    /// Write a program to check whether an arithmetic progression can be formed using all the given elements.
    /// If possible print “YES”, else print “NO”.
    /// 
    /// Input:
    /// First line of input contains a single integer T which denotes the number of test cases.
    /// Then T test cases follows.
    /// First line of each test case contains a single integer N which denotes number of elements in the array.
    /// Second line of each test case contains N space separated integers which denotes elements of the array.
    /// 
    /// Output:
    /// For each test case,
    ///     print "YES" without quotes if an arithmetic progression can be formed using all the given elements, else print "NO" without quotes.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10e5
    /// 1<=Arr[i]<=10e5
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 4
    /// 0 12 4 8
    /// 4
    /// 12 40 11 20
    /// 
    /// Output:
    /// YES
    /// NO
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CheckArithmeticSequence
    {
        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunMix()
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
                var result = "YES";
                if (n > 2)
                {
                    var numbers = StringScanner.GetPositiveInt(test[1], n);
                    Array.Sort(numbers);
                    var dif = numbers[1] - numbers[0];
                    if (numbers.Skip(2).Select((x, i) => x - numbers[i + 1]).Any(x => x != dif))
                    {
                        result = "NO";
                    }
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.09
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
                var result = "YES";
                if (n > 2)
                {
                    var numbers = StringScanner.GetPositiveInt(test[1], n);
                    Array.Sort(numbers);
                    var dif = numbers[1] - numbers[0];
                    for (var i = 2; i < n; i++)
                    {
                        if (numbers[i] - numbers[i - 1] == dif) continue;
                        result = "NO";
                        break;
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}