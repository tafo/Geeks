using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Rearranging array"
    /// 
    /// Given a list of integers, rearrange the list such that it consists of alternating minimum maximum elements using only list operations.
    /// The first element of the list should be minimum and second element should be maximum of all elements present in the list.
    /// Similarly, third element will be next minimum element and fourth element is next maximum element and so on.
    /// Use of extra space is not permitted.
    /// 
    /// Input:
    /// The first line of input contains a single integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consist of two lines.
    /// The first line of each test case consists of an integer N, where N is the size of array.
    /// The second line of each test case contains N space separated integers denoting array elements.
    /// 
    /// Output:
    /// Corresponding to each test case, in a new line, print the modified list.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N ≤ 200
    /// 1 ≤ A[i] ≤ 500
    /// 
    /// Example:
    /// 
    /// Input
    /// 4
    /// 5
    /// 4 5 1 2 3
    /// 4
    /// 1 2 3 4
    /// 5
    /// 206 127 313 376 94 
    /// 19
    /// 398 329 352 317 231 450 426 159 230 21 441 61 148 163 156 176 293 362 255
    /// 
    /// Output
    /// 1 5 2 4 3
    /// 1 4 2 3
    /// 94 376 127 313 206
    /// 21 450 61 441 148 426 156 398 159 362 163 352 176 329 230 317 231 293 255
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class AlternateSortingAnother
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
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var result = Enumerable.Range(1, n).Select(x => (x & 1) == 1 ? numbers[x / 2] : numbers[n - x / 2]);
                Console.WriteLine(string.Join(' ', result));
            }
        }

        /// <summary>
        /// The execution time is 0.08
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
                var i = 0;
                var left = 0;
                var right = n - 1;
                var flag = true;
                var result = new int[n];
                while (left <= right)
                {
                    if (flag)
                    {
                        result[i++] = numbers[left++];
                    }
                    else
                    {
                        result[i++] = numbers[right--];
                    }

                    flag = !flag;
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}