﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Jay's Apples"
    /// 
    /// One day Jay, on getting his first salary, decides to distribute apples among the poverty-stricken persons.
    /// He gave each person 1kg of apples.
    /// People are coming in a queue and he makes sure that he gives every person 1 kg of apples only once.
    /// Every person is identified by a specific integer.
    /// 
    /// Given the length of the queue N followed by an array of N integers, denoting the persons in that queue
    ///     Find the minimum kgs of apples Jay will have to distribute.
    /// 
    /// Input:
    /// The first line of the input contains an integer T denoting the number of test cases.
    /// For each test case there will be two test lines.
    /// The first line contains the length of queue N.
    /// The second line contains the N space separated integers which denotes the people in the queue.
    /// 
    /// Output:
    /// For each test case, output a single line containing the answer.
    /// 
    /// Constraints:
    /// 1 ≤ T ≤ 20
    /// 1 ≤ N ≤ 10e5
    /// 1 ≤ Ai ≤ 10e5
    /// 
    /// Example:
    /// 
    /// Input:
    /// 2
    /// 5
    /// 1 1 1 1 1
    /// 5
    /// 1 2 3 1 2
    /// 
    /// Output:
    /// 1
    /// 3
    /// 
    /// Explanation:
    /// 
    /// For test case 1:
    ///     The same person (identified by the integer '1' comes again and again in the queue, but Jay will not give him apples again and again.
    ///     He gave him apples only once so minimum kgs of apples here required-1kg).
    /// For test case 2:
    ///     Person '1' comes and takes 1kg of apples,
    ///     Then person '2' comes and takes 1kg of apples from Jay
    ///     Then person '3' comes and he also takes 1kg of apples from Jay,
    ///     Then person '1' again comes but he gets nothing as he has already been awarded apples and so with person '2'.
    ///     So, minimum kgs of apples require 3kg.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class CountDistinctElements
    {
        public static void Run()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (int i = 0; i < testCount; i++)
            {
                
            }
        }
    }
}