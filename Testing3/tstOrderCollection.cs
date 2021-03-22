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
            TestItem.orderID = 1;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;

            TestList.Add(TestItem);
            AllOrders.OrderList = TestList; //check if all atributes match the ID
            Assert.AreEqual(AllOrders.OrderList, TestList);
           
        }



        [TestMethod]
        public void ThisOrderPropertyOK() //check if the attributes are valid
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
          
            clsOrder TestOrder = new clsOrder();

            TestOrder.Shipment = true;
            TestOrder.orderID = 1;
            TestOrder.GameTitle = "game1";
            TestOrder.TotalPrice = 1;
            TestOrder.DeliveryDate = DateTime.Now.Date;

     
            AllOrders.ThisOrder = TestOrder;
            Assert.AreEqual(AllOrders.ThisOrder, TestOrder);

        }

        [TestMethod]
        public void ListAndCountOK() //check if count is working
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            List<clsOrder> TestList = new List<clsOrder>();
            clsOrder TestItem = new clsOrder();

            TestItem.Shipment = true;
            TestItem.orderID = 1;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;

            TestList.Add(TestItem);
            AllOrders.OrderList = TestList;
            Assert.AreEqual(AllOrders.Count, TestList.Count);

        }

        [TestMethod]
        public void AddMethodOk() //check if add works
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrder TestItem = new clsOrder();
            Int32 PrimaryKey = 0;

            TestItem.Shipment = true;
            TestItem.orderID = 1;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;

            AllOrders.ThisOrder = TestItem;
            PrimaryKey = AllOrders.Add();  //add attributes to 1 key
            TestItem.orderID = PrimaryKey;
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
            TestItem.GameTitle = "game1"; //first set of attributes
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;


            AllOrders.ThisOrder = TestItem;
            PrimaryKey = AllOrders.Add();
            TestItem.orderID = PrimaryKey;

            TestItem.Shipment = false;
            TestItem.GameTitle = "game2"; //second set of attributes
            TestItem.TotalPrice = 2;
            TestItem.DeliveryDate = DateTime.Now.Date;


            AllOrders.ThisOrder = TestItem;
            AllOrders.Update(); 
            AllOrders.ThisOrder.Find(PrimaryKey);
            Assert.AreEqual(AllOrders.ThisOrder, TestItem);//check if they are the same
        }

        [TestMethod]
        public void DeleteMethodOk()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrder TestItem = new clsOrder();
            Int32 PrimaryKey = 0;

            TestItem.Shipment = true;
            TestItem.orderID = 1;
            TestItem.GameTitle = "game1";
            TestItem.TotalPrice = 1;
            TestItem.DeliveryDate = DateTime.Now.Date;

            AllOrders.ThisOrder = TestItem;
            PrimaryKey = AllOrders.Add();
            TestItem.orderID = PrimaryKey;
            AllOrders.ThisOrder.Find(PrimaryKey);
            AllOrders.Delete();

            Boolean Found = AllOrders.ThisOrder.Find(PrimaryKey); //check if everything in this ID deleted
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByGameTitleMethodOK() //check if title method works
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrderCollection FilteredOrders = new clsOrderCollection();
            FilteredOrders.ReportByGameTitle("");
            Assert.AreEqual(AllOrders.Count, FilteredOrders.Count);
        }

        [TestMethod]
        public void ReportByGameTitleNoneFound() //check if non existant title is found
        {
            clsOrderCollection FilteredOrders = new clsOrderCollection();
            FilteredOrders.ReportByGameTitle("Game Title 1");
            Assert.AreEqual(0, FilteredOrders.Count);
        }

        [TestMethod]
        public void ReportByGameTitleValid() //check if title is valid
        {
            clsOrderCollection FilteredOrders = new clsOrderCollection();
            FilteredOrders.ReportByGameTitle("Game Title 2");
            Assert.AreEqual(0, FilteredOrders.Count);
        }

        [TestMethod]
        public void ReportByGameTitleTestDataFound() //check if Gmod is found in location 10 and 13
        {
            clsOrderCollection FilteredOrders = new clsOrderCollection();
            Boolean OK = true;
            FilteredOrders.ReportByGameTitle("Gmod");

            if (FilteredOrders.Count == 2) //two instances should be found
            {
                if (FilteredOrders.OrderList[0].orderID != 10)
                {
                    OK = false;
                }
                if (FilteredOrders.OrderList[1].orderID != 13)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            Assert.IsTrue(OK); //assert if two are found
        }

    }
}
