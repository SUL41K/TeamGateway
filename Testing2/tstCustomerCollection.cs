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


    }
}
