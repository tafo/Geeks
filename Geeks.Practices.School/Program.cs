using Geeks.Practices.School.Solutions;

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
                    index = 3;
                    break;
                default:
                    int.TryParse(args[0], out index);
                    break;
            }

            switch (index)
            {
                case 0:
                    SumOfArrayElements.Run();
                    break;
                case 1:
                    LargestElementInArray.Run();
                    break;
                case 2:
                    SecondLargestElementInArray.Run();
                    break;
                case 3:
                    AlternateElementsInArray.Run();
                    break;
            }
        }
    }
}
