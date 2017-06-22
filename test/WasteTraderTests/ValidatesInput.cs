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
            var validation = new StringValidation("test")
                .ValidateLength(5, 10);
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestCategory("LengthValidation"), TestMethod]
        public void TooLongLenghtIsInvalid()
        {
            var validation = new StringValidation("testtest")
                .ValidateLength(3, 7);
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestCategory("LengthValidation"), TestMethod]
        public void CorrectLengthIsValid()
        {
            var validation = new StringValidation("test")
                .ValidateLength(3, 5);
            Assert.AreEqual(true, validation.IsValid);
        }

        [TestCategory("OnlyDigitValidation"), TestMethod]
        public void AllDigitsIsValid()
        {
            var validation = new StringValidation("123985")
                .IsOnlyDigits();
            Assert.AreEqual(true, validation.IsValid);
        }

        [TestCategory("NumberValidation"), TestMethod]
        public void LessThanZeroIsInvalid()
        {
            var validation = new NumberValidation(-5)
                .IsMoreThanZero();
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestCategory("NumberValidation"), TestMethod]
        public void ZeroIsInvalid()
        {
            var validation = new NumberValidation(0)
                .IsMoreThanZero();
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestCategory("NumberValidation"), TestMethod]
        public void MoreThanZeroIsValid()
        {
            var validation = new NumberValidation(5)
                .IsMoreThanZero();
            Assert.AreEqual(true, validation.IsValid);
        }
    }
}
