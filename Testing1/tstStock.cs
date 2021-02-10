using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing1
{
    [TestClass]
    public class tstStock
    {
        private string TestString = "Some Test String";
        private int TestInt = 123;

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //test to see that it exists
            Assert.IsNotNull(AnStock);
        }

        [TestMethod]
        public void GameIdOk()
        {
            clsStock AnStock = new clsStock();
            int TestData = TestInt;
            AnStock.gameID = TestData;
            Assert.AreEqual(AnStock.gameID, TestData);
        }

        [TestMethod]
        public void GameNameOk()
        {
            clsStock AnStock = new clsStock();
            string TestData = TestString;
            AnStock.gameName = TestData;
            Assert.AreEqual(AnStock.gameName, TestData);
        }


        [TestMethod]
        public void AvailabilityOk()
        {
            clsStock AnStock = new clsStock();
            Boolean TestData = true;
            AnStock.Availability = TestData;
            Assert.AreEqual(AnStock.Availability, TestData);
        }

        [TestMethod]
        public void ReleaseDateOk()
        {

            clsStock AnStock = new clsStock();
            DateTime TestData = DateTime.Now.Date;
            AnStock.ReleaseDate = TestData;
            Assert.AreEqual(AnStock.ReleaseDate, TestData);
        }

        [TestMethod]
        public void PriceOk()
        {
            clsStock AnStock = new clsStock();
            int TestData = TestInt;
            AnStock.Price = TestData;
            Assert.AreEqual(AnStock.Price, TestData);
        }

        [TestMethod]

        public void AgeRatingOk()
        {
            clsStock AnStock = new clsStock();
            int TestData = TestInt;
            AnStock.AgeRating = TestData;
            Assert.AreEqual(AnStock.AgeRating, TestData);
        }

        [TestMethod]
        public void GameNameNotNull()
        {
            clsStock AnStock = new clsStock();
            string Error = "";
            string TestData = TestString;
            Error = AnStock.Valid(TestString);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void MinLessOne()
        {
            clsStock AnStock = new clsStock();
            string Error = "";
            string TestData = "";
            Error = AnStock.Valid(TestData);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void MaxPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string TestData = "";
            TestData = TestData.PadLeft(51, '*');
            Error = ACustomer.Valid(TestData);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void FindMethodOK()
        {
            
            clsStock AnStock = new clsStock();
            
            Boolean Found = false;
           
            Int32 gameID = 2;
          
            Found = AnStock.Find(gameID);

            Assert.IsTrue(Found);
        }

        [TestMethod]

        public void TestGameIDFound()
        {

            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);
            if (AnStock.gameID != 3)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]

        public void TestGameNameFound()
        {

            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);
            if (AnStock.gameName != "FIFA 21")
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }


        [TestMethod]

        public void TestReleaseDateFound()
        {
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);

            if (AnStock.ReleaseDate!= Convert.ToDateTime("06/10/2020"))
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPriceFound()
        {
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);

            if (AnStock.Price != 60)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }


        [TestMethod]
        public void TestAvailabilityFound()
        {
            clsStock AnStock= new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);

            if (AnStock.Availability != true)
            {
                OK = false;
            }


            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestAgeRatingFound()
        {
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);

            if (AnStock.AgeRating != 3)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }



















    }
}

