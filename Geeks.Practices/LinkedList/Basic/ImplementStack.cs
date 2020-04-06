using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.LinkedList.Basic
{
    /// <summary>
    /// The title is "Implement Stack using Linked List"
    /// 
    /// Let's give it a try!
    /// You have a linked list and you have to implement the functionalities push and pop of stack using this given linked list.
    /// 
    /// Input:
    /// The first line of the input contains an integer 'T' denoting the number of test cases.
    /// Then T test cases follow.
    /// First line of each test case contains an integer Q denoting the number of queries.
    /// A Query Q is of 2 Types
    /// (i) 1 x   (a query of this type means  pushing 'x' into the stack)
    /// (ii) 2     (a query of this type means to pop element from stack and print the popped element)
    /// The second line of each test case contains Q queries separated by space.
    /// 
    /// Output:
    /// For each test case,
    ///     Print space separated integers having -1 if the stack is empty else the element popped out from the stack. 
    /// 
    /// Your Task:
    /// You are required to complete the two methods
    ///     push() which take one argument an integer 'x' to be pushed into the stack
    ///     And pop() which returns a integer popped out from the stack.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= Q <= 100
    /// 1 <= x <= 100
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 5
    /// 1 2 1 3 2 1 4 2
    /// 4
    /// 2 1 4 1 5 2
    /// 
    /// Output:
    /// 3 4
    /// -1 5
    /// 
    /// Explanation:
    /// Testcase 1:
    /// In the first test case for query 
    /// 1 2    the stack will be {2}
    /// 1 3    the stack will be {2 3}
    /// 2      poped element will be 3 the stack will be {2}
    /// 1 4    the stack will be {2 4}
    /// 2      poped element will be 4.
    /// 
    /// Testcase 2:
    /// In the second testcase only two pop operations will be performed and Hence, the output will be -1 5.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ImplementStack
    {
        /// <summary>
        /// The execution time is 0.33
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var stack = new ThatStack();
                Console.ReadLine();
                var scanner = new StringScanner(Console.ReadLine().TrimEnd());
                while (scanner.HasNext)
                {
                    var q = scanner.NextPositiveInt();
                    if (q == 1)
                    {
                        var data = scanner.NextPositiveInt();
                        stack.Push(data);
                    }
                    else
                    {
                        Console.Write($"{stack.Pop()} ");
                    }
                }
                Console.WriteLine();
            }
        }

        private class StackNode
        {
            public readonly int Data;
            public StackNode Next;

            public StackNode(int a)
            {
                Data = a;
                Next = null;
            }
        }

        private class ThatStack
        {

            // Note that top is by default null
            private StackNode _top;

            public void Push(int a)
            {
                var node = new StackNode(a) {Next = _top};
                _top = node;
            }

            public int Pop()
            {
                if (_top == null) return -1;
                var result = _top.Data;
                _top = _top.Next;
                return result;
            }
        }
    }
}