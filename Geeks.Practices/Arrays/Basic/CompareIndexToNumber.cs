using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sherlock a Detective"
    /// 
    /// Sherlock is a famous detective.
    /// This time he's working to catch a team of gangsters.
    /// Sherlock knows that the head of gangsters will be caught if he catches his underlings.
    /// The gangsters work under a hierarchical system.
    /// Each member reports exactly to one other member of the town.
    /// It's clear that there are no cycles in their reporting system.
    /// There are N people in the town, for simplicity indexed from 1 to N, and Sherlock knows who each of them report to.
    /// Member i reports to member Ai, and head of Gangsters does not report to anybody.
    /// Sherlock wants to find the members to whom nobody reports as these members could help him bring down the organization.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// The first line every test case contains of one integer N.
    /// Next line has N space-separated integers.
    /// The i-th integer denotes Ai, the person whom the i-th member reports to.
    /// 
    /// Output:
    /// Single line output in ascending order, denoting the members of gangsters who nobody reports to.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<= N<=10^5
    /// 1<=Ai<=N except for leader of gangsters, whose Ai equals to 0.
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6
    /// 0 1 1 2 2 3
    /// 7
    /// 2 0 2 1 3 4 4
    /// 
    /// Output:
    /// 4 5 6
    /// 5 6 7
    /// 
    /// Explanation:
    /// For testcase1: N=6 and A={0,1,1,2,2,3}
    /// A[0]=0, A[1]=1, A[2]=1, A[3]=2, A[4]=2, A[5]=3.
    /// A[0] is the head. 1 reports to 1. 2 reports to 1. 3 reports to 2. 4 reports to 2. 5 reports to 3.
    /// So, the people not being being reported are 4, 5 and 6.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CompareIndexToNumber
    {
        /// <summary>
        /// The execution time is 0.11
        /// </summary>
        public static void RunSingleLineLinq()
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
                Console.WriteLine(string.Join(' ', Enumerable.Range(1, n).Except(test[1].Split(' ').Select(int.Parse).Distinct())));
            }
        }

        /// <summary>
        /// The execution time is 0.11
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
                Console.WriteLine(string.Join(' ', Enumerable.Range(1, n).Except(StringScanner.GetPositiveInt(test[1], n).Distinct())));
            }
        }

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
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Console.WriteLine(string.Join(' ', Enumerable.Range(1, n).Except(numbers)));
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
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var left = numbers[0];
                var distinctCounter = 1;
                for (var i = 1; i < n; i++)
                {
                    if (numbers[i] == left)
                    {
                        continue;
                    }

                    left = numbers[distinctCounter++] = numbers[i];
                }

                var result = new int[n - distinctCounter + 1];
                var resultIndex = 0;
                var index = 0;
                var position = 1;
                while (position <= n)
                {
                    if (position < numbers[index])
                    {
                        result[resultIndex++] = position++;
                    }
                    else if (position == numbers[index])
                    {
                        position++;
                        index++;
                        if (index == distinctCounter)
                        {
                            break;
                        }
                    }
                    else
                    {
                        index++;
                    }
                }

                while (position <= n)
                {
                    result[resultIndex++] = position++;
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}