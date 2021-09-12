using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSPLibrary.Tests
{
    [TestClass]
    class EmailValidatorTests
    {
        [TestMethod]
		public void ValidateEmail_ValidEmail_ReturnsTrue()
		{
			//Arrange
			string email = "example@mail.com";

			//Act
			var result = PasswordValidator.ValidateEmail(correctEmail);

			//Assert
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void ValidateEmail_HasNoEta_ReturnsFalse()
		{
			//Arrange
			string email = "examplemail.com";

			//Act
			var result = PasswordValidator.ValidateEmail(email);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void ValidateEmail_HasInvalidCharacter_ReturnsFalse()
		{
			//Arrange
			string email = "exampl@e@mail.com";

			//Act
			var result = PasswordValidator.ValidateEmail(email);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void ValidateEmail_HasNoTLD_ReturnsFalse()
		{
			//Arrange
			string email = "example@mail";

			//Act
			var result = PasswordValidator.ValidateEmail(email);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void ValidateEmail_HasIncorrectDomain_ReturnsFalse()
		{
			//Arrange
			string email = "example@.ru";

			//Act
			var result = PasswordValidator.ValidateEmail(email);

			//Assert
			Assert.AreEqual(false, result);
		}
	}
}
