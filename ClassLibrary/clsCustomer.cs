using System;

namespace ClassLibrary
{
    public class clsCustomer
    {
        private string mCustomerName;
        private Int32 mCustomerId;
        private DateTime mCustomerDOB;
        private string mCustomerEmail;
        private Boolean mCustomerSubscribe;

        public string CustomerName
        {
            get
            {
                return mCustomerName;
            }

            set
            {
                mCustomerName = value;
            }
        }
        public Int32 CustomerId
        {
            get
            {
                return mCustomerId;
            }
            set
            {
                mCustomerId = value;
            }
        }

        public DateTime CustomerDOB
        {
            get
            {
                return mCustomerDOB;
            }
            set
            {
                mCustomerDOB = value;
            }
        }
        public string CustomerEmail
        {
            get
            {
                return mCustomerEmail;
            }
            set
            {
                mCustomerEmail = value;
            }
        }
                  
        public Boolean CustomerSubscribe
        {
            get
            {
                return mCustomerSubscribe;
            }
            set
            {
                mCustomerSubscribe = value;
            }
        }

        public string Valid(string cCustomerName)
        {
            if (cCustomerName.Length < 1)
            {
                return "description cannot be blank";
            }

            if (cCustomerName.Length > 50)
            {
                return "description cannot be more then 50 characters";
            }

            else
            {
                return "";
            }
        }

        public bool Find(Int32 customerId)
        {
            mCustomerId = 1;
            mCustomerDOB = Convert.ToDateTime("10/10/1994");
            mCustomerName = "Tobias Jenkins";
            mCustomerEmail = "tjenkins@gmail.com";
            mCustomerSubscribe = true;
            return true;
        }
    }
}
