using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsCustomerCollection
    {

        public clsCustomerCollection()
        {
            Int32 Index = 0;
            Int32 RecordCount = 0;

            //create new instance of data connection class
            clsDataConnection DB = new clsDataConnection();
            //excecute select all stored procedure
            DB.Execute("sproc_tblCustomer_SelectAll");
            PopulateArray(DB);

            //creates new instance of clsCustomer
            //Adds all data entered in each field to create a new customer. Adds customer and increments index of each attribute
            while (Index < RecordCount)
            {
                clsCustomer ACustomer = new clsCustomer();
                ACustomer.CustomerSubscribe = Convert.ToBoolean(DB.DataTable.Rows[Index]["customerSubscribe"]);
                ACustomer.CustomerName = Convert.ToString(DB.DataTable.Rows[Index]["customerName"]);
                ACustomer.CustomerId = Convert.ToInt32(DB.DataTable.Rows[Index]["customerId"]);
                ACustomer.CustomerEmail = Convert.ToString(DB.DataTable.Rows[Index]["customerEmail"]);
                ACustomer.CustomerDOB = Convert.ToDateTime(DB.DataTable.Rows[Index]["customerDOB"]);


                mCustomerList.Add(ACustomer);
                Index++;

            }

        }

        clsCustomer mThisCustomer = new clsCustomer();
        List<clsCustomer> mCustomerList = new List<clsCustomer>();
        public List<clsCustomer> CustomerList
        {
            get
            {
                return mCustomerList;
            }
            set
            {
                mCustomerList = value;
            }
        }
        public int Count
        {
            get
            {
                return mCustomerList.Count;
            }
            set
            {

            }
        }
        public clsCustomer ThisCustomer
        {
            get
            {
                return mThisCustomer;
            }
            set
            {
                mThisCustomer = value;
            }
        }

        public int Add()
        {
            //create new instance of data connection class
            clsDataConnection DB = new clsDataConnection();
            //add parameters to table fields to create a new customer
            DB.AddParameter("@customerName", mThisCustomer.CustomerName);
            DB.AddParameter("@customerEmail", mThisCustomer.CustomerEmail);
            DB.AddParameter("@customerDOB", mThisCustomer.CustomerDOB);
            DB.AddParameter("@customerSubscribe", mThisCustomer.CustomerSubscribe);
            //execute stored procedure which inserts new data into the table
            return DB.Execute("sproc_tblCustomer_Insert");

        }

        public void Update()
        {
            //create new instance of data connection class
            clsDataConnection DB = new clsDataConnection();
            //add parameters to table fields to create new details for customer
            DB.AddParameter("@customerId", mThisCustomer.CustomerId);
            DB.AddParameter("@customerName", mThisCustomer.CustomerName);
            DB.AddParameter("@customerEmail", mThisCustomer.CustomerEmail);
            DB.AddParameter("@customerDOB", mThisCustomer.CustomerDOB);
            DB.AddParameter("@customerSubscribe", mThisCustomer.CustomerSubscribe);
            //execute stored procedure which updates existing customer data with newly inputted data
            DB.Execute("sproc_tblCustomer_Update");
        }

        public void Delete()
        {
            //create new instance of data connection class
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("customerId", mThisCustomer.CustomerId);
            //execute stored procedure which deletes primary key record
            DB.Execute("sproc_tblCustomer_Delete");
        }

        public void ReportByName(string Name)
        {
            //create new instance of data connection class
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@customerName", Name);
            //execute stored procedure which filters records by first name
            DB.Execute("sproc_tblCustomer_FilterBycustomerName");
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            Int32 Index = 0;
            Int32 RecordCount;
            RecordCount = DB.Count;
            mCustomerList = new List<clsCustomer>();
            while (Index < RecordCount)
            {
                clsCustomer ACustomer = new clsCustomer();
                ACustomer.CustomerSubscribe = Convert.ToBoolean(DB.DataTable.Rows[Index]["customerSubscribe"]);
                ACustomer.CustomerName = Convert.ToString(DB.DataTable.Rows[Index]["customerName"]);
                ACustomer.CustomerId = Convert.ToInt32(DB.DataTable.Rows[Index]["customerId"]);
                ACustomer.CustomerEmail = Convert.ToString(DB.DataTable.Rows[Index]["customerEmail"]);
                ACustomer.CustomerDOB = Convert.ToDateTime(DB.DataTable.Rows[Index]["customerDOB"]);
                mCustomerList.Add(ACustomer);
                Index++;
            }
        }
    }
}