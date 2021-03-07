using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsStockCollection
    {
        

        public clsStockCollection()
        {
            
        
            Int32 Index = 0;
            Int32 RecordCount = 0;
            clsDataConnection DB = new clsDataConnection();

            DB.Execute("sproc_tblStock_SelectAll");

            RecordCount = DB.Count;

            while (Index < RecordCount)
            {
                clsStock AnStock = new clsStock();

                AnStock.Availability = Convert.ToBoolean(DB.DataTable.Rows[Index]["Availability"]);
                AnStock.gameID = Convert.ToInt32(DB.DataTable.Rows[Index]["gameID"]);
                AnStock.gameName = Convert.ToString(DB.DataTable.Rows[Index]["gameName"]);
                AnStock.ReleaseDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["ReleaseDate"]);
                AnStock.Price = Convert.ToDecimal(DB.DataTable.Rows[Index]["Price"]);
                AnStock.AgeRating = Convert.ToInt32(DB.DataTable.Rows[Index]["AgeRating"]);

                mStockList.Add(AnStock);
                Index++;
                

        }
           
        }
        List<clsStock> mStockList = new List<clsStock>();


        public List<clsStock> StockList
        {
            get
            {
                return mStockList;
            }

            set
            {
                mStockList = value;
            }
        }



        public int Count
        {

            get
            {
                return mStockList.Count;
            }

            set
            {
                //forlater
}


        }
        public clsStock ThisStock { get; set; }
    }
}