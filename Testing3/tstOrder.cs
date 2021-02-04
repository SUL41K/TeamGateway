using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing3
{
    [TestClass]
    public class tstOrder
    {
        //good test data
        private string gGameTitle = "Some Game Title";

        [TestMethod]
        public void InstanceOk()
        {
            clsOrder AnOrder = new clsOrder();
            Assert.IsNotNull(AnOrder);
        }

        [TestMethod]
        public void GameTitleOk()
        {
            clsOrder AnOrder = new clsOrder();
            string TestData = gGameTitle;
            AnOrder.GameTitle = TestData;
            Assert.AreEqual(AnOrder.GameTitle, TestData);
        }

        [TestMethod]
        public void TotalPriceOk()
        {
            clsOrder AnOrder = new clsOrder();
            string TestData = "15.00";
            AnOrder.TotalPrice = TestData;
            Assert.AreEqual(AnOrder.TotalPrice, TestData);
        }

        [TestMethod]
        public void GamerTitleNotNull()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TestData = gGameTitle;
            Error = AnOrder.Valid(gGameTitle);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void MinLessOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TestData = "";
            Error = AnOrder.Valid(TestData);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void MaxPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TestData = "";
            TestData = TestData.PadLeft(51, '*');
            Error = AnOrder.Valid(TestData);
            Assert.AreNotEqual(Error, "");
        }

    }
}
