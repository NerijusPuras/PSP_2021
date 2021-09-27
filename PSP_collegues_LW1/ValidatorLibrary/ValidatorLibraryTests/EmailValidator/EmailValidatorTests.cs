using Xunit;

namespace ValidatorLibraryTests.EmailValidator
{
    public class EmailValidatorTests
    {
        private EmailValidator _emailValidator;

        public EmailValidatorTests()
        {
            _emailValidator = new EmailValidator();
        }

        [Theory]
        [InlineData("testEmail@gmail.com")]
        [InlineData("testEmail@yahoo.com")]
        [InlineData("te3st2Email@mail.ru")]
        public void EmailValidator_Success(string email)
        {
            Assert.True(_emailValidator.Validate(email));
        }

        [Theory]
        [InlineData("testEmail@notgood.com")]
        [InlineData("testEmail@illegal.org")]
        public void EmailValidator_ReturnsFalse_WhenDomainIsNotValid(string email)
        {
            Assert.False(_emailValidator.Validate(email));
        }

        [Theory]
        [InlineData("testEmail@gmail.a")]
        [InlineData("testEmail@gmail.zzz")]
        public void EmailValidator_ReturnsFalse_WhenTLDIsNotValid(string email)
        {
            Assert.False(_emailValidator.Validate(email));
        }

        [Theory]
        [InlineData("testEmail$@gmail.com")]
        [InlineData("tes%@gmail.com")]
        [InlineData("test!@gmail.com")]
        [InlineData("te|mail$@gmail.com")]
        public void EmailValidator_ReturnsFalse_WhenIllegalSymbols(string email)
        {
            Assert.False(_emailValidator.Validate(email));
        }

        [Fact]
        public void EmailValidator_ReturnsFalse_WhenEmpty()
        {
            Assert.False(_emailValidator.Validate(""));
        }
    }
}
