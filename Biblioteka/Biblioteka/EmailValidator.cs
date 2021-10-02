using System.Collections.Generic;

namespace Biblioteka
{
   public class EmailValidator
    {
        
        public bool IsEmailValid(string email)
        {
            if (!string.IsNullOrEmpty(email) &&
                email.Contains("@") &&
                EmailHasMailboxName(email) &&
                !EmailContainsForbiddenSymbols(email) &&
                EmailContainsCorrectDomain(email) &&
                EmailContainsCorrectTLD(email)
                )
            {
                return true;
            }
            return false;
        }

        private bool EmailContainsForbiddenSymbols(string email)
        {
            for (int i = 0; i < ValuesForValidations.ForbiddenSymbols.Count; i++)
            {
                if (email.Contains(ValuesForValidations.ForbiddenSymbols[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool EmailHasMailboxName(string email)
        {
            if (ReturnSubstringFromCharToChar('\0', '@', email).Length > 0)
            {
                return true;
            }
            return false;
        }

        private bool EmailContainsCorrectDomain(string email)
        {
            if(ReturnSubstringFromCharToChar('@', '.', email).Length <= 0)
            {
                return false;
            }

            if(!EmailContainsCorrectDomainName(email))
            {
                return false;
            }
            
            return true;
        }
        private bool EmailContainsCorrectDomainName(string email)
        {
            string domainName = ReturnSubstringFromCharToChar('@', '.', email);
            if (StringArrayHasValue(domainName, ValuesForValidations.ValidDomainNames))
            {
                return true;
            }
            return false;
        }

        private bool EmailContainsCorrectTLD(string email)
        {
            if (ReturnSubstringFromCharToChar('.', '\0', email).Length <= 0)
            {
                return false;
            }

            if(!EmailContainsCorrectTLDName(email))
            {
                return false;
            }
            return true;
        }
        private bool EmailContainsCorrectTLDName(string email)
        {
            string tldName = ReturnSubstringFromCharToChar('.', '\0', email);
            if (StringArrayHasValue(tldName, ValuesForValidations.ValidTLDNames))
            {
                return true;
            }
            return false;
        }

        private string ReturnSubstringFromCharToChar(char from, char to, string email)
        {
            int fromPosition = 0;
            int toPosition = 0;
            // If from == '\0', length has to be found from the beggining of the email
            if (from != '\0')
            {
                for (int i = 0; i < email.Length; i++)
                {
                    fromPosition = i;
                    if (email[i] == from)
                    {
                        fromPosition++;
                        break;
                    }
                }
            }
            if (to != '\0')
            {
                for (int i = fromPosition; i < email.Length; i++)
                {   
                    toPosition = i;
                    if (email[i] == to)
                    {
                        break;
                    }
                }
            } else
            {
                if(email.Length > 0)
                {
                    return email[fromPosition..];
                }
            }
            return email[fromPosition..toPosition];
        }

        private bool StringArrayHasValue(string email, List<string> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if(array[i] == email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
