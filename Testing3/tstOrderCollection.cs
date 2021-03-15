using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace tstOrderCollection
{
    [TestClass]
    public class tstOrderCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();

            Assert.IsNotNull(AllOrders);
        }

        [TestMethod]
        public void OrderListOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            List<clsOrder> TestList = new List<clsOrder>();
            clsOrder TestItem = new clsOrder();

            TestItem.Shipment = true;
            TestItem.OrderId = 1;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;

            TestList.Add(TestItem);
            AllOrders.OrderList = TestList;
            Assert.AreEqual(AllOrders.OrderList, TestList);
           
        }



        [TestMethod]
        public void ThisOrderPropertyOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
          
            clsOrder TestOrder = new clsOrder();

            TestOrder.Shipment = true;
            TestOrder.OrderId = 1;
            TestOrder.GameTitle = "game1";
            TestOrder.TotalPrice = 1;
            TestOrder.DeliveryDate = DateTime.Now.Date;

     
            AllOrders.ThisOrder = TestOrder;
            Assert.AreEqual(AllOrders.ThisOrder, TestOrder);

        }

        [TestMethod]
        public void ListAndCountOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            List<clsOrder> TestList = new List<clsOrder>();
            clsOrder TestItem = new clsOrder();

            TestItem.Shipment = true;
            TestItem.OrderId = 1;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;

            TestList.Add(TestItem);
            AllOrders.OrderList = TestList;
            Assert.AreEqual(AllOrders.Count, TestList.Count);

        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrder TestItem = new clsOrder();
            Int32 PrimaryKey = 0;

            TestItem.Shipment = true;
            TestItem.OrderId = 1;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;

            AllOrders.ThisOrder = TestItem;
            PrimaryKey = AllOrders.Add();
            TestItem.OrderId = PrimaryKey;
            AllOrders.ThisOrder.Find(PrimaryKey);

            Assert.AreEqual(AllOrders.ThisOrder, TestItem);
        }

    }
}
