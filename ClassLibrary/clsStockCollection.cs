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

            PopulateArray(DB);

            while (Index < RecordCount)
            {
                clsStock AnStock = new clsStock();

                AnStock.Availability = Convert.ToBoolean(DB.DataTable.Rows[Index]["Availability"]);
                AnStock.gameID = Convert.ToInt32(DB.DataTable.Rows[Index]["gameID"]);
                AnStock.gameName = Convert.ToString(DB.DataTable.Rows[Index]["gameName"]);
                AnStock.ReleaseDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["releaseDate"]);
                AnStock.Price = Convert.ToDecimal(DB.DataTable.Rows[Index]["Price"]);
                AnStock.AgeRating = Convert.ToInt32(DB.DataTable.Rows[Index]["ageRating"]);

                mStockList.Add(AnStock);
                Index++;
                

        }
           
        }
        List<clsStock> mStockList = new List<clsStock>();
        clsStock mThisStock = new clsStock();

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
        public clsStock ThisStock
        {
            get
            {
                return mThisStock;
            }
            set
            {
                mThisStock = value;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@gameName", mThisStock.gameName);
            DB.AddParameter("@Availability", mThisStock.Availability);
            DB.AddParameter("@ageRating", mThisStock.Availability);
            DB.AddParameter("@Price", mThisStock.Price);
            DB.AddParameter("@releaseDate", mThisStock.ReleaseDate);
            return DB.Execute("sproc_tblStock_Insert");
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@gameID", mThisStock.gameID);
            DB.AddParameter("@gameName", mThisStock.gameName);
            DB.AddParameter("@Availability", mThisStock.Availability);
            DB.AddParameter("@ageRating", mThisStock.Availability);
            DB.AddParameter("@Price", mThisStock.Price);
            DB.AddParameter("@releaseDate", mThisStock.ReleaseDate);
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@gameID", mThisStock.gameID);
            DB.Execute("sproc_tblStock_Delete");
        }

        public void ReportBygameName(string gameName)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@gameName", gameName);
            DB.Execute("sproc_tblStock_FilteredByGameName");
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            Int32 Index = 0;
            Int32 RecordCount;
            RecordCount = DB.Count;
            mStockList = new List<clsStock>();
            while (Index < RecordCount)
            {
                clsStock AnStock = new clsStock();

                AnStock.Availability = Convert.ToBoolean(DB.DataTable.Rows[Index]["Availability"]);
                AnStock.gameID = Convert.ToInt32(DB.DataTable.Rows[Index]["gameID"]);
                AnStock.gameName = Convert.ToString(DB.DataTable.Rows[Index]["gameName"]);
                AnStock.ReleaseDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["releaseDate"]);
                AnStock.Price = Convert.ToDecimal(DB.DataTable.Rows[Index]["Price"]);
                AnStock.AgeRating = Convert.ToInt32(DB.DataTable.Rows[Index]["ageRating"]);

                mStockList.Add(AnStock);
                Index++;





            }
        }

    }
}