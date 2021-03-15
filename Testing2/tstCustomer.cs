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
            clsCustomer ACustomer = new clsCustomer();

            Assert.IsNotNull(ACustomer);

        }

        [TestMethod]
        public void ValidMethodOK()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            Error = ACustomer.Valid(CustomerName,CustomerEmail,CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMinLessOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMin()
        {
            
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "a"; 
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMinPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "aa"; 
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMaxLessOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMid()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "aaaaaaaaaaaaaaa";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameMaxPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerNameExtremeMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "";
            CustomerName = CustomerName.PadRight(1000, 'a');
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBExtremeMin()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(1950, 01, 01);
            TestDate = TestDate.AddYears(-200);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMinLessOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(1950, 01, 01);
            TestDate = TestDate.AddDays(-1);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMin()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(1950, 01, 01);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(2010, 01, 01);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMaxPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(2010, 01, 01);
            TestDate = TestDate.AddDays(1);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMaxLessOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(2010, 01, 01);
            TestDate = TestDate.AddDays(-1);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMid()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(1980, 01, 01);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBMinPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(1950, 01, 01);
            TestDate = TestDate.AddDays(1);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBExtremeMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            DateTime TestDate;
            TestDate = new DateTime(2010, 01, 01);
            TestDate = TestDate.AddYears(200);
            string CustomerDOB = TestDate.ToString();
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerDOBInvalidData()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerName = "Tobias Jenkins";
            string CustomerId = "2";
            string CustomerEmail = "tjenkins@gmail.com";
            string CustomerDOB = "this is not a date";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerEmailMinLessOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerEmail = "";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMin()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerEmail = "a";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMinPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerEmail = "aa";
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMaxLessOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerEmail = "";
            CustomerEmail = CustomerEmail.PadRight(49, 'a');
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerEmail = "";
            CustomerEmail = CustomerEmail.PadRight(50, 'a');
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMaxPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerEmail = "";
            CustomerEmail = CustomerName.PadRight(51, 'a');
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMid()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerEmail = "";
            CustomerEmail = CustomerEmail.PadRight(25, 'a');
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailExtremeMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            String Error = "";
            string CustomerEmail = "";
            CustomerEmail = CustomerName.PadRight(1000, 'a');
            Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);
            Assert.AreNotEqual(Error, "");
        }



        [TestMethod]
        public void CustomerIdOk()
        {
            clsCustomer ACustomer = new clsCustomer();
            int TestData = TestInt;
            ACustomer.CustomerId = TestData;
            Assert.AreEqual(ACustomer.CustomerId, TestData);
        }

        [TestMethod]
        public void CustomerNameOk()
        {
            clsCustomer ACustomer = new clsCustomer();
            string TestData = TestString;
            ACustomer.CustomerName = TestData;
            Assert.AreEqual(ACustomer.CustomerName, TestData);
        }

        [TestMethod]
        public void CustomerEmailOk()
        {
            clsCustomer ACustomer = new clsCustomer();
            string TestData = TestString;
            ACustomer.CustomerEmail = TestData;
            Assert.AreEqual(ACustomer.CustomerEmail, TestData);
        }


        [TestMethod]
        public void CustomerDOBOk()
        {

            clsCustomer ACustomer = new clsCustomer();
            DateTime TestData = DateTime.Now.Date;
            ACustomer.CustomerDOB = TestData;
            Assert.AreEqual(ACustomer.CustomerDOB, TestData);
        }


        [TestMethod]
        public void CustomerSubscribeOk()
        {
            clsCustomer ACustomer = new clsCustomer();
            Boolean TestData = true;
            ACustomer.CustomerSubscribe = TestData;
            Assert.AreEqual(ACustomer.CustomerSubscribe, TestData);
        }

        [TestMethod]
        public void CustomerNameNotNull()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string TestData = TestString;
            Error = ACustomer.Valid(TestString);
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
            clsCustomer ACustomer = new clsCustomer();

            Boolean Found = false;

            Int32 CustomerId = 1;

            Found = ACustomer.Find(CustomerId);

            Assert.IsTrue(Found);
        }

        [TestMethod]

        public void TestCustomerNameFound()
        {
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;

            Int32 CustomerId = 5;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerName != "Joseph Stevenson")
            {
                OK = false;
            }


            Assert.IsTrue(OK);
        }

        [TestMethod]

        public void TestCustomerIdFound()
        {
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;

            Int32 CustomerId = 1;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerId != 1)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]

        public void TestCustomerDOBFound()
        {
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;

            Int32 CustomerId = 1;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerDOB != Convert.ToDateTime("10/10/1994"))
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestCustomerEmailFound()
        {
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;

            Int32 CustomerId = 3;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerEmail != "tjenkins@gmail.com")
            {
                OK = false;
            }


            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestCustomerSubscribeFound()
        {
            clsCustomer ACustomer = new clsCustomer();
            Boolean Found = false;

            Boolean OK = true;

            Int32 CustomerId = 2;

            Found = ACustomer.Find(CustomerId);

            if (ACustomer.CustomerSubscribe != true)
            {
                OK = false;
            }


            Assert.IsTrue(OK);
        }


    }
}

