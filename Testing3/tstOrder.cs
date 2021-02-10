using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing3
{
    [TestClass]
    public class tstOrder
    {
        //good test data
        private string TestString = "Some Test String";
        private int TestInt = 123;
        private Double TestDouble = 1.50;

        [TestMethod]
        public void ClassOrderNotNull()
        {
            clsOrder AnOrder = new clsOrder();
            Assert.IsNotNull(AnOrder);
        }

        [TestMethod]
        public void OrderIdOk()
        {
            clsOrder AnOrder = new clsOrder();
            int TestData = TestInt;
            AnOrder.OrderId = TestData;
            Assert.AreEqual(AnOrder.OrderId, TestData);
        }

        [TestMethod]
        public void GameTitleOk()
        {
            clsOrder AnOrder = new clsOrder();
            string TestData = TestString;
            AnOrder.GameTitle = TestData;
            Assert.AreEqual(AnOrder.GameTitle, TestData);
        }

        [TestMethod]
        public void TotalPriceOk()
        {
            clsOrder AnOrder = new clsOrder();
            Double TestData = TestDouble;
            AnOrder.TotalPrice = TestData;
            Assert.AreEqual(AnOrder.TotalPrice, TestData);
        }

        [TestMethod]
        public void DeliveryDateOk()
        {
            clsOrder AnOrder = new clsOrder();
            DateTime TestData = DateTime.Now.Date;
            AnOrder.DeliveryDate = TestData;
            Assert.AreEqual(AnOrder.DeliveryDate, TestData);
        }

        [TestMethod]
        public void ShipmentOk()
        {
            clsOrder AnOrder = new clsOrder();
            Boolean TestData = true;
            AnOrder.Shipment = TestData;
            Assert.AreEqual(AnOrder.Shipment, TestData);
        }

        [TestMethod]
        public void GameTitleNotNull()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TestData = TestString;
            Error = AnOrder.Valid(TestString);
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
