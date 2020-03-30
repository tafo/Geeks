using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "King's War"
    /// THE AUTHOR OF THIS PROBLEM IS PROBABLY AN IDIOT !!!
    ///     No winner in battle :(
    /// 
    /// King is getting ready for a war.
    /// He know his strengths and weaknesses so he is taking required number of soldiers with him.
    /// King can only defeat enemies with strongest and weakest power, and one soldier can only kill one enemy.
    /// Your task is to calculate that how many soldiers are required by king to take with him for the war.
    /// 
    /// Input:
    /// First line of input contains T, number of test cases.
    /// First line of each test case consists of a single integer N, which denotes the number of soldiers in the enemies army.
    /// Second line of each test case consists of N space separated integers A1, A2,...,An representing the of power of soldiers of enemies army.
    /// 
    /// Output:
    /// A single integer representing the number of soldiers, king will take with him for the war.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e6
    /// 1 <= Ai <= 10e18
    /// 
    /// Examples
    /// Input:
    /// 3
    /// 2
    /// 1 5
    /// 3
    /// 1 2 5
    /// 83
    /// 59 25 38 63 25 1 37 53 100 80 51 69 72 74 32 82 31 34 95 61 64 100 82 100 97 60 74 14 69 91 96 27 67 85 41 91 85 77 43 37 8 46 57 80 19 88 13 49 73 60 10 37 11 43 88 7 2 14 73 22 56 20 100 22 5 40 12 41 68 6 29 28 51 85 59 21 25 23 70 97 82 31 85
    /// 
    /// Output:
    /// 0
    /// 1
    /// 78
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountElementsBetweenGreatestAndLeast
    {
        /// <summary>
        /// The execution time is 0.38
        /// </summary>
        public static void RunCompareToMix()
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
                var numbers = StringScanner.GetPositiveLong(test[1], n);
                var min = numbers.Min();
                var max = numbers.Max();
                Console.WriteLine(numbers.Count(x => x > min && x < max));
            }
        }

        /// <summary>
        /// The execution time is 0.38
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
                var numbers = StringScanner.GetPositiveLong(test[1], n);
                var min = numbers.Min();
                var max = numbers.Max();
                Console.WriteLine(min == max ? 0 : n - numbers.Count(x => x == min || x == max));
            }
        }

        /// <summary>
        /// The execution time is 0.30
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
                var min = long.MaxValue;
                long max = 0;
                var minCounter = 0;
                var maxCounter = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveLong();
                    if (number < min)
                    {
                        min = number;
                        minCounter = 1;
                    }
                    else if (number == min)
                    {
                        minCounter++;
                    }
                    else if (number == max)
                    {
                        maxCounter++;
                    }
                    else if(number > max)
                    {
                        max = number;
                        maxCounter = 1;
                    }
                }

                Console.WriteLine(n - (maxCounter + minCounter));
            }
        }
    }
}