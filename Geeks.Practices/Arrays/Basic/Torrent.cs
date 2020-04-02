using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Tiger Zinda Hai"
    /// 
    /// Rohan is downloading the movie Tiger Zinda Hai using a torrent website,
    ///     but he is new to torrent, so he doesn't know the difference between a fake download button and a real download button;
    ///     therefore, he keeps pressing every button in excitement.
    /// Now he has clicked N  buttons, and many tabs are opened , if a opened tab is clicked again then it closes it. 
    /// Your task is to tell how many tabs are open at the end.
    /// 
    /// Input:
    /// First line consists of T test cases.
    /// First line of every test case consists of an integer N.
    /// Next line will be the N numbers of Tab clicked or "END".
    /// The "END" button means that all the tabs will be closed.
    /// 
    /// Output:
    /// Single line output, print how many tabs are open at the end.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10000
    /// 
    /// Example:
    /// Input:
    /// 1
    /// 5
    /// 1 2 1 END 2
    /// 
    /// Output:
    /// 1
    /// 
    /// Explanation:
    /// In the above test case, firstly tab 1st is opened then 2nd is opened then 1st is closed then all are closed then again 2nd is opened.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Torrent
    {
        /// <summary>
        /// The execution time is 0.36
        /// </summary>
        public static void RunLinq()
        {
            var testCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var split = Console.ReadLine().Split("END");
                var last = split[^1].Trim();
                if (last.Length == 0)
                {
                    Console.WriteLine(0);
                    continue;
                }

                Console.WriteLine(last.Split(' ').Select(int.Parse).GroupBy(x => x).Count(x => (x.Count() & 1) == 1));
            }
        }

        /// <summary>
        /// The execution time is 0.19
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var split = Console.ReadLine().Split("END");
                var last = split[^1].Trim();
                if (last.Length == 0)
                {
                    Console.WriteLine(0);
                    continue;
                }
                var scanner = new StringScanner(last);
                var tabs = new int[n];
                var counter = 0;
                while (scanner.HasNext)
                {
                    tabs[counter++] = scanner.NextPositiveInt();
                }

                Array.Sort(tabs, 0, counter);
                var left = tabs[0];
                var result = 1;
                var flag = false;
                for (var c = 1; c < counter; c++)
                {
                    if (tabs[c] == left)
                    {
                        if (flag)
                        {
                            result++;
                        }
                        else
                        {
                            result--;
                        }

                        flag = !flag;
                    }
                    else
                    {
                        result++;
                        flag = false;
                    }

                    left = tabs[c];
                }

                Console.WriteLine(result);
            }
        }
    }
}