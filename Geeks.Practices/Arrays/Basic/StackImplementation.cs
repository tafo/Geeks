using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// Implement a Stack using Array. Your task is to complete the functions below.
    /// 
    /// Input Format:
    /// The first line of the input contains an integer 'T' denoting the number of test cases. Then T test cases follow.
    /// First line of each test case contains an integer Q denoting the number of queries . 
    /// A Query Q is of 2 Types:
    /// (i) 1 x   (a query of this type means  pushing 'x' into the stack)
    /// (ii) 2     (a query of this type means to pop element from stack and print the popped element)
    /// The second line of each test case contains Q queries separated by space.
    /// 
    /// Output Format:
    /// The output for each test case will  be space separated integers having -1 if the stack is empty else the element popped out from the stack.
    /// 
    /// Your Task:
    /// You are required to complete two methods
    ///     "push" which take one argument an integer 'x' to be pushed into the stack
    ///     and "pop" which returns a integer popped out from the stack.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= Q <= 100
    /// 1 <= x <= 100
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 5
    /// 1 2 1 3 2 1 4 2
    /// 4
    /// 2 1 4 1 5 2   
    /// 20
    /// 2 2 1 40 2 1 68 2 1 28 1 85 1 21 1 23 2 1 82 1 85 1 73 1 51 2 2 1 100 1 43 1 14
    /// 9
    /// 1 43 1 97 2 1 12 1 16 2 1 33 1 51 2
    /// 
    /// Output:
    /// 3 4
    /// -1 5
    /// -1 -1 40 68 23 51 73
    /// 97 16 51
    /// 
    /// Explanation:
    /// In the first test case for query 
    /// 1 2    the stack will be {2}
    /// 1 3    the stack will be {2 3}
    /// 2       poped element will be 3 the stack will be {2}
    /// 1 4    the stack will be {2 4}
    /// 2       poped element will be 4
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class StackImplementation
    {
        public static void Run()
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
                var resultBuilder = new StringBuilder();
                var n = int.Parse(testCase[0]);
                var stack = new int[n];
                var scanner = new StringScanner(testCase[1]);
                var position = -1;
                
                while (scanner.HasNext)
                {
                    var element = scanner.NextPositiveInt();
                    switch (element)
                    {
                        case 1:
                            stack[++position] = scanner.NextPositiveInt();
                            break;
                        case 2 when position  == -1:
                            resultBuilder.Append("-1");
                            resultBuilder.Append(" ");
                            break;
                        case 2:
                            resultBuilder.Append(stack[position--]);
                            resultBuilder.Append(" ");
                            break;
                    }
                }

                Console.WriteLine(resultBuilder.ToString().TrimEnd());
            }
        }

        /// <summary>
        /// C# option was not available@"08 Mar 2020"
        /// </summary>
        public static void RunForGeeks()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t];

            for (var i = 0; i < t; i++)
            {
                input[i] = Console.ReadLine().TrimEnd();
            }

            foreach (var query in input)
            {
                var resultBuilder = new StringBuilder();
                var scanner = new StringScanner(query);
                var stack = new ThatStack();
                while (scanner.HasNext)
                {
                    var element = scanner.NextPositiveInt();
                    switch (element)
                    {
                        case 1:
                            stack.Push(scanner.NextPositiveInt());
                            break;
                        case 2:
                            resultBuilder.Append(stack.Pop());
                            resultBuilder.Append(" ");
                            break;
                    }
                }

                Console.WriteLine(resultBuilder.ToString());
            }
        }
    }

    /// <summary>
    /// Fields and Method signatures were specified by GeeksForGeeks
    /// </summary>
    public class ThatStack
    {
        private int _top;
        private readonly int[] _elements = new int[1000];

        public ThatStack()
        {
            _top = -1;
        }

        public void Push(int element) => _elements[++_top] = element;

        public int Pop() => _top == -1 ? -1 : _elements[_top--];
    }
}