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
           
            mGameID = 3;
            mgameName = "FIFA 21";
            mReleaseDate = Convert.ToDateTime("06/10/2020");
            mAgeRating = 3;
            mPrice = 60;
            mAvailability = true;
  
            return true;
        }
    }
}
