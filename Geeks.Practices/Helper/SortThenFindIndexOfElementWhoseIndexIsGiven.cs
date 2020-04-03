using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Helper
{
    /// <summary>
    /// The title is "Stable Sort and Position"
    /// 
    /// Given an array of n integers which may contain duplicate elements, index of an element of this array is given to us.
    /// We need to find the final position of this element (for which the index is given) in the array after stable sort is applied on the array. 
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains two integers n and idx.
    /// Next line contains space separated n elements in the array a[].
    /// 
    /// Output:
    /// Print the index(0 based indexing) of the element after a stable sort operation. 
    /// 
    /// Constraints:
    /// 1<=T<=200
    /// 1<=n<=1000
    /// 0<=idx 1<=a[i]<=10000
    /// 
    /// Example:
    /// Input:
    /// 1
    /// 10 5
    /// 3 4 3 5 2 3 4 3 1 5
    /// 
    /// Output:
    /// 4
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public class SortThenFindIndexOfElementWhoseIndexIsGiven
    {
        /// <summary>
        /// The execution time is 0.14
        /// </summary>
        public static void RunAnotherLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var input = Console.ReadLine().TrimEnd();
                var n = int.Parse(split[0]);
                var index = int.Parse(split[1]);
                var scanner = new StringScanner(input);
                var elements = new int[n][];
                var i = 0;
                while (scanner.HasNext)
                {
                    elements[i] = new int[2];
                    elements[i][0] = scanner.NextPositiveInt();
                    elements[i][1] = i;
                    i++;
                }

                Array.Sort(elements, (x, y) => x[0].CompareTo(y[0]) == 0 ? x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));
                Console.WriteLine(Array.FindIndex(elements, x => x[1] == index));
            }
        }

        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var split = Console.ReadLine().Split(' ');
                var input = Console.ReadLine().TrimEnd();
                var n = int.Parse(split[0]);
                var index = int.Parse(split[1]);
                var scanner = new StringScanner(input);
                var elements = new int[n][];
                var i = 0;
                while (scanner.HasNext)
                {
                    elements[i] = new int[2];
                    elements[i][0] = scanner.NextPositiveInt();
                    elements[i][1] = i;
                    i++;
                }

                Array.Sort(elements, (x, y) => x[0].CompareTo(y[0]) == 0 ? x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));

                for (var x = 0; x < n; x++)
                {
                    if (elements[x][1] != index) continue;
                    Console.WriteLine(x);
                    break;
                }
            }
        }
    }
}