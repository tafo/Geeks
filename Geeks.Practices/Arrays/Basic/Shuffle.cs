using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Shuffle integers"
    /// 
    /// Given an array of n elements in the following format { a1, a2, a3, a4, ….., an/2, b1, b2, b3, b4, …., bn/2 }.
    /// The task is shuffle the array to {a1, b1, a2, b2, a3, b3, ……, an/2, bn/2 } without using extra space.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow, Each test case contains an integer n denoting the size of the array.
    /// The next line contains n space separated integers forming the array.
    /// 
    /// Output:
    /// Print the shuffled array without using extra space.
    /// 
    /// Constraints:
    /// 1<=T<=10^5
    /// 1<=n<=10^5
    /// 1<=a[i]<=10^5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 4
    /// 1 2 9 15
    /// 6
    /// 1 2 3 4 5 6
    /// 15
    /// 88 57 44 92 28 66 60 37 33 52 38 29 76 8 75 
    /// 22
    /// 59 96 30 38 36 94 19 29 44 12 29 30 77 5 44 64 14 39 7 41 5 19
    /// 85
    /// 4 52 55 100 33 61 77 69 40 13 27 87 95 40 96 71 35 79 68 2 98 3 18 93 53 57 2 81 87 42 66 90 45 20 41 30 32 18 98 72 82 76 10 28 68 57 98 54 87 66 7 84 20 25 29 72 33 30 4 20 71 69 9 16 41 50 97 24 19 46 47 52 22 56 80 89 65 29 42 51 94 1 35 65 25
    /// 1 2 3 4 5
    /// 
    /// Output:
    /// 1 9 2 15 
    /// 1 4 2 5 3 6
    /// 88 37 57 33 44 52 92 38 28 29 66 76 60 8 75
    /// 59 30 96 77 30 5 38 44 36 64 94 14 19 39 29 7 44 41 12 5 29 19
    /// 4 10 52 28 55 68 100 57 33 98 61 54 77 87 69 66 40 7 13 84 27 20 87 25 95 29 40 72 96 33 71 30 35 4 79 20 68 71 2 69 98 9 3 16 18 41 93 50 53 97 57 24 2 19 81 46 87 47 42 52 66 22 90 56 45 80 20 89 41 65 30 29 32 42 18 51 98 94 72 1 82 35 76 65 25
    /// 1 3 2 4 5
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Shuffle
    {
        /// <summary>
        /// The execution time is 0.12
        /// </summary>
        public static void RunCompareToAnother()
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
                var result = new int[n];
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var half = n / 2;
                var i = 0;
                while (i < n - 1)
                {
                    result[i++] = numbers[i / 2];
                    result[i] = numbers[half + i / 2];
                    i++;
                }

                result[n - 1] = numbers[n - 1];
                Console.WriteLine(string.Join(' ', result));
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunAnother()
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
                var result = new int[n];
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var half = n / 2;
                var i = 0;
                var counter = 0;
                while (counter < half)
                {
                    result[i++] = numbers[counter];
                    result[i++] = numbers[half + counter++];
                    
                }

                result[n - 1] = numbers[n - 1];
                Console.WriteLine(string.Join(' ', result));
            }
        }

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
                var n = int.Parse(test[0]);
                var result = new int[n];
                var scanner = new StringScanner(test[1]);
                for (var i = 0; i < n - 1; i += 2)
                {
                    result[i] = scanner.NextPositiveInt();
                }
                for (var i = 1; i < n - 1; i += 2)
                {
                    result[i] = scanner.NextPositiveInt();
                }

                if ((n & 1) == 1)
                {
                    result[n - 1] = scanner.NextPositiveInt();
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}