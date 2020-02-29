using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.School.Arrays.School
{
    /// <summary>
    /// !!! Original problem statement has been updated !!!
    /// 
    /// Given an array that has N elements, at each step it is reduced by 1 element.
    /// Remove maximum element in the first step. 
    /// Remove minimum element in the second step.
    /// Again remove maximum element in the third step.
    /// And so on.
    /// Continue this till the array contains only 1 element. And print the final element.
    /// 
    /// Input:
    /// The first line is the number of test cases.
    ///
    /// Each test case contains two lines. 
    /// >> The first line is the number of elements of the array.
    /// >> The second line is the space-separated elements of the array.
    /// 
    /// Output:
    /// For each test case, print the final element in a new line.
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal static class FindMiddleElement
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var c);
            var input = new int[c];

            for (var i = 0; i < c; i++)
            {
                int.TryParse(Console.ReadLine(), out var n);
                var elements = new int[n];
                var elementList = Console.ReadLine().Split(' ');

                for (var k = 0; k < elementList.Length; k++)
                {
                    elements[k] = int.Parse(elementList[k]);
                }

                {
                    // >> Just for fun <<
                    //var invalidInput = 0;
                    //for (var k = 0; k < elementList.Length; k++)
                    //{
                    //    int.TryParse(elementList[k], out var number);
                    //    if (number > 0)
                    //    {
                    //        elements[k - invalidInput] = number;
                    //    }
                    //    else
                    //    {
                    //        invalidInput++;
                    //    }
                    //}
                }

                // The detail of sorting an array will be handled in a different problem. 
                Array.Sort(elements);

                if ((elements.Length & 0x1) == 1)
                {
                    input[i] = elements[elements.Length / 2];
                }
                else
                {
                    input[i] = elements[elements.Length / 2 - 1];
                }
            }

            foreach (var result in input)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}