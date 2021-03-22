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

            //create an instance of the class we want to create
            clsStockCollection AllStock = new clsStockCollection();
            List<clsStock> TestList = new List<clsStock>();

            clsStock TestItem = new clsStock();

            //Creating test data for each attribute
            TestItem.Availability = true;
            TestItem.gameID = 3;
            TestItem.gameName = "FIFA 21";
            TestItem.Price = 60;
            TestItem.ReleaseDate = new DateTime(06 / 10 / 2020);
            TestItem.AgeRating = 3;

            TestList.Add(TestItem);

            AllStock.StockList = TestList;

            //test to see if it passes
            Assert.AreEqual(AllStock.StockList, TestList);

        }

        [TestMethod]

        public void ThisStockPropertyOK()
        {
            //create an instance of the class we want to create
            clsStockCollection AllStock = new clsStockCollection();
            clsStock TestStock = new clsStock();

            //Creating test data for each attribute
            TestStock.Availability = true;
            TestStock.gameID = 3;
            TestStock.gameName = "FIFA 21";
            TestStock.Price = 60;
            TestStock.ReleaseDate = new DateTime(06 / 10 / 2020);
            TestStock.AgeRating = 3;

            AllStock.ThisStock = TestStock;
            //test to see if it passes
            Assert.AreEqual(AllStock.ThisStock, TestStock);

        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //create an instance of the class we want to create
            clsStockCollection AllStock = new clsStockCollection();
            List<clsStock> TestList = new List<clsStock>();
            clsStock TestItem = new clsStock();

            //Creating test data for each attribute
            TestItem.Availability = true;
            TestItem.gameID = 3;
            TestItem.gameName = "FIFA 21";
            TestItem.Price = 60;
            TestItem.ReleaseDate = new DateTime(06 / 10 / 2020);
            TestItem.AgeRating = 3;

            
            TestList.Add(TestItem);
            AllStock.StockList = TestList;
            //test to see if it passes
            Assert.AreEqual(AllStock.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the class we want to create
            clsStockCollection AllStocks = new clsStockCollection();
            clsStock TestItem = new clsStock();
            Int32 PrimaryKey = 0;

            //Creating test data for each attribute
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

            //test to see if it passes
            Assert.AreEqual(AllStocks.ThisStock, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOkay()
        {
            //create an instance of the class we want to create
            clsStockCollection AllStocks = new clsStockCollection();
            clsStock TestItem = new clsStock();
            Int32 PrimaryKey = 0;

            //Creating test data for each attribute
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
            //test to see if it passes
            Assert.AreEqual(AllStocks.ThisStock, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create an instance of the class we want to create
            clsStockCollection AllStocks = new clsStockCollection();
            clsStock TestItem = new clsStock();
            Int32 PrimaryKey = 0;

            //Creating test data for each attribute
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
            //test to see if it passes
            Assert.IsFalse(Found);

        }

        [TestMethod]

        public void ReportByGameNameOK()
        {
            //create an instance of the class we want to create
            clsStockCollection AllStocks = new clsStockCollection();
            clsStockCollection FilteredStock = new clsStockCollection();
            FilteredStock.ReportBygameName("");
            //test to see if it passes
            Assert.AreEqual(AllStocks.Count, FilteredStock.Count);

        }

        [TestMethod]

        public void ReportByGameNameNoneFound()
        {
            //create an instance of the class we want to create
            clsStockCollection FilteredStocks = new clsStockCollection();
            FilteredStocks.ReportBygameName("XXXXX XXXXX");
            //test to see if it passes
            Assert.AreEqual(0, FilteredStocks.Count);
        }

        [TestMethod]

        public void ReportByGameNameTestDataFound()
        {
            //create an instance of the class we want to create
            clsStockCollection FilteredStocks = new clsStockCollection();
            Boolean OK = true;
            FilteredStocks.ReportBygameName("XXXXXXXXXX XXXXXXXXXX");
            //Test to find 2 of the same data within the DB
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

            //test to see if it passes
            Assert.IsTrue(OK);
        } 
    





    }
}
