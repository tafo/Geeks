using System;

namespace Geeks.Practices.Arrays.School
{
    /// <summary>
    /// ToDo : Fix the original problem statement
    /// (The original title of the problem is "Pascal Triangle")
    /// 
    /// Given a positive integer K, return the Kth row of pascal triangle.
    /// Pascal's triangle is a triangular array of the binomial coefficients formed by summing up the elements of previous row.
    /// 
    /// Example :
    /// 1
    /// 1 1
    /// 1 2 1
    /// 1 3 3 1
    /// For K = 3, return 3rd row i.e 1 2 1
    /// 
    /// Input:
    /// First line contains an integer T, total number of test cases.
    /// Next T lines contains an integer N denoting the row of triangle to be printed.
    /// 
    /// Output:
    /// Print the Nth row of triangle in a separate line.
    ///
    /// ToDo : Check for a better solution. 
    /// </summary>
    internal class PascalTriangle
    {
        internal static void Run()
        {
            int.TryParse(Console.ReadLine(), out var t);
            var results = new int[t][];
            for (var i = 0; i < t; i++)
            {
                int.TryParse(Console.ReadLine(), out var row);
                results[i] = new int[row];
                results[i][0] = 1;

                // The number of combinations of n things taken k at a time can be found by the below equation.
                // C(x, y) = x! / y! * (x - y)!
                var x = results[i][1] = row - 1;
                var y = 1;

                // ToDo : Skip the second half. Because it is equal to reverser order of the first half. 
                for (var k = 2; k < row; k++)
                {
                    results[i][k] = results[i][k - 1] * --x / ++y;
                }
            }

            foreach (var result in results)
            {
                for (var i = 0; i < result.Length - 1; i++)
                {
                    Console.Write("{0} ", result[i]);
                }
                Console.WriteLine(result[^1]);
            }

            Console.ReadKey();
        }
    }
}