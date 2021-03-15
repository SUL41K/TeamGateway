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

            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblCustomer_SelectAll");
            PopulateArray(DB);

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
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@customerName", mThisCustomer.CustomerName);
            DB.AddParameter("@customerEmail", mThisCustomer.CustomerEmail);
            DB.AddParameter("@customerDOB", mThisCustomer.CustomerDOB);
            DB.AddParameter("@customerSubscribe", mThisCustomer.CustomerSubscribe);

            return DB.Execute("sproc_tblCustomer_Insert");

        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@customerId", mThisCustomer.CustomerId);
            DB.AddParameter("@customerName", mThisCustomer.CustomerName);
            DB.AddParameter("@customerEmail", mThisCustomer.CustomerEmail);
            DB.AddParameter("@customerDOB", mThisCustomer.CustomerDOB);
            DB.AddParameter("@customerSubscribe", mThisCustomer.CustomerSubscribe);

            DB.Execute("sproc_tblCustomer_Update");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("customerId", mThisCustomer.CustomerId);
            DB.Execute("sproc_tblCustomer_Delete");
        }

        public void ReportByName(string Name)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@customerName", Name);
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