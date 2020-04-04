using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// Given are two integers (x and n)  you have to find an array such that it contains the frequency of index numbers occurring in ( x^1 x^2 ....x^(n-1) x^(n) ) . 
    /// 
    /// Input:
    /// The first line of input contains an integer "test" denoting the number of test cases . Then "test" test cases follow . The first line of each test case contains two space separated integers x and n, where x is an integer (1 <= x <= 15) and n is the number of times to which x is to be raised , in increasing manner.  x^1  x^2  x^3 ....... x^(n-1)  x^(n) .
    /// 
    /// Output: 
    /// Corresponding to each test case, in a new line, print an array "a[]" which containes the frequency of each digit occuring in input (frequency of '0' at index "0" , frequency of '1' at index "0" ........ frequency of '9' at index "9" ) .
    /// 
    /// Constraints :
    /// 1 <= T <= 100
    /// 1 <= x <= 15
    /// 1 <= n <= 10
    /// 
    /// Example: 
    /// Input :
    /// 7  
    /// 15  3  
    /// 2 4    
    /// 3 2
    /// 1  5
    /// 5 2
    /// 1 1
    /// 1 2
    /// 
    /// Output : 
    /// 0 1 2 2 0 3 0 1 0 0
    /// 0 1 1 0 1 0 1 0 1 0
    /// 0 0 0 1 0 0 0 0 0 1
    /// 0 5 0 0 0 0 0 0 0 0
    /// 0 0 1 0 0 2 0 0 0 0
    /// 0 1 0 0 0 0 0 0 0 0
    /// 0 2 0 0 0 0 0 0 0 0
    /// 
    /// Explanation :
    /// Example 1: 
    /// First testcase:  15 3 
    /// 15^1 15^2 15^3 ==&gt; 15, 225, 3375 = s
    ///
    /// Output :
    /// An array which displays the frequency of its index numbers occuring in s = 15 225 3375
    /// Frequency of ' 0 ' = 0
    /// Frequency of ' 1 ' = 1 (only once in s , in 15)
    /// Frequency of ' 2 ' = 2 (twice in s , in 225)
    /// Frequency of ' 3 ' = 2 (twice in s , in 3375 )
    /// Frequency of ' 4 ' = 0 ( no where in s)
    /// Frequency of ' 5 ' = 3 ( thrice in s , in '15' , in '225' ,  in '3375' )
    /// Frequency of ' 6 ' = 0
    /// Frequency of ' 7 ' = 1  (only once in s , in '3375' )
    /// Frequency of ' 8 ' = 0
    /// Frequency of ' 9 ' = 0
    ///
    /// Output array : a[] = 
    /// a[0] = 0
    /// a[1] = 1
    /// a[2] = 2
    /// a[3] = 2
    /// a[4] = 0
    /// a[5] = 3
    /// a[6] = 0
    /// a[7] = 1
    /// a[8] = 0
    /// a[9] = 0
    ///
    /// Resultant array:
    /// 0 1 2 2 0 3 0 1 0 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public class CountDigitFrequency
    {
        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var n = int.Parse(split.First());
                var p = int.Parse(split.Last());
                var input = string.Join(string.Empty, Enumerable.Range(1, p).Select(x => $"{Math.Pow(n, x)}"));
                Console.WriteLine(string.Join(' ', Enumerable.Range(0, 10).Select(x => input.Count(c => c - '0' == x))));
            }
        }

        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Replace("  ", " ").Split(' ');
                var x = int.Parse(split[0]);
                var power = int.Parse(split[1]);
                var input = string.Empty;
                for (var i = 1; i <= power; i++)
                {
                    input += $"{Math.Pow(x, i)}";
                }

                var result = new int[10];

                for (var i = 0; i < 10; i++)
                {
                    var counter = 0;
                    foreach (var c in input)
                    {
                        if (c - '0' == i)
                        {
                            counter++;
                        }
                    }

                    result[i] = counter;
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}