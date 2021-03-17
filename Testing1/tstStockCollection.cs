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
            Prc = new Decimal(60);

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

        [TestMethod]
        public void AddMethodOK()
        {
            clsStockCollection AllStocks = new clsStockCollection();
            clsStock TestItem = new clsStock();
            Int32 PrimaryKey = 0;
            TestItem.Availability = true;
            TestItem.gameID = 1;
            TestItem.gameName = "Some Game";
            TestItem.Price = 10;
            TestItem.ReleaseDate = DateTime.Now.Date;
            TestItem.AgeRating = 1;
            AllStocks.ThisStock = TestItem;
            PrimaryKey = AllStocks.Add();
            TestItem.gameID = PrimaryKey;
            AllStocks.ThisStock.Find(PrimaryKey);
            Assert.AreEqual(AllStocks.ThisStock, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOkay()
        {
            clsStockCollection AllStocks = new clsStockCollection();
            clsStock TestItem = new clsStock();
            Int32 PrimaryKey = 0;
            TestItem.Availability = true;
            TestItem.gameName = "Some Game";
            TestItem.Price = 10;
            TestItem.ReleaseDate = DateTime.Now.Date;
            TestItem.AgeRating = 1;
            AllStocks.ThisStock = TestItem;
            PrimaryKey = AllStocks.Add();
            TestItem.gameID = PrimaryKey;
            TestItem.Availability = false;
            TestItem.gameName = "Another Game";
            TestItem.Price = 20;
            TestItem.ReleaseDate = DateTime.Now.Date;
            TestItem.AgeRating = 2;
            AllStocks.ThisStock = TestItem;
            AllStocks.Update();
            AllStocks.ThisStock.Find(PrimaryKey);
            Assert.AreEqual(AllStocks.ThisStock, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            clsStockCollection AllStocks = new clsStockCollection();
            clsStock TestItem = new clsStock();
            Int32 PrimaryKey = 0;
            TestItem.Availability = true;
            TestItem.gameName = "Some Game";
            TestItem.Price = 10;
            TestItem.ReleaseDate = DateTime.Now.Date;
            TestItem.AgeRating = 1;
            AllStocks.ThisStock = TestItem;
            PrimaryKey = AllStocks.Add();
            TestItem.gameID = PrimaryKey;
            AllStocks.Delete();
            Boolean Found = AllStocks.ThisStock.Find(PrimaryKey);
            Assert.IsFalse(Found);

        }

        [TestMethod]

        public void ReportByGameNameOK()
        {
            clsStockCollection AllStocks = new clsStockCollection();
            clsStockCollection FilteredStock = new clsStockCollection();
            FilteredStock.ReportBygameName("");
            Assert.AreEqual(AllStocks.Count, FilteredStock.Count);

        }

        [TestMethod]

        public void ReportByGameNameNoneFound()
        {
            clsStockCollection FilteredStocks = new clsStockCollection();
            FilteredStocks.ReportBygameName("XXXXX XXXXX");
            Assert.AreEqual(0, FilteredStocks.Count);
        }

        [TestMethod]

        public void ReportByGameNameTestDataFound()
        {
            clsStockCollection FilteredStocks = new clsStockCollection();
            Boolean OK = true;
            FilteredStocks.ReportBygameName("XXXXXXXXXX XXXXXXXXXX");

            if (FilteredStocks.Count == 2)
            {
                if (FilteredStocks.StockList[0].gameID != 36)
                {
                    OK = false;
                }
                
                if (FilteredStocks.StockList[1].gameID != 37)
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
