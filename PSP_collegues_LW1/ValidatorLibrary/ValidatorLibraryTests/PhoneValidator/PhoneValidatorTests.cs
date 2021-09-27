using Xunit;

namespace ValidatorLibraryTests.PhoneValidator
{
    public class PhoneValidatorTests
    {
        private PhoneValidator _phoneValidator;

        public PhoneValidatorTests()
        {
            _phoneValidator = new PhoneValidator();
        }

        [Theory]
        [InlineData("864443333")]
        [InlineData("+37064443333")]
        [InlineData("+442222333333")]
        public void PhoneValidator_ReturnsTrue(string number)
        {
            Assert.True(_phoneValidator.Validate(number));
        }

        [Theory]
        [InlineData("864%$333A")]
        [InlineData("+3706!44333B")]
        [InlineData("+44222@33333C")]
        public void PhoneValidator_ReturnsFalse_WhenExtraSymbols(string number)
        {
            Assert.False(_phoneValidator.Validate(number));
        }


        [Theory]
        [InlineData("8644433339")]
        [InlineData("+3706444333399")]
        [InlineData("+442222333333999")]
        public void PhoneValidator_ReturnsFalse_WhenExtraNumbers(string number)
        {
            Assert.False(_phoneValidator.Validate(number));
        }

        [Theory]
        [InlineData("86444333")]
        [InlineData("+3706444333")]
        [InlineData("+44222233333")]
        public void PhoneValidator_ReturnsFalse_WhenMissingNumbers(string number)
        {
            Assert.False(_phoneValidator.Validate(number));
        }

        [Theory]
        [InlineData("!7777777777")]
        [InlineData("-0000000000")]
        [InlineData("66666666666")]
        public void PhoneValidator_ReturnsFalse_WhenUnrecognizedPrefix(string number)
        {
            Assert.False(_phoneValidator.Validate(number));
        }

        [Fact]
        public void PhoneValidator_ReturnsFalse_WhenEmpty()
        {
            Assert.False(_phoneValidator.Validate(""));
        }

    }
}
