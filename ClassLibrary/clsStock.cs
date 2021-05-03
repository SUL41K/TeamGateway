using System;

namespace ClassLibrary
{
    public class clsStock
    {

        //private data member for the GameID
        private Int32 mGameID;
        //private data member for the gameName
        private String mgameName;
        //private data member for the ReleaseDate
        private DateTime mReleaseDate;
        //private data member for the AgeRating
        private Int32 mAgeRating;
        //private data member for the Price
        private Decimal mPrice;
        //private data member for the Availability
        private Boolean mAvailability;

        

    //getter and setter returns GameID
        public Int32 gameID
        {
            get
            {
                //return GameID
                return mGameID;
            }
            set
            {
                //setGameID
                mGameID = value;
            }
        }

        //getter and setter returns gameName
        public String gameName
        {
            get
            {
                //return gameName
                return mgameName;
            }
            set
            {
                //set gameName
                mgameName = value;
            }
        }


        //getter and setter returns releaseDate
        public DateTime ReleaseDate
        {
            get
            {
                //return ReleaseDate
                return mReleaseDate;
            }
            set
            {
                //Set ReleaseDate
                mReleaseDate = value;
            }
        }


        //Method created for validation to ensure the correct data is being inputted
        public string Valid(string gameName, string price, string ageRating, string releaseDate)
        {

        //Declaring empty string for an error message
            String Error = "";

        //Date and time variables created to allow for date and time parameters to be set
            DateTime DateTemp;
            DateTime DateMin;


           //If the name is empty
            if (gameName.Length == 0)
            {
            //output error message
                Error = Error + "The game name may not be blank : ";
            }

            //If statement to ensure game length does not exceed 30 characters in length
            if (gameName.Length > 30)
            {
            //Error message indicating error
                Error = Error + "The name must not exceed more than 30 characters : ";
            }


            try
            {
            //If statement to ensure the price does not equal to 0
                if (Convert.ToDecimal(price) == 0)
            {
            //output error message
                    Error = Error + "The price cannot be free or nothing : ";
            }
            
            //If statement for to ensure the price does not exceed the value of 100
            if (Convert.ToDecimal(price) > 100)
                {
                //output error message
                    Error = Error + "The price for this game is too high! Price must not exceed 100 : ";
                }
                
            }
            catch
            {
            //ensure the price field is not empty
                Error = Error + "Please enter a value for price : ";
            }

            try
            {
               //Variable to ensire the release date is converted to date and time
                DateTemp = Convert.ToDateTime(releaseDate);
                //Minimum date variable
                DateMin = new DateTime(2001,01,01);

                //If method to sure the date does not go further in the past than 2001
                if (DateTemp < DateMin)
                {
                //Error message outputed to showcase error
                    Error = Error + "The date cannot be before 2001 : ";

                }

                //If statement to ensure that the release date is not in the future
                if (DateTemp > DateTime.Now.Date)
                {
                //Error message outputted to showcase error
                    Error = Error + "The date cannot be in the future : ";
                }

            }

            catch
            {
                //Error message if valid date is not entered
                Error = Error + "Please enter a valid date :  ";
            }


            try
            {
            //If statement to ensure the agerating is not lower than 3
                if (Convert.ToInt32(ageRating) < 3)
                {
              //Error message outputted to showcase error
                    Error = Error + "The age may not be less than 3  : ";
                }
            //If statement to ensure that the age rating does not exceed 18
                if (Convert.ToInt32(ageRating) > 18)
                {
                //Error outputted otherwise
                    Error = Error + "Age must not be more than 18 : ";
                }

            }
            catch
            {
            //Error message if value is not entered for age rating
                Error = Error + "Please enter a value for the Age Rating : ";
            }
            return Error;
        }
        

        //getter and Setter for age rating returns age rating
        public Int32 AgeRating
        {
            get
            {
                //return AgeRating
                return mAgeRating;
            }
            set
            {
                //set AgeRating
                mAgeRating = value;
            }
        }

        //getter and setter for price returns price
        public Decimal Price
        {
            get
            {
                //return Price
                return mPrice;
            }
            set
            {
                //set Price
                mPrice = value;
            }
        }


        //getter and setter for availability returns boolean value
        public Boolean Availability
        {
            get
            {
                //return Availablity
                return mAvailability;
            }
            set
            {
                //set Availablity
                mAvailability = value;
            }
        }

        public string Valid(string gGameName)
        {
            if (gGameName.Length < 1)
            {
                return "GameName cannot be blank";
            }

            if (gGameName.Length > 30)
            {
                return "GameName cannot be exceed 30 characters";
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
            //returns all of the found data attributes into each field
                return true;

            }

            else
            {
                return false;
            }

          
        }
    }
}
