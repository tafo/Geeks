using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Tracks"
    ///  
    /// Vishesh, who doesn't like maths, has to certify v-shaped tracks.
    /// A track is valid if it satisfies the following conditions :
    /// 1. There must be a constant difference between the height of pillars (not zero) of a track.
    ///     For eg., if the heights of first two pillars are 7 and 5, then height of 3rd pillar must be 3.
    ///     As 7-5=2 &amp; 5-3=2.
    /// 2. The height of middle pillar must be always 1.
    /// 3. Number of pillars on the left side must be equal to the number of pillars on the right side of middle pillar.
    ///     And their heights must be also equal. for example: Track with pillar heights [3 2 1 2 3] is a valid track. 
    /// Help him in finding the valid tracks.
    /// 
    /// Input:
    /// The first line of input contains an integer T denoting the number of test cases.
    /// Then T test cases follow.
    /// Each test case consists of two lines.
    /// First line of each test case contains an Integer N denoting number of pillars
    /// And the second line contains N space separated integers which are the heights of pillar.
    /// 
    /// Output:
    /// Print on the new  line "Yes" if it is a valid v-shaped track.
    /// Otherwise, print "No".
    /// 
    /// Constraints:
    /// 1 <= T <= 100
    /// 3 <= N <= 10e6
    /// 1 <= H[i] <= 10e6
    /// 
    /// Example:
    /// Input:
    /// 2
    /// 3
    /// 2 1 2
    /// 5
    /// 4 3 2 3 4
    /// 
    /// Output:
    /// Yes
    /// No
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Curve
    {
        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());

            while (testCount-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var result = "Yes";
                if ((n & 1) == 0)
                {
                    result = "No";
                    Console.ReadLine(); // Skip the elements
                }
                else
                {
                    var scanner = new StringScanner(Console.ReadLine().TrimEnd());
                    var half = (n + 1) / 2;
                    var previous = scanner.NextPositiveInt();
                    var current = scanner.NextPositiveInt();
                    var dif = previous - current;
                    if (dif > 0)
                    {
                        var c = 2;
                        while (scanner.HasNext)
                        {
                            if (c < half)
                            {
                                previous = current;
                                current = scanner.NextPositiveInt();
                                c++;
                                if (previous - current == dif) continue;
                                result = "No";
                                break;
                            }

                            if (c == half)
                            {
                                c++;
                                if (current == 1) continue;
                                result = "No";
                                break;
                            }

                            previous = current;
                            current = scanner.NextPositiveInt();
                            c++;
                            if (current - previous == dif) continue;
                            result = "No";
                            break;
                        }
                    }
                    else
                    {
                        result = "No";
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}