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

        [TestMethod]
        public void InstanceOk()
        {
            clsCustomer ACustomer = new clsCustomer();

            Assert.IsNotNull(ACustomer);

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

