namespace Geeks.Practices.Helper
{
    internal static class IntegerExtensions
    {
        // GCD = Greatest Common Divisor
        internal static int GCD(this int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }
    }
}