using System;

namespace ClassLibrary
{
    public class clsOrder
    {
        public int OrderId { get; set; }
        public string GameTitle { get; set; }
        public String TotalPrice { get; set; }
        public int DeliveryDate { get; set; }          //should be changed to datetime datatype
        public Boolean Availability { get; set; }

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
    }
}