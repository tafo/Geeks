using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Missing number"
    /// 
    /// Vaibhav likes to play with numbers and he has n numbers.
    /// One day he was placing the numbers on the playing board just to count that how many numbers he have.
    /// He was placing the numbers in increasing order i.e. from 1 to n.
    /// But when he was putting the numbers back into his bag, some numbers fell down onto the floor.
    /// He picked up all the numbers but one number, he couldn't find.
    /// Now he have to go somewhere urgently, so he asks you to find the missing number.
    /// 
    /// Input:
    /// The first of input contains an integer T, then T test cases follow.
    /// Each test case contains an integer n i.e. numbers of integers he placed on the board
    /// the second line of each test case contains the array a[] which represents the numbers, he successfully picked up from the floor. 
    /// 
    /// 
    /// Output:
    /// For each test case in a new line print the missing number.
    /// 
    /// 
    /// Constraints:
    /// 1<=T<=25
    /// 1<=n<=10000
    /// 1<=a[i]<=10000
    /// 
    /// Example:
    /// Input:                    
    /// 2                                        
    /// 4                                        
    /// 1 4 3                           
    /// 5
    /// 2 5 3 1
    /// Output:
    /// 2
    /// 4
    /// 
    /// Explanation:
    /// For first test case
    /// Vaibhav placed 4 integers but he picked up only 3 numbers.
    /// So missing number will be 2 as it will become 1,2,3,4.
    /// 
    /// For the second case
    /// Vaibhav placed 5 integers on the board, but picked up only 4 integers, so the missing number will be 4 so that it will become 1,2,3,4,5.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindMissingNumber
    {
        /// <summary>
        /// The execution time is 0.09
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
                var n = int.Parse(test[0]) - 1;
                var scanner = new StringScanner(test[1]);
                var numbers = scanner.GetAllPositiveInt(n);
                Array.Sort(numbers);
                int i;
                for (i = 0; i < n; i++)
                {
                    if (numbers[i] == i + 2)
                    {
                        break;
                    }
                }
                Console.WriteLine(i + 1);
            }
        }

        /// <summary>
        /// The execution time is 0.17
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new int[testCount][];

            for (var i = 0; i < tests.Length; i++)
            {
                Console.ReadLine(); // Skip the number of tests
                tests[i] = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
            }

            foreach (var test in tests)
            {
                var result = test.Where((x, i) => x == i + 2).FirstOrDefault();
                Console.WriteLine(result == 0 ? test.Length + 1 : result - 1);
            }
        }
    }
}