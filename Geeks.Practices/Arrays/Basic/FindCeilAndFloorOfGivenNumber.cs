using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Ceil The Floor"
    /// 
    /// Given an unsorted array arr[] and an element x, find floor and ceiling of x in arr[0..n-1].
    /// 
    /// Floor of x is the largest element which is smaller than or equal to x.
    /// Floor of x does not exist if x is smaller than smallest element of arr[].
    /// 
    /// Ceil of x is the smallest element which is greater than or equal to x.
    /// Ceil of x does not exist if x is greater than greatest element of arr[].
    /// 
    /// Examples:
    /// 
    /// Input : arr[] = {5, 6, 8, 9, 6, 5, 5, 6}      
    /// x = 7
    /// Output : Floor = 6
    /// Ceiling = 8
    /// 
    /// Input : arr[] = {5, 6, 8, 9, 6, 5, 5, 6}      
    /// x = 10
    /// Output : Floor = 9
    /// Ceil doesn't exist.
    /// 
    /// Input : arr[] = {5, 6, 8, 9, 6, 5, 5, 6}      
    /// x = 2
    /// Output : Floor doesn't exist
    /// Ceil = 5
    /// 
    /// Example : 
    /// Input : 
    /// The first line of input contains an integer T denoting the Test cases.
    /// Then T test cases follow. 
    /// First line contains no. of array elements - N and value of x
    /// Second line contains array elements A[i]
    /// 
    /// Output : 
    /// Floor and Ceil Value of x
    /// 
    /// Constraints :
    /// 1 ≤ T ≤ 100
    /// 1 ≤ N, x ≤ 10^5
    /// 0 ≤ A[i] ≤ 10^6
    /// 
    /// Input : 
    /// 3
    /// 8 2
    /// 5 6 9 8 6 5 5 6
    /// 11 264
    /// 147 154 383 223 345 30 376 111 33 186 72
    /// 26 51
    /// 108 287 83 110 353 299 283 302 141 179 271 295 184 79 99 282 7 251 39 97 117 102 97 279 298 29
    /// 
    /// Output : 
    /// Floor doesn't exist
    /// 5
    /// 223
    /// 345
    /// 39
    /// 79
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindCeilAndFloorOfGivenNumber
    {
        /// <summary>
        /// The execution time is 0.14
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
                // var n = int.Parse(split[0]); Skip the number of elements
                var x = int.Parse(split[1]);
                var numbers = test[1].Split(' ').Select(int.Parse).ToArray();
                var floor = numbers.Where(a => a <= x).DefaultIfEmpty(-1).Max();
                var ceil = numbers.Where(a => a >= x).DefaultIfEmpty(-1).Min();
                Console.WriteLine(floor == -1 ? "Floor doesn't exist" : floor.ToString());
                Console.WriteLine(ceil == -1 ? "Ceil doesn't exist" : ceil.ToString());
            }
        }

        /// <summary>
        /// The execution time is 0.13
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
                var x = int.Parse(split[1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                var floor = numbers.Where(a => a <= x).DefaultIfEmpty(-1).Max();
                var ceil = numbers.Where(a => a >= x).DefaultIfEmpty(-1).Min();
                Console.WriteLine(floor == -1 ? "Floor doesn't exist" : floor.ToString());
                Console.WriteLine(ceil == -1 ? "Ceil doesn't exist" : ceil.ToString());
            }
        }

        /// <summary>
        /// The execution time is 0.13
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
                // var n = int.Parse(split[0]); Skip the number of elements
                var x = int.Parse(split[1]);
                var scanner = new StringScanner(test[1]);
                var floor = -1;
                var ceil = 100001;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (number < x)
                    {
                        floor = Math.Max(floor, number);
                    } 
                    else if (number > x)
                    {
                        ceil = Math.Min(ceil, number);
                    }
                    else
                    {
                        ceil = number;
                        floor = number;
                    }
                }

                Console.WriteLine(floor == -1 ? "Floor doesn't exist" : floor.ToString());
                Console.WriteLine(ceil == 100001 ? "Ceil doesn't exist" : ceil.ToString());
            }
        }
    }
}