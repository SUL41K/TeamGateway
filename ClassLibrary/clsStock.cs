using System;

namespace ClassLibrary
{
    public class clsStock
    {
        public int gameID { get; set; }
        public string gameName { get; set; }
        public bool Availability { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public int AgeRating { get; set; }

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
    }
}
