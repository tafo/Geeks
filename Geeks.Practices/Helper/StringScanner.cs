using System.Diagnostics.CodeAnalysis;

namespace Geeks.Practices.Helper
{
    /// <summary>
    /// int.MaxValue = 0x7fffffff >> 2,147,483,647
    /// </summary>
    [SuppressMessage("ReSharper", "CommentTypo")]
    public class StringScanner
    {
        private readonly string _input;
        private readonly int _length;
        private const char Sub = '0';

        public int Position { get; set; }
        public bool HasNext { get; set; }

        public StringScanner(string input, bool isReverse = false)
        {
            _input = input;
            _length = _input.Length;
            if (isReverse)
            {
                Reset(_length - 1);
            }
            else
            {
                Reset();
            }
        }

        public static long[] GetPositive(string input, int n)
        {
            var result = new long[n];
            var i = 0;
            long number = 0;

            foreach (var c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    result[i++] = number;
                    number = 0;
                    continue;
                }

                number = number * 10 + (c - Sub);
            }

            result[i] = number;

            return result;
        }

        public static int[] GetPositiveInt(string input, int n)
        {
            var result = new int[n];
            var i = 0;
            var number = 0;

            foreach (var c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    result[i++] = number;
                    number = 0;
                    continue;
                }

                number = number * 10 + (c - Sub);
            }

            result[i] = number;

            return result;
        }

        public static int[] GetInt(string input, int n)
        {
            var result = new int[n];
            var i = 0;
            var number = 0;
            var isNegative = false;
            foreach (var c in input)
            {
                if (c == '-')
                {
                    isNegative = true;
                }
                else if (char.IsWhiteSpace(c))
                {
                    result[i++] = number * (isNegative ? -1 : 1);
                    number = 0;
                    isNegative = false;
                }
                else
                {
                    number = number * 10 + (c - Sub);    
                }
            }

            result[i] = number;

            return result;
        }

        public int NextInt()
        {
            var result = 0;
            var c = _input[Position++];
            var isNegative = false;
            while (!char.IsWhiteSpace(c))
            {
                if (c == '-')
                {
                    isNegative = true;
                }
                else
                {
                    result = result * 10 + (c - Sub);

                    if (Position == _length)
                    {
                        HasNext = false;
                        break;
                    }
                }
                c = _input[Position++];
            }

            return result * (isNegative ? -1 : 1);
        }

        public int NextPositiveInt()
        {
            var result = 0;
            var c = _input[Position++];

            while (!char.IsWhiteSpace(c))
            {
                result = result * 10 + (c - Sub);

                if (Position == _length)
                {
                    HasNext = false;
                    break;
                }

                c = _input[Position++];
            }

            return result;
        }

        public double NextPositiveDouble()
        {
            double result = 0;
            var c = _input[Position++];

            while (!char.IsWhiteSpace(c))
            {
                result = result * 10 + (c - Sub);

                if (Position == _length)
                {
                    HasNext = false;
                    break;
                }

                c = _input[Position++];
            }

            return result;
        }

        public int PreviousPositiveInt()
        {
            var result = 0;
            var c = _input[Position--];
            var factor = 1;
            while (!char.IsWhiteSpace(c))
            {
                result += factor * (c - Sub);

                if (Position < 0)
                {
                    HasNext = false;
                    break;
                }

                factor *= 10;
                c = _input[Position--];
            }

            return result;
        }

        public int NextBit()
        {
            var bit = _input[Position] - Sub;

            Position += 2;

            if (Position > _length)
            {
                HasNext = false;
            }

            return bit;
        }

        public long NextPositiveLong()
        {
            long result = 0;
            var c = _input[Position++];

            while (!char.IsWhiteSpace(c))
            {
                result = result * 10 + (c - Sub);

                if (Position == _length)
                {
                    HasNext = false;
                    break;
                }

                c = _input[Position++];
            }

            return result;
        }

        public void Reset(int position = 0)
        {
            Position = position;
            HasNext = true;
        }
    }
}