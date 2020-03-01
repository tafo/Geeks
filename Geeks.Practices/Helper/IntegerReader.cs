using System;
using System.Threading.Channels;

namespace Geeks.Practices.Helper
{
    /// <summary>
    /// It seems I need to have such a class in order to avoid repetition. 
    /// </summary>
    public class IntegerReader
    {
        private readonly string _input;
        internal int CurrentPosition { get; set; }
        public IntegerReader(string input)
        {
            _input = input.TrimEnd();
            CurrentPosition = -1;
        }

        internal int Next()
        {
            var position = _input.IndexOf(' ', CurrentPosition + 1);
            var buffer = position == -1
                ? _input.Substring(CurrentPosition + 1)
                : _input.Substring(CurrentPosition + 1, position - CurrentPosition);
            CurrentPosition = position;
            return int.Parse(buffer);
        }
    }
}