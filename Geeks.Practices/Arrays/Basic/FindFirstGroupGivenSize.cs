using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "First Come First Serve"
    /// 
    /// CodeMart is an online shopping platform and it is distributing gift vouchers to its esteemed users.
    /// The voucher can be redeemed by providing a fixed amount of shopping credits.
    /// Each credit is sent by a user one by one.
    /// Since there is a huge rush of people you are required to manage the users on the basis of first come first serve.
    /// The user which comes first and has k occurrences of credits is given the voucher first.
    /// You are given an array with the id's of the users in chronological order of the credits sent by them.
    /// You are required to print the id of the user which will be served first.
    /// If no such user meets the condition print "-1".    
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains two integers n and k where n denoted the number of elements in the array a[].
    /// Next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Output a single integer which is the number of first k occurrences.
    /// Output "-1" if no such number exists.
    /// 
    /// Constraints:
    /// 1<=T<=10
    /// 1<=n<=1000
    /// 1<=a[i]<=100000
    /// 1<=k<=100
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 7 2
    /// 1 7 4 3 4 8 7
    /// 6 1
    /// 4 1 6 1 6 4
    /// 
    /// Output:
    /// 7
    /// -1
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class FindFirstGroupGivenSize
    {
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
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var scanner = new StringScanner(test[1]);
                var numbers = new int[n][];
                var i = 0;
                while (scanner.HasNext)
                {
                    numbers[i] = new int[2];
                    numbers[i][0] = scanner.NextPositiveInt();
                    numbers[i][1] = i;
                    i++;
                }

                Array.Sort(numbers, (x, y) => x[0].CompareTo(y[0]));

                var count = 1;
                var minIndex = numbers[0][1];
                var resultIndex = -1;
                var result = -1;
                for (i = 1; i < n; i++)
                {
                    if (numbers[i][0] == numbers[i - 1][0])
                    {
                        count++;
                        minIndex = Math.Min(minIndex, numbers[i][1]);
                        if (i < n - 1) continue;
                    }

                    if(count == k)
                    {
                        if (resultIndex == -1)
                        {
                            resultIndex = minIndex;
                            result = numbers[i - 1][0];
                        }
                        else if(minIndex < resultIndex)
                        {
                            resultIndex = minIndex;
                            result = numbers[i - 1][0];
                        }
                    }
                        
                    minIndex = numbers[i][1];
                    count = 1;
                }

                Console.WriteLine(result);
            }
        }
    }
}