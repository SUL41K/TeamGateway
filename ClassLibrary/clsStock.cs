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

        public string Valid(string gameID, string gameName, string price, string ageRating, string releaseDate)
        {
            String Error = "";
            DateTime DateTemp;
            
            if (gameName.Length == 0)
            {
                Error = Error + "The game name may not be blank : ";
            }

            if (gameName.Length > 30)
            {
                Error = Error + "The name must not be less than 30 characters : ";
            }

            if (price.Length == 0)
            {
                Error = Error + "The total price may not be blank : ";
            }

            try
            {
                decimal i = 0;
                bool result = decimal.TryParse(price, out i);

                if (result == false)
                {
                    Error = Error + "Please enter numerical values : ";
                }
            }
            catch
            {
                Error = Error + "Incorrect Values entered : ";
            }
            try
            {
                DateTemp = Convert.ToDateTime(releaseDate);
                if (DateTemp < DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be past : ";

                }

                if (DateTemp > DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be in the future : ";
                }

            }

            catch
            {
                Error = Error + "The date was not a valid date : ";
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
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@gameID", gameID);
            DB.Execute("sproc_tblStock_FilterByGameID");

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
