using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Stack.Basic
{
    /// <summary>
    /// The title is "Pairwise Consecutive Elements"
    /// 
    /// Given a stack of integers of size N,
    ///     your task is to complete the function pairWiseConsecutive(),
    ///     that checks whether numbers in the stack are pairwise consecutive or not.
    /// The pairs can be increasing or decreasing,
    ///     and if the stack has an odd number of elements,
    ///     the element at the top is left out of a pair.
    /// The function should retain the original stack content.
    /// 
    /// Only following standard operations are allowed on stack.
    /// 
    /// push(X): Enter a element X on top of stack.
    /// pop(): Removes top element of the stack.
    /// empty(): To check if stack is empty.
    /// Input Format:
    /// The first line of input contains T denoting the number of test cases.
    /// T test cases follow.
    /// Each test case contains two lines of input.
    /// The first line contains n denoting the number of elements to be inserted into the stack.
    /// The second line contains the elements to be inserted into the stack.
    /// 
    /// Output Format:
    /// For each test case,
    ///     in a new line,
    ///     print "Yes"(without quote) if the elements of the stack is pairwise consecutive,
    ///     else print "No".
    /// 
    /// Your Task:
    /// This is a function problem.
    /// You only need to complete the function pairWiseConsecutive that
    ///     takes a stack as an argument and returns true if the stack is found to be pairwise consecutive,
    ///     else it returns false.
    /// The printing is done by the driver code.
    /// 
    /// Constraints:
    /// 1 < =T <= 100
    /// 1 < =N <= 10e3
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 6
    /// 1 2 3 4 5 6
    /// 5
    /// 1 5 3 9 7
    /// 
    /// Output:
    /// Yes
    /// No
    /// 
    /// Explanation:
    /// Testcase1:
    /// The number of elements are even and they are pairwise consecutive so we print Yes.
    /// 
    /// Testcase2:
    /// The number of elements are odd so we remove the top element and check for pairwise consecutive.
    /// It is not so we print No.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CheckWhetherPairwiseConsecutiveOrNot
    {
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                Console.ReadLine(); // Skip the number of elements
                var elements = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), int.Parse);
                var stack = new Stack<int>();
                foreach (var element in elements)
                {
                    stack.Push(element);
                }
                Console.WriteLine(CheckPairwiseConsecutive(stack));
            }
        }

        private static bool CheckPairwiseConsecutive(Stack<int> set)
        {
            var result = true;
            while (set.Count > 0)
            {
                var previous = set.Pop();
                if (set.Count == 0) continue;
                var current = set.Pop();
                if (Math.Abs(current - previous) == 1) continue;
                result = false;
                break;
            }

            return result;
        }
    }
}