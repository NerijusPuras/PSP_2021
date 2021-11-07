using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;
using System.Collections.Generic;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class PasswordValidatorTests
    {
        readonly PasswordChecker _passwordChecker = new PasswordChecker(6,
            new List<char>() {
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'
            });

        readonly string _tenLowercaseCharacter = "mypassword";

        [TestMethod]
        public void IsValid_Password_Correct()
        {
            var password = _tenLowercaseCharacter + "." + "L";

            var result = _passwordChecker.IsValid(password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_OneCharTooShort_Incorrect()
        {
            var password = "Pass.";

            var result = _passwordChecker.IsValid(password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_ExactRightLength_Correct()
        {
            var password = "Passw.";

            var result = _passwordChecker.IsValid(password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_NoUpperCase_Incorrect()
        {
            var password = _tenLowercaseCharacter + ".";

            var result = _passwordChecker.IsValid(password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_NoSpecialCharacter_Incorrect()
        {
            var password = _tenLowercaseCharacter + "L";

            var result = _passwordChecker.IsValid(password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WithSpecialCharacterThatIsntAllowed_Incorrect()
        {
            var password = _tenLowercaseCharacter + "(" + "L";

            var result = _passwordChecker.IsValid(password);

            Assert.IsFalse(result);
        }
    }
}
