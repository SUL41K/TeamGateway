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

            TestItem.Active = true;
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

            TestOrder.Active = true;
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

            TestItem.Active = true;
            TestItem.OrderId = 1;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;

            TestList.Add(TestItem);
            AllOrders.OrderList = TestList;
            Assert.AreEqual(AllOrders.Count, TestList.Count);

        }



    }
}
