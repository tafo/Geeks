using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Product of array elements"
    ///
    /// This is a functional problem . Your task is to return the product of array elements under a given modulo.
    /// The modulo operation finds the remainder after division of one number by another.
    ///     For example, K(mod(m))=K%m= remainder obtained when K is divided by m.
    /// 
    /// Input:
    /// The first line of input contains T denoting the number of test cases.
    /// Then each of the T lines contains a single positive integer N denotes number of element in array.
    /// Next line contain 'N' integer elements of the array.
    /// 
    /// 
    /// Output:
    /// Return the product of array elements under a given modulo.
    /// That is, return (Array[0]*Array[1]*Array[2]...*Array[n])%modulo.
    ///  
    /// Constraints:
    /// 1<=T<=200
    /// 1<=N<=10^5
    /// 1<=ar[i]<=10^5
    /// 
    /// Example:
    /// 1
    /// 4
    /// 1 2 3 4
    /// 
    /// Output:
    /// 24
    ///
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// Method Signature
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// public static Long product(Long arr[], Long mod, int n) { }
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// Solution
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// public static Long product(Long arr[], Long mod, int n)
    /// {
    ///     long product = 1;
    ///     for (int i = 0; i < n; i++)
    ///     {
    ///         product = product * arr[i] % mod;
    ///     }
    ///     return product;
    /// }
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class ProductOfElements
    {
        internal static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = new long[n];
                var scanner = new StringScanner(testCase[1]);
                var index = 0;
                while (scanner.HasNext)
                {
                    elements[index++] = scanner.NextPositiveInt();
                }

                Console.WriteLine(Product(elements, n, n));
            }
        }

        public static long Product(long[] elements, long mod, int n)
        {
            long product = 1;

            for (var i = 0; i < n; i++)
            {
                product = product * elements[i] % mod;
            }

            return product;
        }
    }
}