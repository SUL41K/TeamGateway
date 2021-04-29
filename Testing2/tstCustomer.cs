using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Testing2
{
    [TestClass]
    public class tstCustomer
    {
        //good test data
        private string TestString = "Some Test String";
        private int TestInt = 123;
        string CustomerName = "Tobias Jenkins";
        string CustomerEmail = "tjenkins@gmail.com";
        string CustomerDOB = new DateTime(1950, 01, 01).ToString();

        [TestMethod]
        public void InstanceOk()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //check if it exists
            Assert.IsNotNull(ACustomer);

        }

        [TestMethod]
        public void ValidMethodOK()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //invoke method
            Error = ACustomer.Valid(CustomerName,CustomerEmail,CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMinLessOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerName = "";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMin()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerName = "a";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMinPlusOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerName = "aa";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMaxLessOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMax()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMid()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerName = "aaaaaaaaaaaaaaa";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMaxPlusOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameExtremeMax()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerName = "";
            //Apply character to customer name 1000 times
            CustomerName = CustomerName.PadRight(1000, 'a');
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBExtremeMin()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB  
            DateTime TestDate;
            TestDate = new DateTime(1950, 01, 01);
            //Remove 200 years from lowest year
            TestDate = TestDate.AddYears(-200);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMinLessOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB
            DateTime TestDate;
            TestDate = new DateTime(1950, 01, 01);
            //remove one day from min date
            TestDate = TestDate.AddDays(-1);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMin()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB
            DateTime TestDate;
            TestDate = new DateTime(1950, 01, 01);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMax()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB
            DateTime TestDate;
            TestDate = new DateTime(2010, 01, 01);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMaxPlusOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB
            DateTime TestDate;
            TestDate = new DateTime(2010, 01, 01);
            TestDate = TestDate.AddDays(1);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMaxLessOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB
            DateTime TestDate;
            TestDate = new DateTime(2010, 01, 01);
            //reomve a day from max year
            TestDate = TestDate.AddDays(-1);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMid()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB
            DateTime TestDate;
            TestDate = new DateTime(1980, 01, 01);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMinPlusOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB
            DateTime TestDate;
            TestDate = new DateTime(1950, 01, 01);
            //Add one day to min year
            TestDate = TestDate.AddDays(1);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBExtremeMax()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data for DOB
            DateTime TestDate;
            TestDate = new DateTime(2010, 01, 01);
            //Add 200 years to max date
            TestDate = TestDate.AddYears(200);
            //Convert test data to string for it to be read
            string CustomerDOB = TestDate.ToString();
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBInvalidData()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "Tobias Jenkins";
            string CustomerEmail = "tjenkins@gmail.com";
            string CustomerDOB = "this is not a date";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerEmailMinLessOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerEmail = "";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMin()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerEmail = "a";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMinPlusOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerEmail = "aa";
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMaxLessOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerEmail = "";
            //output the same character 49 times
            CustomerEmail = CustomerEmail.PadRight(49, 'a');
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMax()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerEmail = "";
            //output the same character 50 times
            CustomerEmail = CustomerEmail.PadRight(50, 'a');
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMaxPlusOne()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerEmail = "";
            //output the same character 51 times
            CustomerEmail = CustomerName.PadRight(51, 'a');
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMid()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerEmail = "";
            //output the same character 51 times
            CustomerEmail = CustomerEmail.PadRight(25, 'a');
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailExtremeMax()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            String Error = "";
            //create test data to pass the method
            string CustomerEmail = "";
            //output the same character 1000 times
            CustomerEmail = CustomerName.PadRight(1000, 'a');
            //invoke method
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            //test to see the correct result
            Assert.AreNotEqual(Error, "");
        }



        [TestMethod]
        public void CustomerIdOk()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            int TestData = TestInt;
            ACustomer.CustomerId = TestData;
            //test to see the correct result
            Assert.AreEqual(ACustomer.CustomerId, TestData);
        }

        [TestMethod]
        public void CustomerNameOk()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            string TestData = TestString;
            ACustomer.CustomerName = TestData;
            //test to see the correct result
            Assert.AreEqual(ACustomer.CustomerName, TestData);
        }

        [TestMethod]
        public void CustomerEmailOk()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            string TestData = TestString;
            ACustomer.CustomerEmail = TestData;
            //test to see the correct result
            Assert.AreEqual(ACustomer.CustomerEmail, TestData);
        }


        [TestMethod]
        public void CustomerDOBOk()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //set random to test date properties
            DateTime TestData = DateTime.Now.Date;
            ACustomer.CustomerDOB = TestData;
            //test to see the correct result
            Assert.AreEqual(ACustomer.CustomerDOB, TestData);
        }


        [TestMethod]
        public void CustomerSubscribeOk()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            Boolean TestData = true;
            ACustomer.CustomerSubscribe = TestData;
            //test to see the correct result
            Assert.AreEqual(ACustomer.CustomerSubscribe, TestData);
        }

        [TestMethod]
        public void CustomerNameNotNull()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            //create test data for error message
            string Error = "";
            string TestData = TestString;
            //invoke the method
            Error = ACustomer.Valid(TestString);
            //test to see the correct result
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void MinLessOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string TestData = "";
            Error = ACustomer.Valid(TestData);
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();

            Boolean Found = false;
            //test random ID to see if it finds customer Id
            Int32 CustomerId = 3;

            Found = ACustomer.Find(CustomerId);
            //test to see the correct result
            Assert.IsTrue(Found);
        }

        [TestMethod]

        public void TestCustomerNameFound()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;
            //test chosen ID in database to see if it finds customer Id
            Int32 CustomerId = 3;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerName != "Tobias Jenkins")
            {
                OK = false;
            }

            //test to see the correct result
            Assert.IsTrue(OK);
        }

        [TestMethod]

        public void TestCustomerIdFound()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;
            //test chosen ID in database to see if it finds customer Id
            Int32 CustomerId = 3;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerId != 3)
            {
                OK = false;
            }
            //test to see the correct result
            Assert.IsTrue(OK);
        }

        [TestMethod]

        public void TestCustomerDOBFound()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;

            Int32 CustomerId = 3;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerDOB != Convert.ToDateTime("23/06/1999"))
            {
                OK = false;
            }
            //test to see the correct result
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestCustomerEmailFound()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;

            Int32 CustomerId = 3;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerEmail != "tjenkins@gmail.com")
            {
                OK = false;
            }

            //test to see the correct result
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestCustomerSubscribeFound()
        {
            //create an instance of clsCustomer
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;

            Int32 CustomerId = 17;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerSubscribe != true)
            {
                OK = false;
            }

            //test to see the correct result
            Assert.IsTrue(OK);
        }




    }
}

