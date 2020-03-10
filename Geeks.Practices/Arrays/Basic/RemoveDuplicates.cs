using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Remove duplicate elements from sorted Array"
    /// 
    /// Given a sorted array A of size N. The function remove_duplicate takes two arguments.
    /// The first argument is the sorted array A[] and the second argument is 'N' the size of the array
    ///     And returns the size of the new converted array A[] with no duplicate element.
    /// 
    /// Input Format:
    /// The first line of input contains T denoting the no of test cases.
    /// Then T test cases follow.
    ///     The first line of each test case contains an Integer N and the next line contains N space separated values of the array A[].
    /// 
    /// Output Format:
    /// For each test case output will be the transformed array with no duplicates.
    /// 
    /// Your Task:
    /// Your task to complete the function remove_duplicate which removes the duplicate  elements from the array .
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 10e4
    /// 1 <= A[i] <= 10e6
    /// 
    /// Example:
    /// Input  (To be used only for expected output) :
    /// 4
    /// 5
    /// 2 2 2 2 2 
    /// 3
    /// 1 2 2
    /// 34
    /// 2 6 7 7 12 17 24 30 30 36 38 41 42 42 43 43 45 47 48 49 51 54 58 60 63 65 65 69 71 74 79 89 91 91
    /// 21
    /// 1 8 19 22 28 29 35 39 49 49 54 68 69 82 84 85 89 94 97 100 100
    /// Output
    /// 2
    /// 1 2
    /// 2 6 7 12 17 24 30 36 38 41 42 43 45 47 48 49 51 54 58 60 63 65 69 71 74 79 89 91 
    /// 1 8 19 22 28 29 35 39 49 54 68 69 82 84 85 89 94 97 100
    /// 
    /// Note:The Input/Ouput format and Example given are used for system's internal purpose, and should be used by a user for Expected Output only.
    /// As it is a function problem, hence a user should not read any input from stdin/console.
    /// The task is to complete the function specified, and not to write the full code.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class RemoveDuplicates
    {
        /// <summary>
        /// The execution time is 0.28
        /// </summary>
        public static void Run()
        {
            var t = int.Parse(Console.ReadLine());
            var input = new string[t][];

            for (var i = 0; i < t; i++)
            {
                input[i] = new string[2];
                input[i][0] = Console.ReadLine();
                input[i][1] = Console.ReadLine().Trim();
            }

            foreach (var testCase in input)
            {
                var n = int.Parse(testCase[0]);
                var elements = testCase[1].Split(' ').Select(int.Parse).ToArray();
                var size = RemoveDuplicate(elements);
                var uniqueElements = elements.Take(size);
                Console.WriteLine(string.Join(' ', uniqueElements));
            }
        }

        /// <summary>
        /// The equivalent C# method signature of the given JAVA function signature
        /// </summary>
        // ReSharper disable once SuggestBaseTypeForParameter
        private static int RemoveDuplicate(int[] array)
        {
            var previous = array[0];
            var counter = 1;
            for (var i = 1; i < array.Length; i++)
            {
                if (previous == array[i])
                {
                    continue;
                }

                array[counter++] = previous = array[i];
            }

            return counter;
        }
    }
}