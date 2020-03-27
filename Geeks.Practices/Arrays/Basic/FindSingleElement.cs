using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Find unique element"
    /// 
    /// Given an array which contains all elements occurring k times, but one occurs only once. Find that unique element.
    /// 
    /// Input:
    /// The first line consists of an integer T i.e number of test cases.
    /// The first line of each test case consists of two integers n and k.
    /// The next line consists of n spaced integers. 
    /// 
    /// Output:
    /// Print the required output.
    /// 
    /// Constraints: 
    /// 1<=T<=100
    /// 2<=k<n<=100
    /// 1<=a[i]<=10000
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 7 3
    /// 6 2 5 2 2 6 6 
    /// 5 4
    /// 2 2 2 10 2
    /// 9  2
    /// 5423 4967 7339 4890 8350 4967 7339 8350 5423 
    /// 9  2
    /// 2540 7586 2844 5942 6837 2844 7586 2540 6837
    /// 
    /// Output:
    /// 5
    /// 10
    /// 4890
    /// 5942
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindSingleElement
    {
        /// <summary>
        /// The execution time is 0.09
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[^1]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);
                var result = 0;
                var found = false;
                for (var i = 0; i < n; i += k)
                {
                    result = numbers[i];
                    if (i == n - 1)
                    {
                        break;
                    }

                    for (var x = i + 1; x < i + k; x++)
                    {
                        if (numbers[x] == result) continue;
                        found = true;
                        break;
                    }

                    if (found)
                    {
                        break;
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}