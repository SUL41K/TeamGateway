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
            RecordCount = DB.Count;

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
        public clsCustomer ThisCustomer { get; set; }
    }
}