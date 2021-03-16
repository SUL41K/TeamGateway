﻿using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsOrderCollection
    {
        List<clsOrder> mOrderList = new List<clsOrder>();

        clsOrder mThisOrder = new clsOrder();

        public List<clsOrder> OrderList
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
            Int32 Index = 0;
            Int32 RecordCount = 0;
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblOrder_SelectAll");
            RecordCount = DB.Count;

            while (Index < RecordCount)
            {

                clsOrder AnOrder = new clsOrder();

                AnOrder.OrderId = Convert.ToInt32(DB.DataTable.Rows[Index]["orderID"]);
                AnOrder.GameTitle = Convert.ToString(DB.DataTable.Rows[Index]["gameTitle"]);
                AnOrder.TotalPrice = Convert.ToDecimal(DB.DataTable.Rows[Index]["totalPrice"]);
                AnOrder.DeliveryDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["deliveryDate"]);
                AnOrder.Shipment = Convert.ToBoolean(DB.DataTable.Rows[Index]["shipment"]);

                mOrderList.Add(AnOrder);

                Index++;
            }





        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@GameTitle", mThisOrder.GameTitle);
            DB.AddParameter("@TotalPrice", mThisOrder.TotalPrice);
            DB.AddParameter("@DeliveryDate", mThisOrder.DeliveryDate);
            DB.AddParameter("@Shipment", mThisOrder.Shipment);

            return DB.Execute("sproc_tblOrder_Insert");
            
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@OrderID", mThisOrder.OrderId);
            DB.AddParameter("@GameTitle", mThisOrder.GameTitle);
            DB.AddParameter("@TotalPrice", mThisOrder.TotalPrice);
            DB.AddParameter("@DeliveryDate", mThisOrder.DeliveryDate);
            DB.AddParameter("@Shipment", mThisOrder.Shipment);

            DB.Execute("sproc_tblOrder_Update");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("OrderID", mThisOrder.OrderId);
            DB.Execute("sproc_tblOrder_Delete");
        }
    }

}
