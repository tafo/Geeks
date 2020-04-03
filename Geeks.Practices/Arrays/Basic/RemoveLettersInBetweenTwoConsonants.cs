using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Sandwiched_Vowels"
    /// 
    /// For a given string S,
    ///     comprising of only lowercase English alphabets,
    ///     eliminate the vowels from the string that occur between two consonants(sandwiched between two immediately adjacent consonants).
    /// Print the updated string on a new line.
    /// 
    /// Input:
    /// First line of input is an integer T, denoting the number of test cases.
    /// For each test case, input the string S on a new line.
    /// 
    /// Output:
    /// For each test case, the only line of output is the updated string after omission of all sandwiched vowels.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 3<=L<=10, where L is length of string S
    /// 'a'<=S[i]<='z', i is an integer denoting index of S
    /// 
    /// 
    /// Example:
    /// Input:
    /// 5
    /// bab
    /// ceghij
    /// aaii
    /// gghho
    /// saaafor
    /// 
    /// Output:
    /// bb
    /// cghj
    /// aaii
    /// gghho
    /// saaafr
    /// 
    /// Explanation:
    /// 
    /// In the first test case, a is a vowel occuring between two consonants i.e. b. Hence the updated string eliminates a.
    /// In the second test case, e and i are the vowels occurring between tow consonants. Hence they are removed from the string.
    /// In the third and fourth test cases, there is no such vowel that occurs between two consonants. Hence the string remains unchanged.
    /// In the fifth test case, o occurs between f and r which are consonants, hence is eliminated.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class RemoveLettersInBetweenTwoConsonants
    {
        /// <summary>
        /// The execution time is 0.13
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var input = Console.ReadLine().ToCharArray();
                var vowels = new[] { 'a','e','i','o','u'};
                var result = input.Where((x, i) =>
                    i == 0 || i == input.Length - 1 || vowels.Contains(input[i - 1]) || !vowels.Contains(x) || vowels.Contains(input[i + 1]));
                Console.WriteLine(string.Join(string.Empty, result));
            }
        }

        /// <summary>
        /// The execution time is 0.08
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            while (testCount-- > 0)
            {
                var input = Console.ReadLine().ToCharArray();
                var resultBuilder = new StringBuilder();
                resultBuilder.Append(input[0]);
                var vowels = new[] { 'a','e','i','o','u'};
                for (var i = 1; i < input.Length - 1; i++)
                {
                    if (Array.IndexOf(vowels, input[i - 1]) == -1 && 
                        Array.IndexOf(vowels, input[i]) != -1 &&
                        Array.IndexOf(vowels, input[i + 1]) != -1)
                    {
                        continue;
                    }

                    resultBuilder.Append(input[i]);
                }

                resultBuilder.Append(input[^1]);

                Console.WriteLine(resultBuilder.ToString());
            }
        }
    }
}