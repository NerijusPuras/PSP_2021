using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka
{
    public class ValuesForValidations
    {
        private static List<char> forbiddenSymbols = new List<char>();
        private static List<string> validDomainNames = new List<string>();
        private static List<string> validTLDNames = new List<string>();
        private static List<char> specialSymbols = new List<char>();
        private static List<ValidationRule> phoneNumberPrefixs = new List<ValidationRule>();
        private static List<char> specialSymbolsForPhoneNumbers = new List<char>();

        public ValuesForValidations()
        {
            forbiddenSymbols.Add(';');
            forbiddenSymbols.Add('%');

            validDomainNames.Add("gmail");
            validDomainNames.Add("pastas");

            validTLDNames.Add("com");
            validTLDNames.Add("net");
            validTLDNames.Add("lt");
            validTLDNames.Add("ru");

            SpecialSymbols.Add('.');
            SpecialSymbols.Add('!');
            SpecialSymbols.Add('@');
            SpecialSymbols.Add('#');
            SpecialSymbols.Add('$');

            phoneNumberPrefixs.Add(new ValidationRule(12, "+370"));
            phoneNumberPrefixs.Add(new ValidationRule(12, "+371"));
            phoneNumberPrefixs.Add(new ValidationRule(11, "+44"));

            specialSymbolsForPhoneNumbers.Add('+');
        }

        public static List<char> ForbiddenSymbols { get => forbiddenSymbols; set => forbiddenSymbols = value; }
        public static List<string> ValidDomainNames { get => validDomainNames; set => validDomainNames = value; }
        public static List<string> ValidTLDNames { get => validTLDNames; set => validTLDNames = value; }
        public static List<char> SpecialSymbols { get => specialSymbols; set => specialSymbols = value; }
        public static List<ValidationRule> PhoneNumberPrefixs { get => phoneNumberPrefixs; set => phoneNumberPrefixs = value; }
        public static List<char> SpecialSymbolsForPhoneNumbers { get => specialSymbolsForPhoneNumbers; set => specialSymbolsForPhoneNumbers = value; }
    }
}
