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

        public bool Find(int AddressNo)
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("OrderId", OrderId);

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
    }
}