using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WasteTrader.Helpers;

namespace WasteTraderTests
{
    [TestClass]
    public class ValidatesStringInput
    {
        [TestMethod]
        public void NoValidationIsTrue()
        {
            var validation = new StringValidation("test");
            Assert.AreEqual(true, validation.IsValid);
        }

        [TestMethod]
        public void TooShortLengthIsInvalid()
        {
            var validation = new StringValidation("test")
                .ValidateLength(5, 10);
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestMethod]
        public void TooLongLenghtIsInvalid()
        {
            var validation = new StringValidation("testtest")
                .ValidateLength(3, 7);
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestMethod]
        public void CorrectLengthIsValid()
        {
            var validation = new StringValidation("test")
                .ValidateLength(3, 5);
            Assert.AreEqual(true, validation.IsValid);
        }

        [TestMethod]
        public void AllDigitsIsValid()
        {
            var validation = new StringValidation("123985")
                .IsOnlyDigits();
            Assert.AreEqual(true, validation.IsValid);
        }

        [TestMethod]
        public void ChainedTrueValidationsReturnTrue()
        {
            var validation = new StringValidation("test")
                .OnlyLetters()
                .ValidateLength(3, 5);

            Assert.AreEqual(true, validation.IsValid);
        }

        [TestMethod]
        public void ChainedFalseValidationsReturnFalse()
        {
            var validation = new StringValidation("test")
                .IsOnlyDigits()
                .ValidateLength(6, 9);

            Assert.AreEqual(false, validation.IsValid);
        }

        [TestMethod]
        public void ChainedMixedValidationReturnFalse()
        {
            var validation = new StringValidation("test")
                .OnlyLetters()
                .ValidateLength(6, 9);

            Assert.AreEqual(false, validation.IsValid);
        }
    }
}
