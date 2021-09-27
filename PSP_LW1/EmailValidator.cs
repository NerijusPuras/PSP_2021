using System.Collections.Generic;

namespace PSP_LW1
{
    public class EmailValidator
    {
        List<char> _invalidCharacters;
        List<char> _specialCharacters;

        public EmailValidator(List<char> invalidCharacters, List<char> specialCharacters)
        {
            _invalidCharacters = invalidCharacters;
            _specialCharacters = specialCharacters;
        }
        public bool IsFirstSpecialCharacter(string str)
        {
            return true;
        }

        public bool IsLastSpecialCharacter(string str)
        {
            return true;
        }

        public bool IsHaveTwoOrMoreConsecutiveSpecialChars(string str)
        {
            return true;
        }

        public bool IsValid(string email)
        {
            return true;
        }
    }
}
