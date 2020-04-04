using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Equivalent Sub-Arrays"
    /// 
    /// Given an array of n integers.
    /// Count the total number of sub-array having total distinct elements same as that of total distinct elements of the original array.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains the number of elements in the array a[] as n and next line contains space separated n elements in the array.
    /// 
    /// Output:
    /// For each test case output an integer which is the required answer.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=100
    /// 1<=a[i]<=100
    /// 
    /// Example:
    /// Input:
    /// 3
    /// 5
    /// 2 1 3 2 3
    /// 5
    /// 2 4 5 2 1
    /// 5
    /// 2 4 4 2 4
    /// 15
    /// 88 57 44 92 28 66 60 37 33 52 38 29 76 8 75 
    /// 22
    /// 59 96 30 38 36 94 19 29 44 12 29 30 77 5 44 64 14 39 7 41 5 19
    /// 84
    /// 87 78 16 94 36 87 93 50 22 63 28 91 60 64 27 41 27 73 37 12 69 68 30 83 31 63 24 68 36 30 3 23 59 70 68 94 57 12 43 30 74 22 20 85 38 99 25 16 71 14 27 92 81 57 74 63 71 97 82 6 26 85 28 37 6 47 30 14 58 25 96 83 46 15 68 35 65 44 51 88 9 77 79 89
    /// 
    /// Output:
    /// 5
    /// 2
    /// 9
    /// 1
    /// 3
    /// 2
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountSubArrays
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var elements = new int[101][];
                var p = 1;
                var size = 0;
                while (scanner.HasNext)
                {
                    var number = scanner.NextPositiveInt();
                    if (elements[number] == null)
                    {
                        elements[number] = new int[102];
                        elements[number][1] = 2;
                        size++;
                    }

                    var counter = ++elements[number][0];
                    elements[number][counter + 1] = p++;
                }

                Array.Sort(elements, (x, y) => (y?[0] ?? 0).CompareTo(x?[0] ?? 0));
                var numbers = new int[size][];
                Array.Copy(elements, 0, numbers, 0, size);

                var result = 0;
                var breakLoop = false;
                while (true)
                {
                    var min = 101;
                    var max = 0;
                    var minIndex = -1;
                    for (var i = 0; i < size; i++)
                    {
                        var position = numbers[i][1];
                        var counter = numbers[i][0];
                        if (position == counter + 2)
                        {
                            breakLoop = true;
                            break;
                        }

                        if (numbers[i][position] < min)
                        {
                            min = numbers[i][position];
                            minIndex = i;
                        }
                        if (numbers[i][position] > max)
                        {
                            max = numbers[i][position];
                        }
                    }

                    if (breakLoop)
                    {
                        break;
                    }

                    result += n - max + 1;
                    numbers[minIndex][1]++;
                }

                Console.WriteLine(result);
            }
        }
    }
}