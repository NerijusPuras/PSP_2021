using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;
using System.Collections.Generic;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class MyRegexTests
    {
        readonly MyRegex _myRegex = new MyRegex();
        readonly string _simpleStr = "str";

        [TestMethod]
        public void IsHaveListedCharacters_Has_Correct()
        {
            var str = _simpleStr + "£";
            var listedChars = new List<char>(){
               '£', '¢', '¡'
            };

            var result = _myRegex.IsHaveListedCharacters(str, listedChars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveListedCharacters_DoesntHave_Incorrect()
        {
            var listedChars = new List<char>(){
               '£', '¢', '¡'
            };

            var result = _myRegex.IsHaveListedCharacters(_simpleStr, listedChars);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsOnlyHaveListedCharacters_NotOnly_Incorrect()
        {
            var listedChars = new List<char>(){
               '1', 'a', '.'
            };
            var str = _simpleStr + 'b';

            var result = _myRegex.IsOnlyHaveListedCharacters(str, listedChars);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsOnlyHaveListedCharacters_OnlyListed_Correct()
        {
            var listedChars = new List<char>(){
               '1', 'a', '.'
            };
            var str = "a1";

            var result = _myRegex.IsOnlyHaveListedCharacters(str, listedChars);

            Assert.IsTrue(result);
        }
    }
}
