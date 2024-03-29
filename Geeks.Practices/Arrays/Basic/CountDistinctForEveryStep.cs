﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
        /// Time limit exceeded !!!
        /// * Check Dictionary solution 
        /// </summary>
        public static void RunAway()
        {
            var testCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var numbers = new int[n][];
                var x = 0;
                var counter = 0;
                for (var a = 0; a < n; a++)
                {
                    var split = Console.ReadLine().Split(' ');
                    var number = int.Parse(split[1]);
                    var index = Array.FindIndex(numbers, p => p != null && p[0] == number);
                    if (split[0] == "A")
                    {
                        if (index == -1)
                        {
                            numbers[x] = new int[2];
                            numbers[x][0] = number;    
                            numbers[x++][1] = 1;
                            counter++;
                        }
                        else
                        {
                            numbers[index][1]++;
                        }
                    }
                    else
                    {
                        if (index != -1)
                        {
                            if (numbers[index][1] == 1)
                            {
                                numbers[index][0] = 0;
                                counter--;
                            }
                            else
                            {
                                numbers[index][1]--;
                            }
                        }
                    }

                    Console.WriteLine(counter);
                }
            }
        }

        /// <summary>
        /// The execution time is 0.63
        /// * Actually, Dictionary should be used in Arrays category
        /// </summary>
        public static void RunDictionary()
        {
            var testCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCount; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var elements = new Dictionary<string, int>();
                for (var a = 0; a < n; a++)
                {
                    var split = Console.ReadLine().Split(' ');
                    var element = split[1];
                    if (split[0] == "A")
                    {
                        if (elements.ContainsKey(element))
                        {
                            elements[element]++;
                        }
                        else
                        {
                            elements.Add(element, 1);
                        }
                    }
                    else if (elements.ContainsKey(element))
                    {
                        if (elements[element] == 1)
                        {
                            elements.Remove(element);
                        }
                        else
                        {
                            elements[element]--;
                        }
                    }
                    Console.WriteLine(elements.Count);
                }
            }
        }
    }
}