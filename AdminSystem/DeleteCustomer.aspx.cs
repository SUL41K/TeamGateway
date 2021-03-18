using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class DeleteCustomer : System.Web.UI.Page
{
    //customerID variable at page scope to ensure the variable applies to entire page
    Int32 CustomerId;
    protected void Page_Load(object sender, EventArgs e)
    {
        //customerId is converted to Int and applied to customerId session (database)
        CustomerId = Convert.ToInt32(Session["customerId"]);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //create new instance of customer collection class
        clsCustomerCollection CustomerBook = new clsCustomerCollection();
        CustomerBook.ThisCustomer.Find(CustomerId);
        //invoke the delete method
        CustomerBook.Delete();
        //redirect to customer list once confirmed
        Response.Redirect("CustomerList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //redirect to customer list on click
        Response.Redirect("CustomerList.aspx");
    }
}