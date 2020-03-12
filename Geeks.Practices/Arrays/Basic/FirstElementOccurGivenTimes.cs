using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "First element to occur k times"
    /// 
    /// Given an array of N integers.
    /// The task is to find the first element that occurs K number of times. If no element occurs K times the print -1.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// The first line of each test case contains an integer N denoting the size of an array and the number K.
    /// The second line of each test case contains N space separated integers denoting elements of the array A[].
    /// 
    /// Output:
    /// For each test case in a new line print the required answer.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N, K <= 10e5
    /// 1<= A <= 10e6
    /// 
    /// Example:
    /// Input :
    /// 1
    /// 7 2
    /// 1 7 4 3 4 8 7
    /// Output :
    /// 7
    /// 
    /// Explanation:
    /// Both 7 and 4 occur 2 times. But 7 is the first that occurs 2 times.
    ///
    /// Remark:
    /// (1) The statement is not clear !!! 
    /// (2) Even if the statement says that K is greater than 0, there are some test cases having the value of K is equal to 0 !!!
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FirstElementOccurGivenTimes
    {
        private const char E = ' ';
        /// <summary>
        /// The execution time is 0.34
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var count = int.Parse(test[0].Split(E)[1]);
                var result = test[1].Split(E).GroupBy(x => x).FirstOrDefault(x => x.Count() == count)?.Key ?? "-1";
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.41
        /// * Compare to Run3
        /// * But the execution time has a margin of error of 30 milliseconds
        /// </summary>
        public static void Run4()
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
                var split = testCase[0].Split(' ');
                // var n = int.Parse(split[0]); Skip the number of elements
                var count = int.Parse(split[1]);
                var result = testCase[1].Split(' ').Select(int.Parse).GroupBy(x => x).FirstOrDefault(x => x.Count() == count)?.Key ?? -1;
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.39
        /// </summary>
        public static void Run3()
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
                var split = testCase[0].Split(' ');
                // var n = int.Parse(split[0]); Skip the number of elements
                var count = int.Parse(split[1]);
                Console.WriteLine(testCase[1].Split(' ').Select(int.Parse).GroupBy(x => x).FirstOrDefault(x => x.Count() == count)?.Key ?? -1);
            }
        }

        /// <summary>
        /// The execution time is 0.18
        /// * Love LINQ and Scanner :)
        /// </summary>
        public static void Run2()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().Trim();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var count = int.Parse(split[1]);
                var numbers = new int[n];
                var scanner = new StringScanner(test[1]);

                var index = 0;
                while (scanner.HasNext)
                {
                    numbers[index++] = scanner.NextUInt();
                }

                Console.WriteLine(numbers.GroupBy(x => x).FirstOrDefault(x => x.Count() == count)?.Key ?? -1);
            }
        }

        /// <summary>
        /// The execution time is 0.69
        /// </summary>
        public static void Run1()
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
                var split = testCase[0].Split(' ');
                var n = int.Parse(split[0]);
                var occurence = int.Parse(split[1]);

                // Check Remark 2
                if (occurence == 0)
                {
                    Console.WriteLine(-1);
                    continue;
                }

                var numbers = new int[n, 2];
                var scanner = new StringScanner(testCase[1]);

                var index = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextUInt();
                    var exists = false;
                    for (var i = 0; i < index; i++)
                    {
                        if (numbers[i, 0] != number) continue;

                        exists = true;
                        numbers[i, 1]++;
                        break;
                    }

                    if (exists) continue;

                    numbers[index, 0] = number;
                    numbers[index++, 1] = 1;
                }

                var result = -1;
                for (var i = 0; i < n; i++)
                {
                    if (numbers[i, 1] != occurence) continue;

                    result = numbers[i, 0];
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}