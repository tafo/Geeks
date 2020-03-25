using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Max value after m range operation"
    /// 
    /// Given an array of size N with all initial values as 0, write a program to perform following M range increment operations as shown below:
    /// 
    /// increment(a, b, k) : Increment values from 'a'
    /// to 'b' by 'k'.  
    /// 
    /// After M operations, calculate the maximum value in the array.
    /// 
    /// Input:
    /// First line of input contains a single integer T which denotes the number of test cases.
    /// T test cases follows.
    /// First line of each test case contains two space separated integers N and M.
    /// Next M lines of each test case contains three space separated integers a , b and k.
    /// 
    /// Output:
    /// For each test case print the maximum element in the array after M increment operations.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=105
    /// 1<=M<=1000
    /// 0<= a,b <= N-1
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 5 3
    /// 0 1 100
    /// 1 4 100
    /// 2 3 100
    /// 4 3
    /// 1 2 603
    /// 0 0 286
    /// 3 3 882
    /// 201 5
    /// 129 164 759 53 144 8 172 173 211 102 132 309 40 161 903 
    /// 111 8
    /// 94 110 190 84 105 549 21 87 736 70 83 556 98 101 591 61 91 498 91 108 651 53 104 919
    /// Output:
    /// 200
    /// 882
    /// 1979
    /// 2900
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindMaxAfterApplyingGivenFunction
    {
        /// <summary>
        /// The execution time is 0.16
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var results = new int[testCount];

            for (var i = 0; i < testCount; i++)
            {
                var split = Console.ReadLine().Split(' ');
                var n = int.Parse(split[0]);
                var m = int.Parse(split[1]);
                var numbers = new int[n];
                var arguments = Console.ReadLine().Split(' ');
                for (var x = 0; x < m; x++)
                {
                    var a = int.Parse(arguments[3 * x + 0]);
                    var b = int.Parse(arguments[3 * x + 1]);
                    var k = int.Parse(arguments[3 * x + 2]);

                    for (var y = a; y <= b; y++)
                    {
                        numbers[y] += k;
                    }
                }

                var max = 0;
                for (var x = 0; x < n; x++)
                {
                    if (numbers[x] > max)
                    {
                        max = numbers[x];
                    }
                }

                results[i] = max;
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}