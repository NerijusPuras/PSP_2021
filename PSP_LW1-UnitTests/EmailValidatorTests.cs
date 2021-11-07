using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;
using System.Collections.Generic;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class EmailValidatorTests
    {
        readonly List<char> _specialChars = new List<char>(){
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'
            };
        readonly List<char> _invalidChars = new List<char>(){
                '£', '¢', '¡'
            };
        readonly string _simpleStr = "str";

        readonly EmailValidator _emailValidator;

        public EmailValidatorTests()
        {
            _emailValidator = new EmailValidator(_specialChars, _invalidChars);
        }

        [TestMethod]
        public void IsFirstSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = "%" + _simpleStr;

            var result = _emailValidator.IsFirstSpecialCharacter(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _emailValidator.IsFirstSpecialCharacter(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = _simpleStr + "%";

            var result = _emailValidator.IsLastSpecialCharacter(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _emailValidator.IsLastSpecialCharacter(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveTwoOrMoreConsecutiveSpecialChars_HasTwo_Incorrect()
        {
            var str = _simpleStr + "%*";

            var result = _emailValidator.IsHaveTwoOrMoreConsecutiveSpecialChars(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ValidEmail_Correct()
        {
            var email = "myEmail@gmail.com";

            var result = _emailValidator.IsValid(email);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_NoAtSymbol_Incorrect()
        {
            var email = "myEmailgmail.com";

            var result = _emailValidator.IsValid(email);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_InvalidDomainCharacter_Incorrect()
        {
            var email = "myEmail@gm?ail.com";

            var result = _emailValidator.IsValid(email);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_InvalidTDLCharacter_Incorrect()
        {
            var email = "myEmail@gmail.c?om";

            var result = _emailValidator.IsValid(email);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_NoTDL_Incorrect()
        {
            var email = "myEmail@gmail";

            var result = _emailValidator.IsValid(email);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_NoDomain_Incorrect()
        {
            var email = "myEmail@com";

            var result = _emailValidator.IsValid(email);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_HasInvalidCharacter_Incorrect()
        {
            var email = "myEm¢ail@gmail.com";

            var result = _emailValidator.IsValid(email);

            Assert.IsFalse(result);
        }
    }
}
