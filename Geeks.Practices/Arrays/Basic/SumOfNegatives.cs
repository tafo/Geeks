using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Mega Sale"
    /// 
    /// Mr. Geek is a greedy seller.
    /// He has a stock of N laptops which comprises of both useful and useless laptops.
    /// Now, he wants to organize a sale to clear his stock of useless laptops.
    /// The prices of N laptops are Ai each consisting of positive and negative integers (-ve denoting useless laptops).
    /// In a day, he can sell at most M laptops.
    /// Mr. Geek being a greedy seller want to earn maximum profit out of this sale.
    /// So, help him maximizing his profit by selling useless laptops.
    /// 
    /// Input:
    /// The first line of input contains number of test cases T.
    /// For each test case, there will be two lines of input.
    /// The first line contains two integers N and M.
    /// The second line contains prices of N laptops.
    /// 
    /// Output:
    /// The maximum profit Mr.
    /// Geek can earn in a single day.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N ≤ 10e7
    /// 1 <= M <= 10e7
    /// -10e18 <= Ai <= 10e18
    /// 
    /// Sample Input:
    /// 3
    /// 4 3
    /// -6 0 35 4
    /// 5 3
    /// -6 0 35 -2 4
    /// 3 6728
    /// -28589 -13197 -18851
    /// 
    /// Sample Output:
    /// 6
    /// 8
    /// 117 244 524
    /// 
    /// Explanation:
    /// Geek sells the laptops with price -6 and earns Rs. 6 as profit.
    ///
    /// Remark:
    /// 1) The problem statement is not clear !
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SumOfNegatives
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
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var m = int.Parse(split[1]);
                var numbers = StringScanner.GetLong(test[1], n);
                Array.Sort(numbers);
                long sum = 0;
                var i = 0;
                while (numbers[i] < 0 && m-- > 0)
                {
                    sum += numbers[i++];
                }

                Console.WriteLine(sum * -1);
            }
        }
    }
}