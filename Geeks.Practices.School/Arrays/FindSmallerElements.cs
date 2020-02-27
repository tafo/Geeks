using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.School.Arrays
{
    /// <summary>
    /// Given an array of N distinct elements, the task is to find all elements in arrays except two greatest elements.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Each test case contains two lines.
    /// The first line of input contains an integer N denoting the size of the array.
    /// The second line of input contains space-separated elements.
    /// 
    /// Output:
    /// For each test case in a new line print the space-separated sorted values that satisfy the condition.
    ///
    /// ToDo : Check for a better algorithm
    /// 
    /// </summary>
    internal class FindSmallerElements
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var input = new int[t][];
            
            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                var elements = Console.ReadLine().Split(' ');
                input[i] = new int[n];

                for (var k = 0; k < n; k++)
                {
                    input[i][k] = int.Parse(elements[k]);
                }
            }

            foreach (var elements in input)
            {
                int max, max2;

                if (elements[0] > elements[1])
                {
                    max = elements[0];
                    max2 = elements[1];
                }
                else
                {
                    max = elements[1];
                    max2 = elements[0];
                }

                var result = new int[elements.Length - 2];
                var k = 0;
                
                for (var index = 2; index < elements.Length; index++)
                {
                    var element = elements[index];

                    if (element > max)
                    {
                        result[k] = max2;
                        max2 = max;
                        max = element;
                    }
                    else if (element > max2)
                    {
                        result[k] = max2;
                        max2 = element;
                    }
                    else
                    {
                        result[k] = element;
                    }

                    k++;
                }

                // Sorting detail will be handled in a different problem. 
                Array.Sort(result);

                foreach (var element in result)
                {
                    Console.Write("{0} ", element);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}