using System.Collections.Generic;

namespace PSP_LW1
{
    public class PasswordChecker
    {
        private readonly int _minLength;
        private readonly List<char> _allowedSpecialCharacters = new List<char>();

        public PasswordChecker(int minLength, List<char> allowedSpecialCharacters)
        {
            _minLength = minLength;
            _allowedSpecialCharacters = allowedSpecialCharacters;
        }
        public bool IsValid(string str)
        {
            return true;
        }
    }
}
