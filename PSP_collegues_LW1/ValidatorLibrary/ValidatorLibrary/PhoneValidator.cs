using System;
using System.Collections.Generic;

namespace ValidatorLibrary
{
    public class PhoneValidator
    {
        private readonly List<CountryPhoneRules> _allCountriesPhoneRules = new List<CountryPhoneRules>()
        {
            new CountryPhoneRules("LTU", "+370", "8", 8),
            new CountryPhoneRules("WTF", "+44", "7", 10)
        };

        public bool Validate(string phone)
        {
            var rules = ChooseRules(phone);
            if (rules == null)
            {
                return false;
            }

            if (!IsValidLength(phone, rules)
                || ContainsInvalidSymbols(phone))
            {
                return false;
            }
            return true;
        }

        public string ChangeShortcutPrefixToDefault(string phone)
        {
            var rules = ChooseRules(phone);
            if (rules == null)
            {
                return null;
            }

            if (!Validate(phone)
                || phone[0].Equals(rules.ShortPrefix))
            {
                return null;
            }

            var (_, number) = SeperatePrefix(phone);
            return String.Concat(rules.LongPrefix, number);
        }

        private CountryPhoneRules ChooseRules(string phone)
        {
            foreach (var country in _allCountriesPhoneRules)
            {
                if (0 == phone.IndexOf(country.ShortPrefix)
                    || 0 == phone.IndexOf(country.LongPrefix))
                {
                    return country;
                }
            }
            return null;
        }

        private (string, string) SeperatePrefix(string phone)
        {
            if ('+' == phone[0])
            {
                return (phone.Substring(0, 4), phone[4..]);
            }

            return (phone.Substring(0, 1), phone[1..]);
        }

        private bool IsValidLength(string phone, CountryPhoneRules rules)
        {
            if (rules.LongPrefix.Length + rules.PhoneLengthWithoutPrefix == phone.Length
                || rules.ShortPrefix.Length + rules.PhoneLengthWithoutPrefix == phone.Length)
            {
                return true;
            }

            return false;
        }

        private bool ContainsInvalidSymbols(string str)
        {
            foreach (var ch in str.ToCharArray())
            {
                if (!char.IsDigit(ch))
                {
                    if (!ch.Equals('+'))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
