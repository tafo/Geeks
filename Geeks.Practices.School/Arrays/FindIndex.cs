using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// ToDo : Fix the original problem statement 
    /// 
    /// Given an unsorted array Arr[] of N integers and a Key which is present in this array.
    ///     You need to write a program to find the start index( index where the element is first found from left in the array )
    ///     and end index( index where the element is first found from right in the array).
    /// 
    /// Input:
    /// First line of input contains an integer T which denotes the number of test cases.
    /// First line of each test case contains a single integer N which denotes the number of elements in the array.
    /// Second line of each test case contains N space separated integers.
    /// Third line of each test case contains the key to be searched.
    /// 
    /// Output:
    /// For each test case print two space separated integers, first is the start index and second is the end index.
    ///     If the key does not exist in the array then print -1 in this case. (It says "present"!!!)
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class FindIndex
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new int[t][];

            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                var elements = Console.ReadLine().TrimEnd().Split(' ');
                int.TryParse(Console.ReadLine(), out var key);
                results[i] = new int[2];
                results[i][0] = -1;
                for (var k = 0; k < elements.Length; k++)
                {
                    if (key != int.Parse(elements[k])) continue;

                    if (results[i][0] == -1)
                    {
                        results[i][0] = results[i][1] = k;
                    }
                    else
                    {
                        results[i][1] = k;
                    }
                }
            }

            foreach (var result in results)
            {
                if (result[0] == -1)
                {
                    Console.WriteLine("-1");
                }
                else
                {
                    Console.WriteLine("{0} {1}", result[0], result[1]);
                }
            }

            Console.ReadKey();
        }
    }
}