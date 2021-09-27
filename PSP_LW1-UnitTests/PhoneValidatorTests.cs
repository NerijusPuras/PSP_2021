using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        readonly PhoneValidator _passwordChecker = new PhoneValidator(8, "+370", "8");
        readonly string _correctPhoneWithoutPrefix = "69675098";

        [TestMethod]
        public void IsValid_ValidWithDefaultPrefix_Incorrect()
        {
            var phone = "+370" + _correctPhoneWithoutPrefix;

            var result = _passwordChecker.IsValid(phone);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsValid_ValidWithShortcutPrefix_Incorrect()
        {
            var phone = "8" + _correctPhoneWithoutPrefix;

            var result = _passwordChecker.IsValid(phone);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_HasLetters_Incorrect()
        {
            var phone = "8685AA695";

            var result = _passwordChecker.IsValid(phone);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_TooShort_Incorrect()
        {
            var phone = "86855695";

            var result = _passwordChecker.IsValid(phone);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChangeShortcutPrefixToDefault_Correct()
        {
            var shortcutPrefixPhone = "8" + _correctPhoneWithoutPrefix;
            var defaultPrefixPhone = "+370" + _correctPhoneWithoutPrefix;

            var result = _passwordChecker.ChangeShortcutPrefixToDefault(shortcutPrefixPhone);

            Assert.IsTrue(defaultPrefixPhone == result);
        }

        [TestMethod]
        public void ChangeShortcutPrefixToDefault_WrongShortcutPrefix_Correct()
        {
            var shortcutPrefixPhone = "7" + _correctPhoneWithoutPrefix;
            var defaultPrefixPhone = "+370" + _correctPhoneWithoutPrefix;

            var result = _passwordChecker.ChangeShortcutPrefixToDefault(shortcutPrefixPhone);

            Assert.IsFalse(defaultPrefixPhone == result);
        }
    }
}
