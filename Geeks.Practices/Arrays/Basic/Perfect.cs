﻿using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Perfect Array"
    /// 
    /// There is an array contains some non-negative integers.
    /// Check whether the array is perfect or not.
    /// An array is called perfect if it is first strictly increasing, then constant and finally strictly decreasing.
    /// Any of the three parts can be empty.
    /// 
    /// Input:
    /// The first line of the input contains an integer T, denoting number of test cases.
    /// The first line of each test case contains an integer N denoting the size of the array.
    /// The second line of each test cases N space separated integers.
    /// 
    /// Output:
    /// For each test case, print "Yes" if it satisfies the condition else "No".
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10^3
    /// Each element in the array will be in range [1,100000]
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 6
    /// 1 8 8 8 3 2
    /// 5
    /// 1 1 2 2 1
    /// 
    /// Output:
    /// Yes
    /// No
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Perfect
    {
        /// <summary>
        /// The execution time is 0.12
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
                var result = "Yes";
                //var n = int.Parse(test[0]); // Skip the number of elements
                var scanner = new StringScanner(test[1]);
                var left = scanner.NextPositiveInt();
                var flag = -2; // -1 = Increasing, 0 = Constant, 1 = Decreasing
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (flag == -2 || flag == -1)
                    {
                        flag = left.CompareTo(number);
                    }
                    else if (flag == 0)
                    {
                        if (number == left)
                        {
                            continue;
                        }

                        if (number < left)
                        {
                            flag = 1;
                        }
                        else
                        {
                            result = "No";
                            break;
                        }
                    }
                    else
                    {
                        if (number < left)
                        {
                            continue;
                        }

                        result = "No";
                        break;
                    }

                    left = number;
                }

                Console.WriteLine(result);
            }
        }
    }
}