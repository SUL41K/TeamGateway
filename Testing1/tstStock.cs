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
        string gameName = "FIFA 21";
        string Price = "60";
        string AgeRating = "3";
        string ReleaseDate = new DateTime (2001,01,01).ToString();


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
            //Creates an instance of clsStock
            clsStock AnStock = new clsStock();
            //Creates test data for the use of an error message
            String Error = "";
            //Invokes the method
            Error = AnStock.Valid(gameName,Price,AgeRating,ReleaseDate);
            //Ensures correct result is found
            Assert.AreEqual(Error, "");

        }

       

        [TestMethod]
        public void GameNameMinLessOne()
        {
            //Create an instance of clsStock
            clsStock AnStock = new clsStock();
            //String varible to create an Error message
            String Error = "";
            //Creating some test data
            string gameName = "";//This should pass
            //Invokes the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //Test to see if result is correct
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void gameNameExtremeMax()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string gameName = "";
            //invoke the method
            gameName = gameName.PadRight(500, 'a');//should fail
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
        
        [TestMethod]
        public void ReleaseDateExtremeMin()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            DateTime TestDate;
            TestDate = new DateTime(2001,01,01);
            //Removes 100 years from the minimum
            TestDate = TestDate.AddYears(-100);
            //Converts into a toString
            string ReleaseDate = TestDate.ToString();
            //invokes the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);//This should fail
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
            TestDate = new DateTime(2001,01,01);
            //change the date to whatever the date is less 1 day
            TestDate = TestDate.AddDays(-1);
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);//This should fail
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
            TestDate = new DateTime(2001,01,01);
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);//This should pass
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
            //set the date to (2001,01,01)
            TestDate =  new DateTime(2001,01,01);
            //change the date to whatever the date is plus 1 day
            TestDate = TestDate.AddDays(1);
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);//This should pass
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ReleaseDateMax()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //creates test data
            DateTime TestDate;
            //sets to todays date
            TestDate = DateTime.Now.Date;//This should pass
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ReleaseDateMaxLessOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //creates test data
            DateTime TestDate;
            //sets todays date
            TestDate = DateTime.Now.Date;
            //take -1 day off
            TestDate = TestDate.AddDays(-1);//This should pass
            //converts into toString
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ReleaseDateExtremeMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date to todays date
            TestDate = DateTime.Now.Date;
            //change the date to whatever the date is plus 100 years
            TestDate = TestDate.AddDays(1);
            //convert the date variable to a string variable
            string ReleaseDate = TestDate.ToString();
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
        
        [TestMethod]
        public void ReleaseDateInvalidData()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            
            string gameName = "FIFA 21";
            string Price = "60";
            string AgeRating = "3";
            string ReleaseDate = "This is not a date!";
            //invokes the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see correct result
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void PriceEmpty()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //String variable to store price
            string Price = "";
            //invokes the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);//Should fail
            //test to see correct result
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void PriceMin()
        {
            //create an instance of the class we want to create   
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //creating some test data
            string Price = "1";//should pass
            //invokes the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
           //test to see correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PriceMinLessOne()
        {
            //create an instance of the class we want to create 
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //creating some test data
            string Price = "0";//Should fail
            //invokes the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see correct result
            Assert.AreNotEqual(Error, "");
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }


        [TestMethod]
        public void PriceMid()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string Price = "50"; //this should be ok
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void PriceExtremeMax()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string Price = "";
            Price = Price.PadRight(1000, '1');//should fail
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void PriceInvalidData()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            string gameName = "FIFA 21";
            string Price = "This is not a Valid figure";
            string AgeRating = "This is not a valid number";
            string ReleaseDate = "This is not a date!";
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void AgeRatingMinLessOne()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //creates test data
            string AgeRating = "0";
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void AgeRatingMin()
        {

            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //creates test data
            String AgeRating = "1";//this should pass
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
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
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void AgeRatingMid()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string AgeRating = "10"; //this should pass
            //invoke the method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }



        [TestMethod]
        public void AgeRatingExtremeMax()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string AgeRating = "";
            //changes age rating 100 to the right
            AgeRating = AgeRating.PadRight(100, '1');//should fail
            //invokes method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }



        [TestMethod]
        public void AgeRatingInvalidData()
        {
            //create an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            String Error = "";
            //creates test data
            string gameName = "FIFA 21";
            string Price = "60";
            string AgeRating = "This is not a valid number";
            string ReleaseDate = "This is not a date!";
            //invokes method
            Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }


        [TestMethod]
        public void GameIdOk()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //creates test data
            int TestData = TestInt;
            AnStock.gameID = TestData;
            //test to see the correct result
            Assert.AreEqual(AnStock.gameID, TestData);
        }

        [TestMethod]
        public void GameNameOk()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //creates test data
            string TestData = TestString;
            AnStock.gameName = TestData;
            //test to see the correct result
            Assert.AreEqual(AnStock.gameName, TestData);
        }


        [TestMethod]
        public void AvailabilityOk()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //creates test data
            Boolean TestData = true;
            AnStock.Availability = TestData;
            //test to see the correct result
            Assert.AreEqual(AnStock.Availability, TestData);
        }

        [TestMethod]
        public void ReleaseDateOk()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //creates test data
            DateTime TestData = DateTime.Now.Date;
            AnStock.ReleaseDate = TestData;
            //test to see the correct result
            Assert.AreEqual(AnStock.ReleaseDate, TestData);
        }

        [TestMethod]
        public void PriceOk()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //test data
            decimal TestData = TestDec;
            AnStock.Price = TestData;
            //test to see the correct result
            Assert.AreEqual(AnStock.Price, TestData);
        }

        [TestMethod]
        public void AgeRatingOk()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //test data
            int TestData = TestInt;
            AnStock.AgeRating = TestData;
            //test to see the correct result
            Assert.AreEqual(AnStock.AgeRating, TestData);
        }

        [TestMethod]
        public void GameNameNotNull()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            string Error = "";
            //creates test data
            string TestData = TestString;
            //invokes method
            Error = AnStock.Valid(TestString);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void MinLessOne()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            string Error = "";
            //creates test data as a String
            string TestData = "";
            //invokes method
            Error = AnStock.Valid(TestData);
            //tests to see correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void MaxPlusOne()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            //string variable to store any error message
            string Error = "";
            //creates test data as a String
            string TestData = "";
            //moves test data 51 spaces to the left
            TestData = TestData.PadLeft(51, '*');
            //invokes the method
            Error = AnStock.Valid(TestData);
            //tests to see correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void FindMethodOK()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            
            Boolean Found = false;
            //tests for random ID to see if it can find the primary key
            Int32 gameID = 2;
          
            Found = AnStock.Find(gameID);
            //test to see correct result

            Assert.IsTrue(Found);
        }

        [TestMethod]

        public void TestGameIDFound()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;
            //tests to see for a specfic ID
            Int32 gameID = 3;

            Found = AnStock.Find(gameID);
            if (AnStock.gameID != 3)
            {
                OK = false;
            }
            //test to see correct result
            Assert.IsTrue(OK);
        }

        [TestMethod]

        public void TestGameNameFound()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;
            //tests to see for a specfic ID
            Int32 gameID = 3;

            Found = AnStock.Find(gameID);
            if (AnStock.gameName != "FIFA 21")
            {
                OK = false;
            }
            //test to see correct result
            Assert.IsTrue(OK);
        }


        [TestMethod]

        public void TestReleaseDateFound()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);

            if (AnStock.ReleaseDate!= Convert.ToDateTime("06/10/2020"))
            {
                OK = false;
            }
            //test to see correct result
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPriceFound()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);

            if (AnStock.Price != Convert.ToDecimal(60))
            {
                OK = false;
            }
            //test to see correct result
            Assert.IsTrue(OK);
        }


        [TestMethod]
        public void TestAvailabilityFound()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);

            if (AnStock.Availability != true)
            {
                OK = false;
            }

            //test to see correct result
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestAgeRatingFound()
        {
            //creates an instance of the class we want to create
            clsStock AnStock = new clsStock();
            Boolean Found = false;

            Boolean OK = true;

            Int32 gameID = 3;

            Found = AnStock.Find(gameID);

            if (AnStock.AgeRating != 3)
            {
                OK = false;
            }
            //test to see correct result
            Assert.IsTrue(OK);
        }



















    }
}

