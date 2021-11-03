using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidatorLibrary
{
    public class EmailValidator
    {
        readonly List<char> _specialChars = new List<char>(){
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'
            };
        readonly List<char> _invalidChars = new List<char>(){
                '£', '¢', '¡'
            };
        readonly List<string> _approvedDomainList = new List<string>() {
                "gmail", "mail", "yahoo", "hotmail"
        };
        readonly List<string> _approvedTLDList = new List<string>() {
                "com", "org", "ru", "lt"
        };

        public bool Validate(string email)
        {
            var atSymbolIndex = email.LastIndexOf('@');
            var dotSymbolIndex = email.LastIndexOf('.');
            if (-1 == atSymbolIndex || -1 == dotSymbolIndex)
            {
                return false;
            }

            var username = email.Substring(0, atSymbolIndex);
            var domain = email.Substring(atSymbolIndex + 1, dotSymbolIndex - atSymbolIndex - 1);
            var tld = email[(dotSymbolIndex + 1)..];

            if (!IsValidUsername(username))
            {
                return false;
            }
            if (!IsInApprovedDomainList(domain))
            {
                return false;
            }
            if (!IsInApprovedTLDList(tld))
            {
                return false;
            }

            //if (!IsValidDomain(domain))
            //{
            //    return false;
            //}
            //if (!IsValidTld(tld))
            //{
            //    return false;
            //}

            return true;
        }

        private bool IsValidUsername(string username)
        {
            var invalid = _specialChars.Contains(username[0]);
            invalid = _specialChars.Contains(username[^1]) || invalid;
            invalid = IsHaveTwoOrMoreConsecutiveSpecialChars(username) || invalid;
            invalid = IsContainsInvalidChar(username) || invalid;

            return !invalid;
        }

        private bool IsValidDomain(string domain)
        {
            foreach (var ch in domain.ToCharArray())
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    if (!ch.Equals('-'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsInApprovedDomainList(string domain)
        {
            return _approvedDomainList.Contains(domain);
        }

        private bool IsInApprovedTLDList(string tld)
        {
            return _approvedTLDList.Contains(tld);
        }

        private bool IsValidTld(string tld)
        {
            return tld.ToCharArray().All(ch => Char.IsLetter(ch));
        }

        private bool IsHaveTwoOrMoreConsecutiveSpecialChars(string email)
        {
            for (int i = 0; i < email.Length; i++)
            {
                if (_specialChars.Contains(email[i]))
                {
                    if (i + 1 == email.Length)
                    {
                        return false;
                    }
                    if (_specialChars.Contains(email[i + 1]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsContainsInvalidChar(string str)
        {
            foreach (var ch in str.ToCharArray())
            {
                if (_invalidChars.Contains(ch))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
