using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices
{
    /// <summary>
    ///
    /// ROTATE AND DELETE
    /// 
    /// Given an array arr[] of N integers. Do the following operation n-1 times. For every Kth operation:
    /// 
    /// Right rotate the array clockwise by 1.
    /// Delete the (n-k+1)th last element.
    /// Now, find the element which is left at last.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follows. Each test case contains two lines.
    ///     The first line of each test case contains an integer N.
    ///     Then in the next line are N space separated values of the array arr[].
    /// 
    /// Output:
    /// For each test case in a new line print the required result.
    /// 
    /// Constraints:
    /// 1 <= T <= 110
    /// 1 <= N <= 10^6
    /// 1 <= A[i] <= 10^7
    /// 
    /// Example:
    /// Input
    /// 2
    /// 4
    /// 1 2 3 4
    /// 6
    /// 1 2 3 4 5 6
    /// 
    /// Output:
    /// 2
    /// 3
    /// 
    /// Explanation:
    /// Testcase 2: A = {1, 2, 3, 4, 5, 6}.
    /// After rotation the array A = {6, 1, 2, 3, 4, 5} and delete the last element that is {5} so A = {6, 1, 2, 3, 4}.
    /// Again rotate the array for the second time and deletes the second last element that is {2} so A = {4, 6, 1, 3}.
    /// Doing these steps when he reaches 4th time, 4th last element does not exists so he deletes 1st element ie {1} so A={3, 6}.
    /// So continuing this procedure the last element in A is {3}, so outputp will be 3.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    internal class Program0001
    {
        /// <summary>
        /// Simplify the rotation and deletion operations
        /// </summary>
        private static void Main()
        {
            int t;

            do
            {
                int.TryParse(Console.ReadLine(), out t);
            } while (t < 1 || t > 110);

            var input = new int[t][];

            for (var i = 0; i < t; i++)
            {
                int n;
                do
                {
                    int.TryParse(Console.ReadLine(), out n);
                } while (n < 1 || n > 10e6);

                int index;
                var elements = new int[n];
                do
                {
                    index = 0;

                    var elementListLine = Console.ReadLine();

                    if (string.IsNullOrEmpty(elementListLine)) continue;

                    var elementList = elementListLine.Trim().Split(' ');

                    if (elementList.Length != n) continue;

                    foreach (var element in elementList)
                    {
                        if (int.TryParse(element, out var backup) && backup >= 1 && backup <= 10e7)
                        {
                            elements[index++] = backup;
                        }
                        else
                        {
                            break;
                        }
                    }
                } while (index < n);

                input[i] = elements;
            }

            foreach (var elements in input)
            {
                if (elements.Length == 1)
                {
                    Console.WriteLine(elements[0]);
                }
                else
                {
                    switch (elements.Length % 4)
                    {
                        case 0:
                            Console.WriteLine(elements[elements.Length / 4]);
                            break;
                        case 1:
                            Console.WriteLine(elements[(elements.Length + 3) / 4]);
                            break;
                        case 2:
                            Console.WriteLine(elements[(elements.Length + 2) / 4]);
                            break;
                        case 3:
                            Console.WriteLine(elements[(elements.Length + 5) / 4]);
                            break;
                    }
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Classic solution
        /// </summary>
        private static void MainBackup()
        {
            int t;

            do
            {
                int.TryParse(Console.ReadLine(), out t);
            } while (t < 1 || t > 110);

            var input = new int[t][];

            for (var i = 0; i < t; i++)
            {
                int n;
                do
                {
                    int.TryParse(Console.ReadLine(), out n);
                } while (n < 1 || n > 10e6);

                int index;
                var elements = new int[n];
                do
                {
                    index = 0;

                    var elementListLine = Console.ReadLine();

                    if (string.IsNullOrEmpty(elementListLine)) continue;

                    var elementList = elementListLine.Trim().Split(' ');

                    if (elementList.Length != n) continue;

                    foreach (var element in elementList)
                    {
                        if (int.TryParse(element, out var backup) && backup >= 1 && backup <= 10e7)
                        {
                            elements[index++] = backup;
                        }
                        else
                        {
                            break;
                        }
                    }
                } while (index < n);

                input[i] = elements;
            }

            foreach (var elements in input)
            {
                var n = elements.Length;
                var backupIndex = n - 2;
                while (backupIndex > 1)
                {
                    for (var i = backupIndex; i > 0; i--)
                    {
                        elements[i] = elements[i - 1];
                    }

                    elements[0] = elements[--n];

                    backupIndex -= 2;
                }

                Console.WriteLine(elements[n - 1]);
            }

            Console.ReadKey();
        }
    }
}
