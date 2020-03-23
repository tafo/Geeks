using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Triplet Family"
    /// 
    /// Given an array A of integers.
    /// Find three numbers such that sum of two elements equals the third element and return the triplet in a container result
    /// If no such triplet is found return the container as empty.
    /// 
    /// Input:
    /// First line of input contains number of test cases.
    /// For each test cases there will two lines.
    /// First line contains size of array and next line contains array elements.
    /// 
    /// Output:
    /// For each test case output the triplets, if any triplet found from the array, if no such triplet is found, output -1.
    /// 
    /// Your Task: Your task is to complete the function to find triplet and return container containing result.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e3
    /// 0 <= Ai <= 10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 3
    /// 5
    /// 1 2 3 4 5
    /// 3
    /// 3 3 3
    /// 6
    /// 8 10 16 6 15 25
    /// 
    /// Output:
    /// 1
    /// -1
    /// 1
    /// 
    /// Explanation:
    /// Testcase 1:
    /// Triplet Formed: {2, 1, 3}
    /// Hence 1 
    ///
    /// Test Case 2:
    /// Triplet Formed: {}
    /// Hence -1
    ///
    /// Test Case 3:
    /// Triplet Formed: {10, 15, 25}
    /// Hence 1
    ///
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class TripletFamily
    {
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
                var n = int.Parse(test[0]);
                var numbers = StringScanner.GetPositiveInt(test[1], n);
                Array.Sort(numbers);

                var isQualified = false;
                var c = n - 1;
                while (c > 1)
                {
                    var b = c - 1;
                    var a = 0;
                    while (a < b)
                    {
                        var sum = numbers[a] + numbers[b];
                        if (sum < numbers[c])
                        {
                            a++;
                        }
                        else if (sum > numbers[c])
                        {
                            b--;
                        }
                        else
                        {
                            isQualified = true;
                            c = 2;
                            break;
                        }
                    }
                    c--;
                }
                
                Console.WriteLine(isQualified ? 1 : -1);
            }
        }
    }
}