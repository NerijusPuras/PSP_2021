namespace ValidatorLibrary
{
    public class CountryPhoneRules
    {
        public string CountryCode { get; set; }
        public string LongPrefix { get; set; }
        public string ShortPrefix { get; set; }
        public int PhoneLengthWithoutPrefix { get; set; }

        public CountryPhoneRules(string countryCode, string longPrefix, string shortPrefix, int phoneLengthWithoutPrefix)
        {
            CountryCode = countryCode;
            LongPrefix = longPrefix;
            ShortPrefix = shortPrefix;
            PhoneLengthWithoutPrefix = phoneLengthWithoutPrefix;
        }
    }
}
