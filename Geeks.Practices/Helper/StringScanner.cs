namespace Geeks.Practices.Helper
{
    public class StringScanner
    {
        private readonly string _input;
        private readonly int _length;
        internal int Position { get; set; }
        private const char Sub = '0';
        internal bool HasNext { get; set; }

        public StringScanner(string input)
        {
            _input = input;
            _length = _input.Length;
            Reset();
        }

        internal int NextInt()
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

        internal int NextPositiveInt()
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

        internal long NextInt64()
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

        internal void Reset()
        {
            Position = 0;
            HasNext = true;
        }
    }
}