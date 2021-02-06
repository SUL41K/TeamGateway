using System;

namespace ClassLibrary
{
    public class clsCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CustomerDOB { get; set; }          //should be changed to datetime datatype
        public Boolean CustomerForm { get; set; }

        public string Valid(string cCustomerName)
        {
            if (cCustomerName.Length < 1)
            {
                return "description cannot be blank";
            }

            if (cCustomerName.Length > 50)
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
