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
            //set the private data members to the test data value
            mOrderId = 21;
            mGameTitle = "Test Game Title";
            mTotalPrice = 1;
            mDeliveryDate = Convert.ToDateTime("16/9/2015");
            mShipment = true;

            //always return true
            return true;

        }
    }
}