using System.Collections.Generic;
using System.Linq;

namespace ValidatorLibrary
{
    public class PasswordChecker
    {
        readonly List<char> _specialChars = new List<char>(){
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.', '@'
            };

        public int PasswordLength { get; set; } = 5;

        public bool Validate(string password)
        {
            if (password.Length < PasswordLength)
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            foreach (var ch in password.ToCharArray())
            {
                if (_specialChars.Contains(ch))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
