using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsOrderCollection
    {
        List<clsOrder> mOrderList = new List<clsOrder>();

        clsOrder mThisOrder = new clsOrder();

        public List<clsOrder> OrderList //get and set methods
        {
            get
            {
                return mOrderList;
            }
            set
            {
                mOrderList = value;
            }
        }
        public int Count
        {
            get
            {
                return mOrderList.Count;
            }
            set
            {
                //todo
            }
        }

        public clsOrder ThisOrder
        {
            get
            {
                return mThisOrder;
            }
            set
            {
                mThisOrder = value;
            }
        }

        public clsOrderCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblOrder_SelectAll"); //execute procedure to show all
            PopulateArray(DB);
        }

        public int Add() //add all changes that were input
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@GameTitle", mThisOrder.GameTitle);
            DB.AddParameter("@TotalPrice", mThisOrder.TotalPrice);
            DB.AddParameter("@DeliveryDate", mThisOrder.DeliveryDate);
            DB.AddParameter("@Shipment", mThisOrder.Shipment);

            return DB.Execute("sproc_tblOrder_Insert"); //redirect
            
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection(); //update all attributes input by user

            DB.AddParameter("@orderID", mThisOrder.orderID);
            DB.AddParameter("@GameTitle", mThisOrder.GameTitle);
            DB.AddParameter("@TotalPrice", mThisOrder.TotalPrice);
            DB.AddParameter("@DeliveryDate", mThisOrder.DeliveryDate);
            DB.AddParameter("@Shipment", mThisOrder.Shipment);

            DB.Execute("sproc_tblOrder_Update");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("orderID", mThisOrder.orderID);
            DB.Execute("sproc_tblOrder_Delete"); //add paramiter to delete using this procedure
        }

        public void ReportByGameTitle(string GameTitle)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@GameTitle", GameTitle);
            DB.Execute("sproc_tblOrder_FilterByGameTitle");
            PopulateArray(DB); //filter by game title and show it
        }

        void PopulateArray(clsDataConnection DB)
        {
            Int32 Index = 0;
            Int32 RecordCount;
            RecordCount = DB.Count;
            mOrderList = new List<clsOrder>();

            while (Index < RecordCount)
            {
                clsOrder AnOrder = new clsOrder();

                AnOrder.orderID = Convert.ToInt32(DB.DataTable.Rows[Index]["orderID"]);
                AnOrder.GameTitle = Convert.ToString(DB.DataTable.Rows[Index]["gameTitle"]);
                AnOrder.TotalPrice = Convert.ToDecimal(DB.DataTable.Rows[Index]["totalPrice"]);
                AnOrder.DeliveryDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["deliveryDate"]);
                AnOrder.Shipment = Convert.ToBoolean(DB.DataTable.Rows[Index]["shipment"]);

                mOrderList.Add(AnOrder); //add all attributes and give ID +1 to make a new Order
                Index++;
            }
        }
    }

}
