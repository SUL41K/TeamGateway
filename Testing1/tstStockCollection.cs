using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Testing1
{
    [TestClass]
    public class tstStockCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsStockCollection AllStock = new clsStockCollection();
            //test to see that it exists
            Assert.IsNotNull(AllStock);
        }

        [TestMethod]
        public void StockListOK()
        {
            DateTime RDate;
            Decimal Prc;

            //create an instance of the class we want to create
            clsStockCollection AllStock = new clsStockCollection();
            List<clsStock> TestList = new List<clsStock>();
            
            clsStock TestItem = new clsStock();

            RDate = new DateTime(06 / 10 / 2020);
            Prc = new Decimal (60);

            TestItem.Availability = true;
            TestItem.gameID = 3;
            TestItem.gameName = "FIFA 21";
            TestItem.Price = Prc;
            TestItem.ReleaseDate = RDate;
            TestItem.AgeRating = 3;

            TestList.Add(TestItem);

            AllStock.StockList = TestList;

            Assert.AreEqual(AllStock.StockList, TestList);




        }


        [TestMethod]

        public void ThisStockPropertyOK()
        {
            clsStockCollection AllStock = new clsStockCollection();
            clsStock TestStock = new clsStock();


            TestStock.Availability = true;
            TestStock.gameID = 3;
            TestStock.gameName = "FIFA 21";
            TestStock.Price = 60;
            TestStock.ReleaseDate = new DateTime(06 / 10 / 2020);
            TestStock.AgeRating = 3;

            AllStock.ThisStock = TestStock;
            Assert.AreEqual(AllStock.ThisStock, TestStock);

        }

        [TestMethod]
        public void ListAndCountOK()
        {
            clsStockCollection AllStock = new clsStockCollection();
            List<clsStock> TestList = new List<clsStock>();
            clsStock TestItem = new clsStock();

            TestItem.Availability = true;
            TestItem.gameID = 3;
            TestItem.gameName = "FIFA 21";
            TestItem.Price = 60;
            TestItem.ReleaseDate = new DateTime(06 / 10 / 2020);
            TestItem.AgeRating = 3;

            TestList.Add(TestItem);
            AllStock.StockList = TestList;
            Assert.AreEqual(AllStock.Count, TestList.Count);
        }
    

    }
}
