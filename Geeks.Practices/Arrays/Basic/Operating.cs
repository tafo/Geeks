using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Operating an array"
    /// 
    /// Given an array A of size N, your task is to do some operations,
    ///     i.e., search an element, insert an element, and delete an element by completing the functions.
    /// Also, all functions should return a boolean value.
    /// 
    /// Input Format:
    /// The first line of input consists of T, the number of test cases.
    /// T test cases follow.
    /// Each test case contains 3 lines of input.
    /// The first line of every test case consists of an integer N, denotes the number of elements in an array.
    /// The second line of every test cases consists of N spaced integers Ai.
    /// The third line of every test case consists of four integers X, Y, Yi and Z
    ///     denoting the elements for the search operation, insert operation, insert operation element index and delete operation respectively.
    /// 
    /// Output Format:
    /// For each test case, return 1 for each operation if done successfully else 0.
    /// 
    /// Your Task:
    /// Since this is a function problem, you only need to complete the provided functions.
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 1 <= N <= 100
    /// 1 <= Ai <= 100
    /// 
    /// Example:
    /// Input:
    /// 4
    /// 5
    /// 2 4 1 0 6
    /// 1 2 2 0
    /// 6
    /// 801 661 730 878 305 320 
    /// 736 444 0 522
    /// 16
    /// 127 504 629 49 964 285 429 343 335 177 900 238 971 949 289 367 
    /// 988 292 3 743
    /// 84
    /// 886 777 915 793 335 386 492 649 421 362 27 690 59 763 926 540 426 172 736 211 368 567 429 782 530 862 123 67 135 929 802 22 58 69 167 393 456 11 42 229 373 919 784 537 198 324 315 370 413 526 91 980 956 873 170 996 281 305 925 84 327 336 505 846 729 313 857 124 895 582 545 814 367 434 364 43 750 87 808 276 178 788 584 403
    /// 651 754 43 932
    /// Output:
    /// 1 1 1
    /// 0 1 1
    /// 0 1 1
    /// 0 1 1
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
    [SuppressMessage("ReSharper", "ForCanBeConvertedToForeach")]
    [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
    public class Operating
    {
        /// <summary>
        /// The execution time of the equivalent JAVA function is 0.34
        /// </summary>
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                Console.ReadLine(); // Skip the number of elements
                tests[i][0] = Console.ReadLine().TrimEnd();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var elements = test[0].Split(' ').Select(int.Parse).ToArray();
                var operations = test[1].Split(' ').Select(int.Parse).ToArray();
                Console.Write(Search(elements, operations[0]) ? "1 " : "0 ");
                Console.Write(Insert(elements, operations[1], operations[2]) && elements[operations[2]] == operations[1] ? "1 " : "0 ");
                Console.WriteLine(Delete(elements, operations[3]) && !Search(elements, operations[3]) ? "1" : "0");
            }
        }

        private static bool Search(int[] elements, int x)
        {
            bool found = false;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != x) continue;
                found = true;
                break;
            }

            return found;
        }

        private static bool Insert(int[] elements, int y, int i)
        {
            if (i >= elements.Length || i < 0) return false;
            elements[i] = y;
            return true;
        }

        private static bool Delete(int[] elements, int z)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != z) continue;
                elements[i] = -1;
            }

            return true;
        }
    }
}