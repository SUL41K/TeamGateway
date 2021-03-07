using System;

namespace ClassLibrary
{
    public class clsOrder
    {
        private int mOrderId;
        private string mGameTitle;
        private Decimal mTotalPrice;
        private DateTime mDeliveryDate;
        private Boolean mShipment;

        public int OrderId
        {
            get
            {
                return mOrderId;
            }
            set
            {
                mOrderId = value;
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

        public bool Active { get; set; }

        public string Valid(string gGameTitle)
        {
            if (gGameTitle.Length < 1)
            {
                return "description cannot be blank";
            }

            if (gGameTitle.Length > 50)
            {
                return "description cannot be more then 50 characters";
            }

            else
            {
                return "";
            }
        }

        public bool Find(int OrderId)
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("OrderId", OrderId);

            DB.Execute("sproc_tblOrder_FilterByOrderId");

            if (DB.Count == 1)
            {

                mOrderId = Convert.ToInt32(DB.DataTable.Rows[0]["orderId"]);
                mGameTitle = Convert.ToString(DB.DataTable.Rows[0]["gameTitle"]);
                mTotalPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["totalPrice"]);
                mDeliveryDate = Convert.ToDateTime(DB.DataTable.Rows[0]["deliveryDate"]);
                mShipment = Convert.ToBoolean(DB.DataTable.Rows[0]["shipment"]);

                return true;
            }
            else
            {
                return false;
            }
        }

        public string Valid(string gameTitle, string totalPrice, string deliveryDate)
        {
            String Error = "";

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



            try
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
                DateTemp = Convert.ToDateTime(deliveryDate);
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

            return Error;
        }
    }
}