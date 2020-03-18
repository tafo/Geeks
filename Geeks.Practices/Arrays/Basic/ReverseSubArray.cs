using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Reverse sub array"
    /// 
    /// Provided an array of N integers, you need to reverse a sub array of that array.
    /// The range of this sub array is given by L and R.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// T test cases follow.
    /// Each test cases contains three lines of input:
    /// The first line is N, the size of the array.
    /// The second line contains N integers denoting the elements of the array.
    /// The third line contains L and R, denoting the starting and ending positions of the sub array.
    /// 
    /// Output:
    /// For each test case, print the modified array.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 200
    /// 1 ≤ N ≤ 10e7
    /// 1 ≤ A[i] ≤ 1000
    /// 1 ≤ L ≤ R ≤ N
    /// 
    /// Example Input:
    /// 1
    /// 7
    /// 1 2 3 4 5 6 7
    /// 2 4
    /// Output:
    /// 1 4 3 2 5 6 7
    /// 
    /// Explanation:
    /// Test case 1: After reversing the elements in range 2 to 4 (2, 3, 4), modified array is 1, 4, 3, 2, 5, 6, 7.
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ReverseSubArray
    {
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[3];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
                tests[i][2] = Console.ReadLine();
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var split = test[2].Split(' ');
                var firstPosition = int.Parse(split[0]);
                var lastPosition = int.Parse(split[1]);
                var reverseIndex = lastPosition - 1;
                var numbers = new int[n];
                var scanner = new StringScanner(test[1]);
                var i = 0;
                var reverse = false;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (i + 1 == firstPosition)
                    {
                        reverse = true;
                    }
                    else if (i == lastPosition)
                    {
                        reverse = false;
                    }

                    if (reverse)
                    {
                        numbers[reverseIndex--] = number;
                        i++;
                    }
                    else
                    {
                        numbers[i++] = number;
                    }
                }

                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}