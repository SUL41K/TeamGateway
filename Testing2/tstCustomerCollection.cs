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
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            Assert.IsNotNull(AllCustomers);
        }

        [TestMethod]
        public void CustomerListOK()
        {
            DateTime DOB;
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            List<clsCustomer> TestList = new List<clsCustomer>();
            DOB = new DateTime(1994, 10, 10);
            clsCustomer TestItem = new clsCustomer();
            TestItem.CustomerSubscribe = true;
            TestItem.CustomerDOB = DOB;
            TestItem.CustomerEmail = "tkenkins@gmail.com";
            TestItem.CustomerId = 1;
            TestItem.CustomerName = "Tobias Jenkins";

            TestList.Add(TestItem);
            AllCustomers.CustomerList = TestList;
            Assert.AreEqual(AllCustomers.CustomerList, TestList);
        }

        [TestMethod]
        public void ThisCustomerPropertyOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestCustomer = new clsCustomer();
            TestCustomer.CustomerSubscribe = true;
            TestCustomer.CustomerName = "Tobias Jenkins";
            TestCustomer.CustomerId = 1;
            TestCustomer.CustomerEmail = "tjenkins@gmail.com";
            TestCustomer.CustomerDOB = new DateTime(1994, 10, 10);
            AllCustomers.ThisCustomer = TestCustomer;
            Assert.AreEqual(AllCustomers.ThisCustomer, TestCustomer);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            DateTime DOB;
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            List<clsCustomer> TestList = new List<clsCustomer>();
            DOB = new DateTime(1994, 10, 10);
            clsCustomer TestItem = new clsCustomer();
            TestItem.CustomerSubscribe = true;
            TestItem.CustomerDOB = DOB;
            TestItem.CustomerEmail = "tkenkins@gmail.com";
            TestItem.CustomerId = 1;
            TestItem.CustomerName = "Tobias Jenkins";

            TestList.Add(TestItem);
            AllCustomers.CustomerList = TestList;
            Assert.AreEqual(AllCustomers.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();
            Int32 PrimaryKey = 0;
            TestItem.CustomerSubscribe = true;
            TestItem.CustomerId = 1;
            TestItem.CustomerDOB = new DateTime(1994, 10, 10);
            TestItem.CustomerName = "Tobias Jenkins";
            TestItem.CustomerEmail = "tjenkins@gmail.com";

            AllCustomers.ThisCustomer = TestItem;
            PrimaryKey = AllCustomers.Add();
            TestItem.CustomerId = PrimaryKey;
            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();
            Int32 PrimaryKey = 0;
            TestItem.CustomerName = "Tobias Jenkins";
            TestItem.CustomerDOB = new DateTime(1994, 10, 10);
            TestItem.CustomerEmail = "tjenkins@gmail.com";
            TestItem.CustomerSubscribe = true;
            AllCustomers.ThisCustomer = TestItem;
            PrimaryKey = AllCustomers.Add();
            TestItem.CustomerId = PrimaryKey;
            TestItem.CustomerName = "Paul Jenkins";
            TestItem.CustomerDOB = new DateTime(1995, 09, 10);
            TestItem.CustomerEmail = "pjenkins@gmail.com";
            TestItem.CustomerSubscribe = false;
            AllCustomers.ThisCustomer = TestItem;
            AllCustomers.Update();
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);

        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();
            Int32 PrimaryKey = 0;
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
            Assert.IsFalse(Found);
        }

        [TestMethod]

        public void ReportByNameMethodOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            FilteredCustomers.ReportByName("");
            Assert.AreEqual(AllCustomers.Count, FilteredCustomers.Count);
        }

        [TestMethod]

        public void ReportByNameNoneFound()
        {
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            FilteredCustomers.ReportByName("xxxxx xxxxx");
            Assert.AreEqual(0, FilteredCustomers.Count);
        }

        [TestMethod]

        public void ReportByNameTestDataFound()
        {
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            Boolean OK = true;
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

                Assert.IsTrue(OK);


            }
        }
    }
}
