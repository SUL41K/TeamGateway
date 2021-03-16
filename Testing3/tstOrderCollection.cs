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

        [TestMethod]
        public void UpdateMethodOk()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrder TestItem = new clsOrder();
            Int32 PrimaryKey = 0;

            TestItem.Shipment = true;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;


            AllOrders.ThisOrder = TestItem;
            PrimaryKey = AllOrders.Add();
            TestItem.OrderId = PrimaryKey;

            TestItem.Shipment = false;
            TestItem.GameTitle = "game2";
            TestItem.TotalPrice = 2;
            TestItem.DeliveryDate = DateTime.Now.Date;


            AllOrders.ThisOrder = TestItem;
            AllOrders.Update();
            AllOrders.ThisOrder.Find(PrimaryKey);
            Assert.AreEqual(AllOrders.ThisOrder, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOk()
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
            AllOrders.Delete();

            Boolean Found = AllOrders.ThisOrder.Find(PrimaryKey);
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByGameTitleMethodOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrderCollection FilteredOrders = new clsOrderCollection();
            FilteredOrders.ReportByGameTitle("");
            Assert.AreEqual(AllOrders.Count, FilteredOrders.Count);
        }

        [TestMethod]
        public void ReportByGameTitleNoneFound()
        {
            clsOrderCollection FilteredOrders = new clsOrderCollection();
            FilteredOrders.ReportByGameTitle("Game Title 1");
            Assert.AreEqual(0, FilteredOrders.Count);
        }

        [TestMethod]
        public void ReportByGameTitleTestDataFound()
        {
            clsOrderCollection FilteredOrders = new clsOrderCollection();
            Boolean OK = true;
            FilteredOrders.ReportByGameTitle("Gmod");

            if (FilteredOrders.Count == 2)
            {
                if (FilteredOrders.OrderList[0].OrderId != 10)
                {
                    OK = false;
                }
                if (FilteredOrders.OrderList[1].OrderId != 1064)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

    }
}
