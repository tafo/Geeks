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
            _input = input.TrimEnd();
            _length = _input.Length;
            Position = 0;
            HasNext = true;
        }

        internal int NextInt()
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
    }
}