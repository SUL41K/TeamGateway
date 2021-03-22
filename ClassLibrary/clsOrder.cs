using System;

namespace ClassLibrary
{
    public class clsOrder
    {
        private int mOrderID;   //private variables to be used later
        private string mGameTitle;
        private Decimal mTotalPrice;
        private DateTime mDeliveryDate;
        private Boolean mShipment;

        public int orderID //get and set methods
        {
            get
            {
                return mOrderID;
            }
            set
            {
                mOrderID = value;
            }
        }

        public string GameTitle
        {
            get
            {
                return mGameTitle;
            }
            set
            {
                mGameTitle = value;
            }
        }
        public Decimal TotalPrice
        {
            get
            {
                return mTotalPrice;
            }
            set
            {
                mTotalPrice = value;
            }
        }
        public DateTime DeliveryDate
        {
            get
            {
                return mDeliveryDate;
            }
            set
            {
                mDeliveryDate = value;
            }
        }
        public Boolean Shipment
        {
            get
            {
                return mShipment;
            }
            set
            {
                mShipment = value;
            }
        }

       

        public string Valid(string gGameTitle) //test if game title is valid
        {
            if (gGameTitle.Length < 1) //bigger than 1
            {
                return "description cannot be blank";
            }

            if (gGameTitle.Length > 50) //smaller than 50
            {
                return "description cannot be more then 50 characters";
            }

            else  //else no error was found
            {
                return "";
            }
        }

        public bool Find(int orderID)
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("OrderID", orderID);

            DB.Execute("sproc_tblOrder_FilterByOrderId"); //filter ID to find what we need

            if (DB.Count == 1) //if its found then get all other variables converted
            {

                mOrderID = Convert.ToInt32(DB.DataTable.Rows[0]["orderID"]);
                mGameTitle = Convert.ToString(DB.DataTable.Rows[0]["gameTitle"]);
                mTotalPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["totalPrice"]);
                mDeliveryDate = Convert.ToDateTime(DB.DataTable.Rows[0]["deliveryDate"]);
                mShipment = Convert.ToBoolean(DB.DataTable.Rows[0]["shipment"]);

                return true;
            }
            else //else return that ID was not found
            {
                return false;
            }
        }

        public string Valid(string gameTitle, string totalPrice, string deliveryDate)
        {
            String Error = ""; //checking if all variables are valid

            DateTime DateTemp;

            Decimal someTotalPrice;

            if (gameTitle.Length == 0)
            {
                Error = Error + "The game title may not be blank : ";
            }

            if (gameTitle.Length > 50)
            {
                Error = Error + "The game title must be less the 50 characters long : ";
            }

            if (totalPrice.Length == 0)
            {
                Error = Error + "The total price may not be blank : ";
            }



            try //try method as if statements could crash program
            {
                decimal i;
                bool result = decimal.TryParse(totalPrice, out i);

                if (i <= 0)
                {
                    Error = Error + "The Total Price cannot be negative : ";
                }
            }
            catch
            {
                Error = Error + "";
            }



            try
            {
                decimal i;
                bool result = decimal.TryParse(totalPrice, out i);  

                if (result == false)
                {
                    Error = Error + "The price must only contain numbers : ";
                }
            }
            catch
            {
                Error = Error + "";
            }

            try
            {
                DateTemp = Convert.ToDateTime(deliveryDate); //convert
                if (DateTemp < DateTime.Now.Date)
                {
                    Error = Error + "The Date cannot be in the past : ";
                }

                if (DateTemp > DateTime.Now.Date.AddYears(1))
                {
                    //record the error
                    Error = Error + "The date cannot be more then 1 year in the future : ";
                }
            }
            catch
            {
                Error = Error + "The Date was not a valid date : ";
            }

            return Error; //return blank if no error found or text if a error was found
        }
    }
}