using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WasteTrader.MathUtils;

namespace WasteTraderTests
{
    [TestCategory("Math"), TestClass]
    public class CalculatesDistance
    {
        [TestMethod]
        public void ConvertsDegreesToRadians()
        {
            double result = GeographyMath.DegreesToRadians(30);

            Assert.IsTrue(result > 0.523598);
            Assert.IsTrue(result < 0.523600);
        }

        [TestMethod]
        public void ConvertingLargeDegreesWork()
        {
            double result = GeographyMath.DegreesToRadians(2500);

            Assert.IsTrue(result > 43.63322);
            Assert.IsTrue(result < 43.63324);
        }

        [TestMethod]
        public void ConvertingNegativeDegreesWork()
        {
            double result = GeographyMath.DegreesToRadians(-122);

            Assert.IsTrue(result < -2.1292);
            Assert.IsTrue(result > -2.1294);
        }
    }
}
