using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sorting Employees"
    /// 
    /// You have records of employee name as string (Ename) and salary as positive integer (S).
    /// You have to sort the records on the basis of employee salary, if salary is same then use employee name for comparison.
    /// 
    /// Input:
    /// The first line consists of a number T denoting the number of test cases.
    /// Each test case will consist of a integer N denoting number of employees followed by the name and salary of the employee with spaces.
    /// 
    /// Output:
    /// Each test case consists of a single line.
    /// It consists of the name and salary of the employees with spaces.
    /// 
    /// Constraints:
    /// 1 <= T <= 200
    /// 1 <= N <= 1000
    /// 1 <= Ename <= 10e6
    /// 1 <= S <= 10e6
    /// 
    /// Example:
    /// 
    /// Input:
    /// 3
    /// 2
    /// xbnnskd 100 geek 50
    /// 2
    /// shyam 50 ram 50
    /// 5
    /// a 1 d 2 c 3 b 2 e 1
    ///
    /// Output:
    /// geek 50 xbnnskd 100
    /// ram 50 shyam 50
    /// a 1 e 1 b 2 d 2 c 3
    /// 
    /// Explanation:
    /// Testcase 1:
    /// geek has lowest salary as 50 and xbnnskd has more salary.
    /// So sorted output is as given in sample.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SortingWorker
    {
        /// <summary>
        /// The execution time is 0.21
        /// </summary>
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
                var n = int.Parse(test[0]);
                var workers = new string[n];
                var salaries = new int[n];
                var index = 0;
                var scanner = new StringScanner(test[1]);
                while (scanner.HasNext)
                {
                    workers[index] = scanner.NextString();
                    salaries[index++] = scanner.NextPositiveInt();
                }
                Array.Sort(salaries, workers);

                var k = 1;
                var length = 1;
                while (k  < n)
                {
                    if (salaries[k] == salaries[k - 1])
                    {
                        length++;
                        if (k == n - 1)
                        {
                            Array.Sort(workers, k - length + 1, length);
                        }
                    }
                    else if (salaries[k] > salaries[k - 1] && length > 1)
                    {
                        Array.Sort(workers, k - length, length);
                        length = 1;
                    }

                    k++;
                }

                var builder = new StringBuilder();
                for (var i = 0; i < n; i++)
                {
                    builder.AppendFormat("{0} {1} ", workers[i], salaries[i]);
                }

                Console.WriteLine(builder.ToString());
            }
        }
    }
}