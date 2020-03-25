using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Geeks.Practices.Helper
{
    /// <summary>
    /// int.MaxValue = 0x7fffffff >> 2,147,483,647
    /// </summary>
    [SuppressMessage("ReSharper", "CommentTypo")]
    public class StringScanner
    {
        private string _input;
        private int _length;
        private const char Sub = '0';

        public int Position { get; set; }
        public bool HasNext { get; set; }

        public StringScanner(string input, bool isReverse = false)
        {
            if (isReverse)
            {
                Reset(_length - 1, input);
            }
            else
            {
                Reset(0, input);
            }
        }

        public static int SumPositiveInt(string input)
        {
            var result = 0;
            var number = 0;

            foreach (var c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    result += number;
                    number = 0;
                    continue;
                }

                number = number * 10 + (c - Sub);
            }

            result += number;

            return result;
        }

        public static int MaxInt(string input)
        {
            var max = int.MinValue;
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
                    max = Math.Max(max, number * (isNegative ? -1 : 1));
                    number = 0;
                    isNegative = false;
                }
                else
                {
                    number = number * 10 + (c - Sub);
                }
            }

            return Math.Max(max, number * (isNegative ? -1 : 1));
        }

        public static int MaxPositiveInt(string input)
        {
            var max = int.MinValue;
            var number = 0;
            foreach (var c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    max = Math.Max(max, number);
                    number = 0;
                }
                else
                {
                    number = number * 10 + (c - Sub);
                }
            }

            return Math.Max(max, number);
        }

        public static int MinInt(string input)
        {
            var min = int.MaxValue;
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
                    min = Math.Min(min, number * (isNegative ? -1 : 1));
                    number = 0;
                    isNegative = false;
                }
                else
                {
                    number = number * 10 + (c - Sub);
                }
            }

            return Math.Min(min, number * (isNegative ? -1 : 1));
        }

        public static long[] GetPositiveLong(string input, int n)
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

            result[i] = number * (isNegative ? -1 : 1);

            return result;
        }

        public static long[] GetLong(string input, int n)
        {
            var result = new long[n];
            var i = 0;
            long number = 0;
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

            result[i] = number * (isNegative ? -1 : 1);

            return result;
        }

        public static int[] GetDigit(string input, int n)
        {
            var result = new int[n];
            var i = 0;
            var digit = 0;

            foreach (var c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    result[i++] = digit;
                }
                else
                {
                    digit = c - Sub;
                }
            }

            result[i] = digit;

            return result;
        }

        public static char[] GetChar(string input, int n)
        {
            var result = new char[n];
            var i = 0;

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var c in input)
            {
                if (!char.IsWhiteSpace(c))
                {
                    result[i++] = c;
                }
            }

            return result;
        }

        public static string[] GetString(string input, int n)
        {
            var result = new string[n];
            var i = 0;
            var element = string.Empty;

            foreach (var c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    result[i++] = element;
                    element = string.Empty;
                    continue;
                }

                element += c;
            }

            result[i] = element;

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

        public long NextLong()
        {
            long result = 0;
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

        public int NextDigit()
        {
            var digit = _input[Position] - Sub;

            Position += 2;

            if (Position > _length)
            {
                HasNext = false;
            }

            return digit;
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

        public string NextString()
        {
            var stringBuilder = new StringBuilder();
            var c = _input[Position++];
            while (!char.IsWhiteSpace(c))
            {
                stringBuilder.Append(c);

                if (Position == _length)
                {
                    HasNext = false;
                    break;
                }

                c = _input[Position++];
            }

            return stringBuilder.ToString();
        }

        public void Reset(int position = 0, string input = null)
        {
            Position = position;
            if (input != null)
            {
                _input = input;
                _length = input.Length;
            }

            HasNext = true;
        }
    }
}