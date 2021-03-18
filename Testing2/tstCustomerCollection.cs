using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Testing2
{
    [TestClass]
    public class tstCustomerCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //test to see that it exists
            Assert.IsNotNull(AllCustomers);
        }

        [TestMethod]
        public void CustomerListOK()
        {
            DateTime DOB;
            //create an instance of the class we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            List<clsCustomer> TestList = new List<clsCustomer>();
            //create test data for each attribute
            DOB = new DateTime(1994, 10, 10);
            clsCustomer TestItem = new clsCustomer();
            TestItem.CustomerSubscribe = true;
            TestItem.CustomerDOB = DOB;
            TestItem.CustomerEmail = "tkenkins@gmail.com";
            TestItem.CustomerId = 1;
            TestItem.CustomerName = "Tobias Jenkins";

            TestList.Add(TestItem);
            AllCustomers.CustomerList = TestList;
            //test to see that it passes
            Assert.AreEqual(AllCustomers.CustomerList, TestList);
        }

        [TestMethod]
        public void ThisCustomerPropertyOK()
        {
            //create an instance of the classes we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestCustomer = new clsCustomer();
            //create test data for each attribute
            TestCustomer.CustomerSubscribe = true;
            TestCustomer.CustomerName = "Tobias Jenkins";
            TestCustomer.CustomerId = 1;
            TestCustomer.CustomerEmail = "tjenkins@gmail.com";
            TestCustomer.CustomerDOB = new DateTime(1994, 10, 10);
            AllCustomers.ThisCustomer = TestCustomer;
            //test to see that it passes
            Assert.AreEqual(AllCustomers.ThisCustomer, TestCustomer);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            DateTime DOB;
            //create an instance of the classes we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            List<clsCustomer> TestList = new List<clsCustomer>();
            //create test data for each attribute
            DOB = new DateTime(1994, 10, 10);
            clsCustomer TestItem = new clsCustomer();
            TestItem.CustomerSubscribe = true;
            TestItem.CustomerDOB = DOB;
            TestItem.CustomerEmail = "tkenkins@gmail.com";
            TestItem.CustomerId = 1;
            TestItem.CustomerName = "Tobias Jenkins";

            TestList.Add(TestItem);
            AllCustomers.CustomerList = TestList;
            //test to see that it passes
            Assert.AreEqual(AllCustomers.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the classes we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();
            Int32 PrimaryKey = 0;
            //create test data for each attribute
            TestItem.CustomerSubscribe = true;
            TestItem.CustomerId = 1;
            TestItem.CustomerDOB = new DateTime(1994, 10, 10);
            TestItem.CustomerName = "Tobias Jenkins";
            TestItem.CustomerEmail = "tjenkins@gmail.com";

            AllCustomers.ThisCustomer = TestItem;
            PrimaryKey = AllCustomers.Add();
            TestItem.CustomerId = PrimaryKey;
            //test to see that it passes
            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create an instance of the classes we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();
            Int32 PrimaryKey = 0;
            //create test data for each attribute
            TestItem.CustomerName = "Tobias Jenkins";
            TestItem.CustomerDOB = new DateTime(1994, 10, 10);
            TestItem.CustomerEmail = "tjenkins@gmail.com";
            TestItem.CustomerSubscribe = true;
            AllCustomers.ThisCustomer = TestItem;
            PrimaryKey = AllCustomers.Add();
            TestItem.CustomerId = PrimaryKey;
            //create new data for each attribute to update
            TestItem.CustomerName = "Paul Jenkins";
            TestItem.CustomerDOB = new DateTime(1995, 09, 10);
            TestItem.CustomerEmail = "pjenkins@gmail.com";
            TestItem.CustomerSubscribe = false;
            AllCustomers.ThisCustomer = TestItem;
            AllCustomers.Update();
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            //test to see that it passes
            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);

        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create an instance of the classes we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();
            Int32 PrimaryKey = 0;
            //create test data for each attribute
            TestItem.CustomerSubscribe = true;
            TestItem.CustomerId = 1;
            TestItem.CustomerDOB = new DateTime(1994, 10, 10);
            TestItem.CustomerName = "Tobias Jenkins";
            TestItem.CustomerEmail = "tjenkins@gmail.com";

            AllCustomers.ThisCustomer = TestItem;
            PrimaryKey = AllCustomers.Add();
            TestItem.CustomerId = PrimaryKey;
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            AllCustomers.Delete();
            Boolean Found = AllCustomers.ThisCustomer.Find(PrimaryKey);
            //test to see that it passes
            Assert.IsFalse(Found);
        }

        [TestMethod]

        public void ReportByNameMethodOK()
        {
            //create an instance of the classes we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            FilteredCustomers.ReportByName("");
            //test to see that it passes
            Assert.AreEqual(AllCustomers.Count, FilteredCustomers.Count);
        }

        [TestMethod]

        public void ReportByNameNoneFound()
        {
            //create an instance of the classes we want to create
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            //non existing data created to see if it finds it
            FilteredCustomers.ReportByName("xxxxx xxxxx");
            //test to see that it passes
            Assert.AreEqual(0, FilteredCustomers.Count);
        }

        [TestMethod]

        public void ReportByNameTestDataFound()
        {
            //create an instance of the classes we want to create
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            Boolean OK = true;
            //testing when 4 of the same name entry is found
            FilteredCustomers.ReportByName("Tobias Jenkins");
            if (FilteredCustomers.Count == 4)
            {
                if(FilteredCustomers.CustomerList[0].CustomerId != 3)
                {
                    OK = false;
                }

                if (FilteredCustomers.CustomerList[0].CustomerId != 8)
                {
                    OK = false;
                }

                if (FilteredCustomers.CustomerList[0].CustomerId != 10)
                {
                    OK = false;
                }

                if (FilteredCustomers.CustomerList[0].CustomerId != 11)
                {
                    OK = false;
                }
                //test to see that it passes
                Assert.IsTrue(OK);


            }
        }
    }
}
