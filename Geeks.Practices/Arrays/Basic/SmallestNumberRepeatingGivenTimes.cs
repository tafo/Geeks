using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Smallest number repeating K times"
    /// 
    /// Given an array of size n, the goal is to find out the smallest number that is repeated exactly 'k' times.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// First line of every test cases consists of 2 integers N and K.
    /// Second line of consists of every test case consists of array elements
    /// 
    /// Output:
    /// Single line output, print the smallest number to be repeated k times, else print -1.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10000
    /// 1<=K<=10
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 5 2
    /// 1 2 2 1 1
    /// 5 2
    /// 1 1 1 2 3
    /// 
    /// Output:
    /// 2
    /// -1
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SmallestNumberRepeatingGivenTimes
    {
        /// <summary>
        /// The execution time is 0.11
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                Console.WriteLine(numbers.GroupBy(x => x).FirstOrDefault(x => x.Count() == k)?.Key ?? -1);
            }
        }

        /// <summary>
        /// The execution time is 0.10
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var count = 1;
                var result = -1;
                for (var i = 1; i < n; i++)
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        count++;
                    }
                    else if(count == k)
                    {
                        result = numbers[i - 1];
                        break;
                    }
                    else
                    {
                        count = 1;
                    }
                }

                if (result == -1 && count == k)
                {
                    result = numbers[n - 1];
                }

                Console.WriteLine(result);
            }
        }
    }
}