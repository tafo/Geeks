using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Tywin's War Strategy"
    /// 
    /// Tywin Lannister is facing a war.
    /// He has N troops of soldiers.
    /// Each troop has a certain number of soldiers denoted by an array A.
    /// Tywin thinks that a troop is lucky if it has number of soldiers as a multiple of K.
    /// He doesn't want to lose any soldiers, so he decides to train some more.
    /// He will win the war if he has at least half of his troops are lucky troops.
    /// Determine the minimum number of soldiers he must train to win the war.
    /// 
    /// Input : 
    /// First line of input contains a single integer T denoting the number of test cases.
    /// The first line of each test case contains 2 space-separated integers N and K.
    /// The second line contains N space-separated integers A1,A2,A3,...,AN denoting number of soldiers in each troop.
    /// 
    /// Output : 
    /// For each test case, print the required answer in a new line.
    /// 
    /// Constraints : 
    /// 1 <= T <= 150
    /// 1 <= N <= 100
    /// 1 <= K <= 100
    /// 1 <= Ai <= 10^4
    /// 
    /// Example 1 : 
    /// Input : 
    /// 2
    /// 5 2
    /// 5 6 3 2 1
    /// 6 4
    /// 2 3 4 9 8 7
    /// 
    /// Output : 
    /// 1
    /// 1
    /// 
    /// Explaination : 
    /// Case 1 : Troop with 1 soldier is increased to 2.
    /// Case 2 : Troop with 3 soldier is increased to 4.
    /// 
    /// Example 2 :
    /// Input : 
    /// 1
    /// 4 3
    /// 3 1 4 7
    /// 
    /// Output : 
    /// 2
    /// 
    /// Explaination : 
    /// Case 1 : Troop with 1 soldier is increased to 3.
    ///
    /// Example 3 :
    /// Input :
    /// 2
    /// 6 41
    /// 9752 2163 5567 2490 7656 6936 
    /// 18 27
    /// 3282 6117 875 3112 7792 3547 587 9985 2158 4622 8997 650 7388 1906 5126 6128 9718 943
    ///
    /// Output : 
    /// 25
    /// 44
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    public class AnotherIdiot
    {
        /// <summary>
        /// The execution time is 0.09
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
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var remainders = test[1].Split(' ').Select(x => int.Parse(x) % k).ToArray();
                var counter = remainders.Count(x => x == 0);
                Console.WriteLine(counter * 2 < n
                    ? remainders.OrderByDescending(x => x).Take((int) Math.Ceiling(n / 2D) - counter).Sum(x => k - x)
                    : 0);
            }
        }

        /// <summary>
        /// The execution time is 0.10
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
                var remainders = numbers.Select(x => x % k).ToArray();
                var counter = remainders.Count(x => x == 0);
                Console.WriteLine(remainders.OrderByDescending(x => x).Take((int) Math.Ceiling(n / 2D) - counter).Sum(x => k - x));
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunAnotherCompareToLoop()
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
                var scanner = new StringScanner(test[1]);
                var numbers = new int[n];
                var i = 0;
                var counter = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    numbers[i] = number % k;
                    if (numbers[i] == 0)
                    {
                        counter++;
                    }

                    i++;
                }

                var result = 0;
                var missingCounter = Math.Ceiling(n / 2D) - counter;
                if (missingCounter > 0)
                {
                    Array.Sort(numbers, (x, y) => y.CompareTo(x));
                    for (var a = 0; a < missingCounter; a++)
                    {
                        result += k - numbers[a];
                    }
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunCompareToLoop()
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
                var scanner = new StringScanner(test[1]);
                var numbers = new int[n][];
                var i = 0;
                var counter = 0;
                while (scanner.HasNext)
                {
                    numbers[i] = new int[2];
                    var number = scanner.NextPositiveInt();
                    numbers[i][0] = number;
                    numbers[i][1] = number % k;
                    if (numbers[i][1] == 0)
                    {
                        counter++;
                    }

                    i++;
                }

                var result = 0;
                var missingCounter = Math.Ceiling(n / 2D) - counter;
                if (missingCounter > 0)
                {
                    Array.Sort(numbers, (x, y) => y[1].CompareTo(x[1]));
                    for (var a = 0; a < missingCounter; a++)
                    {
                        result += k - numbers[a][1];
                    }
                }

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// The execution time is 0.12
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
                var scanner = new StringScanner(test[1]);
                var numbers = new int[n][];
                var i = 0;
                var counter = 0;
                while (scanner.HasNext)
                {
                    numbers[i] = new int[2];
                    var number = scanner.NextPositiveInt();
                    numbers[i][0] = number;
                    numbers[i][1] = number % k;
                    if (numbers[i][1] == 0)
                    {
                        counter++;
                    }

                    i++;
                }

                var result = 0;
                if (2 * counter < n)
                {
                    Array.Sort(numbers, (x, y) => y[1].CompareTo(x[1]));
                    foreach (var number in numbers)
                    {
                        result += k - number[1];
                        if (2 * ++counter >= n)
                        {
                            break;
                        }
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}