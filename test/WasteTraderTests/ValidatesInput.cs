using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WasteTrader.Helpers;

namespace WasteTraderTests
{
    [TestClass]
    public class ValidatesInput
    {
        [TestCategory("LengthValidation"), TestMethod]
        public void TooShortLengthIsInvalid()
        {
            var validation = new InputValidation("test");
            validation.ValidateLength(5, 10);
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestCategory("LengthValidation"), TestMethod]
        public void TooLongLenghtIsInvalid()
        {
            var validation = new InputValidation("testtest");
            validation.ValidateLength(3, 7);
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestCategory("LengthValidation"), TestMethod]
        public void CorrectLengthIsValid()
        {
            var validation = new InputValidation("test");
            validation.ValidateLength(3, 5);
            Assert.AreEqual(true, validation.IsValid);
        }

        [TestCategory("OnlyDigitValidation"), TestMethod]
        public void AllDigitsIsValid()
        {
            var validation = new InputValidation("123985");
            validation.IsOnlyDigits();
            Assert.AreEqual(true, validation.IsValid);
        }
    }
}
