namespace PSP_LW1
{
    public class PhoneValidator
    {
        readonly int _lenWithoutPrefix;
        readonly string _defaultPrefix;
        readonly string _shortcutPrefix;

        public PhoneValidator(int lenWithoutPrefix, string defaultPrefix, string shortcutPrefix)
        {
            _lenWithoutPrefix = lenWithoutPrefix;
            _defaultPrefix = defaultPrefix;
            _shortcutPrefix = shortcutPrefix;
        }

        public bool IsValid(string phone)
        {
            return true;
        }

        public string ChangeShortcutPrefixToDefault(string phone)
        {
            return "";
        }
    }
}
