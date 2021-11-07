using System.Collections.Generic;

namespace PSP_LW1
{
    public class MyRegex
    {
        string _allowedSpecialSymbols = System.Configuration.ConfigurationManager.AppSettings["AllowedSpecialSymbols"];

        public bool IsHaveListedCharacters(string str, List<char> listedCharacters)
        {
            return true;
        }

        public bool IsOnlyHaveListedCharacters(string str, List<char> listedCharacters)
        {
            return true;
        }
    }
}
