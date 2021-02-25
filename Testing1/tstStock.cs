using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing1
{
    [TestClass]
    public class tstStock
    {

        //good test data
        private string TestString = "Some Test String";
        private int TestInt = 123;
        private decimal TestDec = 456;
        string gameID = "3";
        string gameName = "FIFA 21";
        string Price = "60";
        string AgeRating = "3";
        string ReleaseDate = DateTime.Now.Date.ToString();


        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //test to see that it exists
            Assert.IsNotNull(AnStock);
        }

        [TestMethod]

        public void ValidMethodOK()
        {
            clsStock AnStock = new clsStock();

            String Error = "";

            Error = AnStock.Valid(gameID,gameName,Price,AgeRating,ReleaseDate);

            Assert.AreEqual(Error, "");

        }

       

        [TestMethod]
        public void GameNameMinLessOne()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            string gameName = "";
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            Assert.AreNotEqual(Error, "");
        }

        public void GameNameMin()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string gameName = "a"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void gameNameMinPlusOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string gameName = "aa"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void GameNameMaxLessOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string gameName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void GameNameMax()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string gameName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void GameNameMid()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string gameName = "aaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void GameNameMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string gameName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; //this should fail
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void gameNameExtremeMax()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            string gameName = "";
            gameName = gameName.PadRight(500, 'a');//should fail
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
        
        [TestMethod]
        public void ReleaseDateExtremeMin()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddYears(-100);
            string ReleaseDate = TestDate.ToString();
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void ReleaseDateMinLessOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //change the date to whatever the date is less 1 day
            TestDate = TestDate.AddDays(-1);
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ReleaseDateMin()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void ReleaseDateMinPlusOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //change the date to whatever the date is plus 1 day
            TestDate = TestDate.AddDays(1);
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ReleaseDateExtremeMax()
        {
            //create an instance of the class we want to create
            clsStock AnStock= new clsStock();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //change the date to whatever the date is plus 100 years
            TestDate = TestDate.AddYears(100);
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
        
        [TestMethod]
        public void ReleaseDateInvalidData()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            string gameID = "3";
            string gameName = "FIFA 21";
            string Price = "60";
            string AgeRating = "3";
            string ReleaseDate = "This is not a date!";
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            Assert.AreNotEqual(Error, "");

        }






        [TestMethod]
        public void PriceEmpty()
        {
            clsStock AnStock= new clsStock();
            String Error = "";
            string Price = "";
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void PriceMin()
        {
            
            clsStock AnStock = new clsStock();
           
            String Error = "";
            
            string Price = "1"; 
          
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PriceMinPlusOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string Price = "2"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PriceMax()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string Price = "100"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PriceMaxLessOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string Price = "99"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }




        [TestMethod]
        public void PriceMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string Price = "101"; //this should fail
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void PriceExtremeMax()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            string Price = "";
            Price = Price.PadRight(1000, '1');//should fail
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void PriceInvalidData()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            string gameID = "3";
            string gameName = "FIFA 21";
            string Price = "This is not a Valid figure";
            string AgeRating = "This is not a valid number";
            string ReleaseDate = "This is not a date!";
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            Assert.AreNotEqual(Error, "");

        }



        [TestMethod]
        public void AgeRatingMinLessOne()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            string AgeRating = "0";
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void AgeRatingMin()
        {

            clsStock AnStock = new clsStock();

            String Error = "";

            String AgeRating = "1";

            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);

            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void AgeRatingMinPlusOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string Price = "2"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }


        [TestMethod]
        public void AgeRatingMax()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string AgeRating = "18"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }


        [TestMethod]
        public void AgeRatingMaxLessOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string AgeRating = "17"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

       


        [TestMethod]
        public void AgeRatingMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string AgeRating = "19"; //this should fail
            //invoke the method
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void AgeRatingExtremeMax()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            string AgeRating = "";
            AgeRating = AgeRating.PadRight(100, '1');//should fail
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }



        [TestMethod]
        public void AgeRatingInvalidData()
        {
            clsStock AnStock = new clsStock();
            String Error = "";
            string gameID = "3";
            string gameName = "FIFA 21";
            string Price = "60";
            string AgeRating = "This is not a valid number";
            string ReleaseDate = "This is not a date!";
            Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
            Assert.AreNotEqual(Error, "");

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
            decimal TestData = TestDec;
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
            clsStock AnStock = new clsStock();
            string Error = "";
            string TestData = "";
            TestData = TestData.PadLeft(51, '*');
            Error = AnStock.Valid(TestData);
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

            if (AnStock.Price != Convert.ToDecimal(60))
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

