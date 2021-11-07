using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka
{
    public class PasswordChecker
    {
        public bool IsPasswordValid(string password)
        {
            if (!string.IsNullOrEmpty(password) &&
                PasswordIsCorrectLength(password, 8) &&
                PasswordHasUpperSymbol(password) &&
                PasswordHasSpecialSymbol(password)
                )
            {
                return true;
            }
            return false;
        }

        private bool PasswordIsCorrectLength(string password, int length)
        {
            if(password.Length < length)
            {
                return false;
            }
            return true;
        }

        private bool PasswordHasUpperSymbol(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool PasswordHasSpecialSymbol(string password)
        {
            for (int i = 0; i < ValuesForValidations.SpecialSymbols.Count; i++)
            {
                if (password.Contains(ValuesForValidations.SpecialSymbols[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
