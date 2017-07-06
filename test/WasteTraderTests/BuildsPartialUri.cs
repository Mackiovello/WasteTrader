using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WasteTrader.Helpers;

namespace WasteTraderTests
{
    [TestClass, TestCategory("Partial string building")]
    public class BuildsPartialUri
    {
        [TestMethod]
        public void PartialNameNullThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => UriHelper.BuildPartialUri(null));
        }

        [TestMethod]
        public void PartialNameWithSpaceThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => UriHelper.BuildPartialUri("this string"));
        }

        [TestMethod]
        public void SimplePartialNameWorks()
        {
            string result = UriHelper.BuildPartialUri("test");
            Assert.AreEqual("/Waste2Value/partial/test", result);
        }

        [TestMethod]
        public void PassingOneParameterWorks()
        {
            string result = UriHelper.BuildPartialUri("test", new[] { "name" });
            Assert.AreEqual("/Waste2Value/partial/test/name", result);
        }


        [TestMethod]
        public void PassingTwoParametersWorks()
        {
            string result = UriHelper.BuildPartialUri("test", new[] { "name", "lastname" });
            Assert.AreEqual("/Waste2Value/partial/test/name/lastname", result);
        }

        [TestMethod]
        public void ParameterWithSpaceThrowsException()
        {
            Action building = () => UriHelper.BuildPartialUri("test", new[] { "name name" });
            Assert.ThrowsException<ArgumentException>(building);
        }

        [TestMethod]
        public void PassingNullAsParameterThrowsException()
        {
            Action building = () => UriHelper.BuildPartialUri("test", new[] { "name", null, "lastname" });
            Assert.ThrowsException<ArgumentNullException>(building);
        }
    }
}
