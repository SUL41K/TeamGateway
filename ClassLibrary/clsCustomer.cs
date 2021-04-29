using System;

namespace ClassLibrary
{
    public class clsCustomer
    {
        //private declarations of each attribute
        private string mCustomerName;
        private Int32 mCustomerId;
        private DateTime mCustomerDOB;
        private string mCustomerEmail;
        private Boolean mCustomerSubscribe;

        //get and set method to return customer name
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

        //get and set method to return customer Id
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

        //get and set method to return customer DOB
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

        //Validation method to ensure the correct and accurate data is being inputted for each attribute
        public string Valid(string customerName, string customerEmail, string customerDOB)
        {
            //blank string for error message
            String Error = "";

            //date time variables added to create age range for DOB
            DateTime DateTemp;
            DateTime Date1950;
            DateTime DateMax;

            //Setting condition if name is empty
            if (customerName.Length == 0)
            {
                //Update error message string if field is empty
                Error = Error + "The Customer Name may not be blank : ";
            }

            //Setting condition if name is over 30 characters
            if (customerName.Length > 30)
            {
                //Update error message if field is over 30 characters
                Error = Error + "The Customer Name must be less than 30 characters : ";
            }

            //Setting condition if email is empty
            if (customerEmail.Length == 0)
            {
                //Update error message string if field is empty
                Error = Error + "The Customer email may not be blank : ";
            }

            //Setting condition if email is over 50 characters
            if (customerEmail.Length > 50)
            {
                //Update error message if email is over 50 characters
                Error = Error + "The Customer email must be less than 50 characters : ";
            }

            if (String.IsNullOrEmpty(customerName))
            {
                Error = Error + "The name must not contain numbers";
            }

            try
            {
                //Making variable value the same as the customer DOB
                DateTemp = Convert.ToDateTime(customerDOB);
                //Setting minimum valid date
                Date1950 = new DateTime(1950, 01, 01);
                //setting maximum valid date
                DateMax = new DateTime(2010, 01, 01);

                //Setting condition if DOB is earlier than minimum valid date
                if (DateTemp < Date1950)
                {
                    //Updates error message
                    Error = Error + "The date cannot be before 1950 : ";
                }

                //Setting condition if date is later than maximum date set
                if (DateTemp > Date1950 && DateTemp > DateMax)
                {
                    //Updates error message
                    Error = Error + "The date cannot be after 2010 : ";
                }

            }
            catch
            {
                //Updates error message if incorrect data was inputted
                Error = Error + "The date was not a valid date : ";
            }

            return Error;
        }

        //set and get method to return email
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

        //set and get method to return boolean checkbox value
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

            else
            {
                return "";
            }
        }

        public bool Find(Int32 customerId)
        {
            //create new instance of the dataconnection class
            clsDataConnection DB = new clsDataConnection();
            //add customer id parameter to customer Id table field
            DB.AddParameter("@customerId", customerId);
            //execute stored procedure
            DB.Execute("sproc_tblCustomer_FilterBycustomerId");

            //search and return all table fields if count == 1
            if (DB.Count == 1)
            {


                mCustomerId = Convert.ToInt32(DB.DataTable.Rows[0]["customerId"]);
                mCustomerDOB = Convert.ToDateTime(DB.DataTable.Rows[0]["customerDOB"]);
                mCustomerName = Convert.ToString(DB.DataTable.Rows[0]["customerName"]);
                mCustomerEmail = Convert.ToString(DB.DataTable.Rows[0]["customerEmail"]);
                mCustomerSubscribe = Convert.ToBoolean(DB.DataTable.Rows[0]["customerSubscribe"]);
                //returns all of the found data attributes into each field
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
