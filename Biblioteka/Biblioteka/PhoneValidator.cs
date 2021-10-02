using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka
{
    public class PhoneValidator
    {
        public bool IsPhoneNumberValid(string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber) &&
                PhoneNumberConsistsOfCorrectCharacters(phoneNumber) &&
                PhoneNumberPrefixIsCorrect(phoneNumber) &&
                PhoneNumberLengthIsCorrect(phoneNumber)
                )
            {
                return true;
            }
            return false;
        }
        public string ChangeNumberPrefix(string phoneNumber)
        {
            if (phoneNumber.StartsWith("8"))
            {
                return "+370" + phoneNumber[1..];
            }

            return phoneNumber;
        }
        public ValidationRule AddValidationRule(int length, string prefix)
        {
            ValuesForValidations.PhoneNumberPrefixs.Add(new ValidationRule(length, prefix));
            return ValuesForValidations.PhoneNumberPrefixs[^1];
        }

        private bool PhoneNumberConsistsOfCorrectCharacters(string phoneNumber)
        {
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (Char.IsDigit(phoneNumber[i]) || PhoneNumberHasChar(phoneNumber[i]))
                {
                    continue;
                } else
                {
                    return false;
                }
            }
            return true;
        }

        private bool PhoneNumberHasChar(char phoneNumberChar)
        {
            foreach (var symbol in ValuesForValidations.SpecialSymbolsForPhoneNumbers)
            {
                if (phoneNumberChar == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        private bool PhoneNumberPrefixIsCorrect(string phoneNumber)
        {
            foreach (var prefix in ValuesForValidations.PhoneNumberPrefixs)
            {
                if(phoneNumber.StartsWith(prefix.prefix))
                {
                    return true;
                }
            }
            return false;
        }
        private bool PhoneNumberLengthIsCorrect(string phoneNumber)
        {
            int length = -1;
            foreach (var prefix in ValuesForValidations.PhoneNumberPrefixs)
            {
                if (phoneNumber.Equals(prefix.prefix))
                {
                    length = prefix.length;
                }
            }
            if(length == phoneNumber.Length)
            {
                return true;
            }
            return false;
        }
    }
}
