using System;
using System.Diagnostics;
using Geeks.Practices.School.Arrays;

namespace Geeks.Practices.School
{
    /// <summary>
    /// Even school practices are useful
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            int index;
            switch (args.Length)
            {
                case 0:
                    index = 21;
                    break;
                default:
                    int.TryParse(args[0], out index);
                    break;
            }

            switch (index)
            {
                case 0:
                    SumOfElements.Run();
                    break;
                case 1:
                    LargestElement.Run();
                    break;
                case 2:
                    SecondLargestElement.Run();
                    break;
                case 3:
                    AlternateElements.Run();
                    break;
                case 4:
                    SumOfSeries.Run();
                    break;
                case 5:
                    SumOfSeries.Run();
                    break;
                case 6:
                    MaxAndMinElements.Run();
                    break;
                case 7:
                    PalindromeNumbers.Run();
                    break;
                case 8:
                    DisplayLongestName.Run();
                    break;
                case 9:
                    SwapElements.Run();
                    break;
                case 10:
                    CountGreaterElements.Run();
                    break;
                case 11:
                    ProductOfElements.Run();
                    break;
                case 12:
                    FindSmallerElements.Run();
                    break;
                case 13:
                    FindMiddleElement.Run();
                    break;
                case 14:
                    FindTalent.Run();
                    break;
                case 15:
                    FindElementByIndex.Run();
                    break;
                case 16:
                    MovingAverage.Run();
                    break;
                case 17:
                    SmallerAndLarger.Run();
                    break;
                case 18:
                    SeAndGeNumbersForSorted.Run();
                    break;
                case 19:
                    Reverse.Run();
                    break;
                case 20:
                    FindIndex.Run();
                    break;
                case 21:
                    PrintElements.Run();
                    break;
            }
        }
    }
}
