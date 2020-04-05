using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Minimum move to front operations"
    /// 
    /// Given an array arr[] of size n such that array elements are distinct and in the range from 1 to n.
    /// The task is to count minimum number of move-to-front operations to arrange items as {1, 2, 3,… n}.
    /// The "move-to-front" operation is to pick any element arr[i] and place it at first position.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// First line of every test case consists of N, denoting the number of elements of array.
    /// Second line of every test case consists of elements of array.
    /// 
    /// Output:
    /// Single line output i.e minimum number of move to front operation to sort the array.
    /// 
    /// Constraints:
    /// 1 <= T <=100
    /// 1 <= N <=100
    /// 1 <= e <= N
    /// (e=A[i])
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 4
    /// 3 2 1 4
    /// 7
    /// 5 7 4 3 2 6 1
    /// 1
    /// 1 
    /// 2
    /// 1 2
    /// 
    /// Output:
    /// 2
    /// 6
    /// 0
    /// 0
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class MinMoveToMakeAscendingArray
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine();
                var input = Console.ReadLine().TrimEnd();
                var scanner = new StringScanner(input);
                var elements = new int[100];
                var p = 1;
                while (scanner.HasNext)
                {
                    elements[scanner.NextPositiveInt() - 1] = p++;
                }

                var previousPosition = 101;
                var result = 0;
                for (var a = 99; a >= 0; a--)
                {
                    if (elements[a] == 0)
                    {
                        continue;
                    }

                    if (elements[a] < previousPosition)
                    {
                        previousPosition = elements[a];
                    }
                    else
                    {
                        result++;
                        previousPosition = 0;
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}