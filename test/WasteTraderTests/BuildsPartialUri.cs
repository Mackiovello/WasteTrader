using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WasteTrader.Api;
using System.Linq;

namespace WasteTraderTests
{
    [TestClass, TestCategory("Partial string building")]
    public class BuildsPartialUri
    {
        public MainHandlers mainHandlers { get; set; }

        [TestInitialize]
        public void CreateMainHandlerInstance()
        {
            mainHandlers = new MainHandlers();
        }

        [TestMethod]
        public void PartialNameNullThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => mainHandlers.BuildPartialUri(null));
        }

        [TestMethod]
        public void PartialNameWithSpaceThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => mainHandlers.BuildPartialUri("this string"));
        }

        [TestMethod]
        public void SimplePartialNameWorks()
        {
            string result = mainHandlers.BuildPartialUri("test");
            Assert.AreEqual("/Waste2Value/partial/test", result);
        }

        [TestMethod]
        public void PassingOneParameterWorks()
        {
            string result = mainHandlers.BuildPartialUri("test", new[] { "name" });
            Assert.AreEqual("/Waste2Value/partial/test/name", result);
        }


        [TestMethod]
        public void PassingTwoParametersWorks()
        {
            string result = mainHandlers.BuildPartialUri("test", new[] { "name", "lastname" });
            Assert.AreEqual("/Waste2Value/partial/test/name/lastname", result);
        }

        [TestMethod]
        public void ParameterWithSpaceThrowsException()
        {
            Action building = () => mainHandlers.BuildPartialUri("test", new[] { "name name" });
            Assert.ThrowsException<ArgumentException>(building);
        }

        [TestMethod]
        public void PassingNullAsParameterThrowsException()
        {
            Action building = () => mainHandlers.BuildPartialUri("test", new[] { "name", null, "lastname" });
            Assert.ThrowsException<ArgumentNullException>(building);
        }
    }
}
