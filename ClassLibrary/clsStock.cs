using System;

namespace ClassLibrary
{
    public class clsStock
    {
      

        private Int32 mGameID;
        private String mgameName;
        private DateTime mReleaseDate;
        private Int32 mAgeRating;
        private Decimal mPrice;
        private Boolean mAvailability;

        

        public Int32 gameID
        {
            get
            {
                return mGameID;
            }
            set
            {
                mGameID = value;
            }
        }
        public String gameName
        {
            get
            {
                return mgameName;
            }
            set
            {
                mgameName = value;
            }
        }
        public DateTime ReleaseDate
        {
            get
            {
                return mReleaseDate;
            }
            set
            {
                mReleaseDate = value;
            }
        }

        public string Valid(string gameName, string price, string ageRating, string releaseDate)
        {
            String Error = "";
            DateTime DateTemp;

            DateTime DateMin;

            int MinAge = 2;


            if (gameName.Length == 0)
            {
                Error = Error + "The game name may not be blank : ";
            }

            if (gameName.Length > 30)
            {
                Error = Error + "The name must not be less than 30 characters : ";
            }


            try
            { 
            if (Convert.ToDecimal(price) == 0)
            {
                Error = Error + "The total price may not be blank : ";
            }
            if (Convert.ToDecimal(price) > 100)
                {
                    Error = Error + "The price for this game is too high!: ";
                }
                
            }
            catch
            {
                Error = Error + "Please enter a value for Price : ";
            }
            try
            {
                DateTemp = Convert.ToDateTime(releaseDate);
                DateMin = new DateTime(2001,01,01);
                if (DateTemp < DateMin)
                {
                    Error = Error + "The date cannot be before 2001 : ";

                }

                if (DateTemp > DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be in the future : ";
                }

            }

            catch
            {
                Error = Error + "Please enter a valid Date : ";
            }


            try
            {
                if (Convert.ToInt32(ageRating) < 3)
                {
                    Error = Error + "The age may not be less than 3  : ";
                }
                if (Convert.ToInt32(ageRating) > 18)
                {
                    Error = Error + "Age must not be more than 18 : ";
                }

            }
            catch
            {
                Error = Error + "Please enter a value for the Age Rating! : ";
            }
            return Error;
        }
        

        public Int32 AgeRating
        {
            get
            {
                return mAgeRating;
            }
            set
            {
                mAgeRating = value;
            }
        }
        public Decimal Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }

        public Boolean Availability
        {
            get
            {
                return mAvailability;
            }
            set
            {
                mAvailability = value;
            }
        }

        public string Valid(string gGameName)
        {
            if (gGameName.Length < 1)
            {
                return "description cannot be blank";
            }

            if (gGameName.Length > 50)
            {
                return "description cannot be more then 50 characters";
            }

            else
            {
                return "";
            }
        }

        public bool Find(int gameID)
        {

            //create new instance of the dataconnection class
            clsDataConnection DB = new clsDataConnection();
            //add gameID paramater to gameID field in DB
            DB.AddParameter("@gameID", gameID);
            //Execute relevant stored procedure
            DB.Execute("sproc_tblStock_FilterByGameID");

            //search & return all table fields if count is == 1
            if (DB.Count == 1)
            {
            mGameID = Convert.ToInt32(DB.DataTable.Rows[0]["gameID"]);
                mgameName = Convert.ToString(DB.DataTable.Rows[0] ["gameName"]);
            mReleaseDate = Convert.ToDateTime(DB.DataTable.Rows[0]["releaseDate"]);
            mAgeRating = Convert.ToInt32(DB.DataTable.Rows[0]["ageRating"]);
            mPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["Price"]);
            mAvailability = Convert.ToBoolean(DB.DataTable.Rows[0]["Availability"]);

            return true;

            }

            else
            {
                return false;
            }

          
        }
    }
}
