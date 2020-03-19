namespace Geeks.Practices.Helper
{
    public static class IntegerExtensions
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

        public static bool IsPrime(this int number)
        {
            var result = true;
            if (number < 2)
            {
                result = false;
            }
            else if (number % 2 == 0)
            {
                result = false;
            }
            else
            {
                for (var i = 3; i * i <= number; i += 2)
                {
                    if (number % i == 0)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }
    }
}