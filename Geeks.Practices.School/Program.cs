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
            switch (args)
            {
                case null:
                    index = 2;
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
            }
        }
    }
}
