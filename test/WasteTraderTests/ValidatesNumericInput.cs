using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WasteTrader.Helpers;

namespace WasteTraderTests
{
    [TestClass]
    public class ValidatesNumericInput
    {
        [TestMethod]
        public void LessThanZeroIsInvalid()
        {
            var validation = new NumberValidation(-5)
                .IsMoreThanZero();
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestMethod]
        public void ZeroIsInvalid()
        {
            var validation = new NumberValidation(0)
                .IsMoreThanZero();
            Assert.AreEqual(false, validation.IsValid);
        }

        [TestMethod]
        public void MoreThanZeroIsValid()
        {
            var validation = new NumberValidation(5)
                .IsMoreThanZero();
            Assert.AreEqual(true, validation.IsValid);
        }

    }
}
