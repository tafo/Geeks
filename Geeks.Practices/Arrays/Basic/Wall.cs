using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Reducing Walls"
    /// 
    /// Ishaan is trapped in a city full of walls.
    /// To escape from there, it needs to climb N walls, one after the other.
    /// He can climb a wall if its height is at most K.
    /// Ishaan also has a superpower.
    /// He can reduce the height of a wall H by K by using his superpower.
    /// Since he can't use this power many times, calculate the minimum number of times he has to use this power to go over all the walls.
    /// 
    /// Input : 
    /// First line of input contains a single integer T denoting the number of test cases.
    /// The first line of each test case contains 2 space-separated integers N and K.
    /// The second line contains N space-separated integers denoting the heights of the walls.
    /// 
    /// Output : 
    /// For each test case, print the required answer in a new line.
    /// 
    /// Constraints : 
    /// 1 <= T <= 100
    /// 1 <= N <= 250
    /// 1 <= K <= 10e5
    /// 1 <= H <= 10e9
    /// 
    /// Example :
    /// 
    /// Input : 
    /// 3
    /// 5 5
    /// 5 3 2 6 8
    /// 6 4
    /// 2 6 4 8 1 6
    /// 4 3
    /// 2 2 2 2
    /// 
    /// Output : 
    /// 2
    /// 3
    /// 0
    /// 
    /// Explanation : 
    /// Case 1 : 
    /// Heights : 5 3 2 6 8
    /// Ishaan can climb a wall with height atmost 5.
    /// So he climbs the first 3 walls easily.
    /// Now he has to use his power to reduce the height of the 4th wall.
    /// After using his power, heights : 5 3 2 1 8
    /// Now to climb the last wall, he again uses his power.
    /// Final heights : 5 3 2 1 3
    /// 
    /// Case 2 : 
    /// Heights : 2 4 6 8 1 6
    /// Ishaan can climb a wall with height atmost 4.
    /// So he climbs the first 2 walls easily.
    /// Now he has to use his power to reduce the height of the 3rd wall.
    /// After using his power, heights : 2 4 2 8 1 6
    /// Now to climb the next wall, he again uses his power.
    /// Heights : 2 4 2 4 1 6
    /// He climbs the 5th wall easily.
    /// To climb the last wall, h uses his power again.
    /// Final Heights : 2 4 2 4 1 2
    /// 
    /// Case 3 : 
    /// Since all the heights are already below K(=3), Ishaan can climb all the walls without using his powers.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Wall
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void Run()
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
                // var n = int.Parse(split[0]); Skip the number of elements
                var k = double.Parse(split[1]);
                var scanner = new StringScanner(test[1]);
                double result = 0;
                while (scanner.HasNext)
                {
                    result += Math.Ceiling(scanner.NextPositiveInt() / k) - 1;
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.20
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
                var k = double.Parse(split[1]);
                Console.WriteLine(StringScanner.GetPositiveInt(test[1], n).Sum(x => Math.Ceiling(x / k) - 1));
            }
        }

        /// <summary>
        /// The execution time is 0.17
        /// </summary>
        public static void RunLinq()
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
                // var n = int.Parse(split[0]);
                var k = double.Parse(split[1]);
                Console.WriteLine(test[1].Split(' ').Select(int.Parse).Sum(x => Math.Ceiling(x / k) - 1));
            }
        }

        /// <summary>
        /// The execution time is 0.17
        /// * Compare this solution with RunLinq
        /// * Same performance
        /// </summary>
        public static void RunCompareToLinq()
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
                // var n = int.Parse(split[0]);
                var k = double.Parse(split[1]);
                Console.WriteLine(test[1].Split(' ').Sum(x => Math.Ceiling(int.Parse(x) / k) - 1));
            }
        }

        /// <summary>
        /// The execution time is 0.18
        /// </summary>
        public static void RunSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = Console.ReadLine().Split(' ').Skip(1).Select(int.Parse)
                    .Concat(Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse)).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.Skip(1).Sum(x => Math.Ceiling(x / (double)test[0]) - 1));
            }
        }

        /// <summary>
        /// The execution time is 0.17
        /// * Compare this solution with RunSingleLineLinq
        /// </summary>
        public static void RunCompareToSingleLineLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new double[testCount][][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new double[2][];
                tests[i][0] = Console.ReadLine().Split(' ').Skip(1).Select(double.Parse).ToArray();
                tests[i][1] = Console.ReadLine().TrimEnd().Split(' ').Select(double.Parse).ToArray();
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test[1].Sum(x => Math.Ceiling(x / test[0][0]) - 1));
            }
        }
    }
}