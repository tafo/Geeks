using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Distinct Elements in a Stream"
    /// 
    /// Given an input stream of N integers (along with the operation on these integers),
    ///     the task is to print the number of the distinct elements in the stream after each operation.
    /// There can be two types of operations that can be performed:
    /// 
    /// Addition represented by A.
    /// Deletion represented by R.
    /// Input:
    /// First line of the input contains an integer T denoting the number of test cases.
    /// Then T test case follows.
    /// First line of each test case contains an integer N denoting the number of operations to be performed on a stream.
    /// Next N lines two space separated elements, the operation to be performed and the key element.
    /// 
    /// Output:
    /// For each operation output the number of the distinct characters in a stream on a new line.
    /// 
    /// Constraints:
    /// 1<=N<=10e6
    /// 1<=A[]<=10e6
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 8
    /// A 5
    /// A 5
    /// A 7
    /// R 5
    /// R 7
    /// A 1
    /// A 2
    /// R 2
    /// 100
    /// R 8362
    /// A 4784
    /// R 1851
    /// R 6978
    /// R 8750
    /// R 5408
    /// A 5226
    /// R 4904
    /// A 6732
    /// R 1217
    /// A 7378
    /// A 2344
    /// A 7608
    /// R 2367
    /// R 9294
    /// A 3179
    /// A 7512
    /// A 7344
    /// A 1832
    /// A 4792
    /// A 28
    /// R 2399
    /// A 9403
    /// A 4237
    /// A 9445
    /// R 4941
    /// A 1620
    /// R 5798
    /// R 7313
    /// R 4108
    /// A 1815
    /// R 8927
    /// R 716
    /// R 2237
    /// R 4763
    /// R 7973
    /// A 6917
    /// A 299
    /// A 1874
    /// A 9889
    /// A 2608
    /// R 8364
    /// A 4648
    /// A 440
    /// R 2619
    /// A 4725
    /// A 6151
    /// A 2663
    /// A 21
    /// R 8240
    /// A 9692
    /// R 4532
    /// R 6089
    /// R 9866
    /// R 5244
    /// A 1545
    /// A 2822
    /// R 9100
    /// R 4112
    /// A 387
    /// A 6771
    /// A 5951
    /// A 1488
    /// R 1348
    /// R 3085
    /// R 4198
    /// A 3228
    /// A 1324
    /// R 6863
    /// R 6889
    /// A 5955
    /// A 9081
    /// R 3456
    /// A 7631
    /// R 7260
    /// A 6162
    /// R 9622
    /// R 3549
    /// R 4552
    /// R 9567
    /// R 206
    /// R 4072
    /// A 2501
    /// R 394
    /// R 4737
    /// A 9635
    /// R 9
    /// R 5944
    /// A 7242
    /// A 9717
    /// R 1959
    /// A 8189
    /// R 3613
    /// A 5064
    /// R 200
    /// A 1589
    /// R 8164
    /// R 3629
    /// R 4772
    /// R 3512
    /// 
    /// Output:
    /// 1
    /// 1
    /// 2
    /// 2
    /// 1
    /// 2
    /// 3
    /// 2
    /// (Second output)
    /// 0
    /// 1
    /// 1
    /// 1
    /// 1
    /// 1
    /// 2
    /// 2
    /// 3
    /// 3
    /// 4
    /// 5
    /// 6
    /// 6
    /// 6
    /// 7
    /// 8
    /// 9
    /// 10
    /// 11
    /// 12
    /// 12
    /// 13
    /// 14
    /// 15
    /// 15
    /// 16
    /// 16
    /// 16
    /// 16
    /// 17
    /// 17
    /// 17
    /// 17
    /// 17
    /// 17
    /// 18
    /// 19
    /// 20
    /// 21
    /// 22
    /// 22
    /// 23
    /// 24
    /// 24
    /// 25
    /// 26
    /// 27
    /// 28
    /// 28
    /// 29
    /// 29
    /// 29
    /// 29
    /// 29
    /// 30
    /// 31
    /// 31
    /// 31
    /// 32
    /// 33
    /// 34
    /// 35
    /// 35
    /// 35
    /// 35
    /// 36
    /// 37
    /// 37
    /// 37
    /// 38
    /// 39
    /// 39
    /// 40
    /// 40
    /// 41
    /// 41
    /// 41
    /// 41
    /// 41
    /// 41
    /// 41
    /// 42
    /// 42
    /// 42
    /// 43
    /// 43
    /// 43
    /// 44
    /// 45
    /// 45
    /// 46
    /// 46
    /// 47
    /// 47
    /// 48
    /// 48
    /// 48
    /// 48
    /// 48
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class CountDistinctForEveryStep
    {
        /// <summary>
        /// Time Limit Exceeded
        /// Expected Time Limit < 3.256 sec
        /// </summary>
        public static void RunAwayLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                var n = int.Parse(tests[i][0]);
                for (var a = 0; a < n; a++)
                {
                    tests[i][1] += Console.ReadLine().TrimEnd() + " ";
                }
            }

            foreach (var test in tests)
            {
                var n = int.Parse(test[0]);
                var numbers = new int[n];
                var scanner = new StringScanner(test[1].TrimEnd());
                var i = 0;
                var counter = 0;
                while (scanner.HasNext)
                {
                    var c = scanner.NextChar();
                    var number = scanner.NextPositiveInt();
                    var index = Array.IndexOf(numbers, number, 0, i);
                    if (c == 'A')
                    {
                        numbers[i++] = number;
                        if (index == -1)
                        {
                            counter++;
                        }
                    }
                    else if (index != -1)
                    {
                        numbers[index] = 0;
                        counter--;
                    }
                    Console.WriteLine(counter);
                }
            }
        }
        
        /// <summary>
        /// Time Limit Exceeded
        /// Expected Time Limit < 3.256 sec
        /// </summary>
        public static void RunAwayAnother()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine().TrimEnd());
                tests[i] = new string[n];

                for (var a = 0; a < n; a++)
                {
                    tests[i][a] = Console.ReadLine();
                }
            }

            foreach (var test in tests)
            {
                var numbers = new int[test.Length];
                var counter = 0;
                var i = 0;
                foreach (var line in test)
                {
                    var split = line.Split(' ');
                    var operation = split[0];
                    var number = int.Parse(split[1]);
                    var index = Array.IndexOf(numbers, number, 0, i);
                    if (operation == "A")
                    {
                        numbers[i++] = number;
                        if (index == -1)
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        if (index != -1)
                        {
                            numbers[index] = 0;
                            counter--;
                        }
                    }

                    Console.WriteLine(counter);
                }
            }
        }

        /// <summary>
        /// Time Limit Exceeded
        /// Expected Time Limit < 3.256 sec
        /// </summary>
        public static void RunAway()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine().TrimEnd());
                tests[i] = new string[n];

                for (var a = 0; a < n; a++)
                {
                    tests[i][a] = Console.ReadLine();
                }
            }

            foreach (var test in tests)
            {
                var numbers = new int[test.Length];
                var counter = 0;
                var sb = new StringBuilder(test.Length);
                var i = 0;
                for (var a = 0; a < test.Length; a++)
                {
                    var line = test[a];
                    var split = line.Split(' ');
                    var operation = split[0];
                    var number = int.Parse(split[1]);
                    if (operation == "A")
                    {
                        if (Array.IndexOf(numbers, number) == -1)
                        {
                            counter++;
                        }

                        numbers[i++] = number;
                    }
                    else
                    {
                        var index = Array.IndexOf(numbers, number);
                        if (index != -1)
                        {
                            numbers[index] = 0;
                            counter--;
                        }
                    }

                    if (a == test.Length - 1)
                    {
                        sb.Append(counter.ToString());
                    }
                    else
                    {
                        sb.AppendLine(counter.ToString());
                    }
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }
}