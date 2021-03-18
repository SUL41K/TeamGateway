using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class _1_DataEntry : System.Web.UI.Page
{
    //page scope variable to make sure CustomerId is Int32
    Int32 CustomerId;

    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerId = Convert.ToInt32(Session["customerId"]);
        if (IsPostBack == false)
        {
            if (CustomerId != -1)
            {
                DisplayCustomer();
            }
        }

    }

    void DisplayCustomer()
    {
        //create new instance of customer collection class
        clsCustomerCollection CustomerBook = new clsCustomerCollection();
        //find customer Id and updates all textboxes and checkbox to show the attributes of that customer
        CustomerBook.ThisCustomer.Find(CustomerId);
        txtCustomerID.Text = CustomerBook.ThisCustomer.CustomerId.ToString();
        txtCustomerEmail.Text = CustomerBook.ThisCustomer.CustomerEmail;
        txtCustomerName.Text = CustomerBook.ThisCustomer.CustomerName;
        txtCustomerDOB.Text = CustomerBook.ThisCustomer.CustomerDOB.ToString();
        chkCustomerSubscribe.Checked = CustomerBook.ThisCustomer.CustomerSubscribe;

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        //create new instance of clsCustomer
        clsCustomer ACustomer = new clsCustomer();
        //create string variables of textboxes so they can be updated
        string CustomerName = txtCustomerName.Text;

        string CustomerEmail = txtCustomerEmail.Text;

        string CustomerDOB = txtCustomerDOB.Text;
        //create test data for error message
        string Error = "";
        //Applies valid method to string variable
        Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);

        if (Error == "")
        {
            //captures all of the attributes of the customer
            ACustomer.CustomerId = CustomerId;
            ACustomer.CustomerName = CustomerName;
            ACustomer.CustomerEmail = CustomerEmail;
            ACustomer.CustomerDOB = Convert.ToDateTime(CustomerDOB);
            ACustomer.CustomerSubscribe = chkCustomerSubscribe.Checked;
            clsCustomerCollection CustomerList = new clsCustomerCollection();

            //checks if a new record i.e. -1 has been added
            if (CustomerId == -1)
            {
                CustomerList.ThisCustomer = ACustomer;
                //add new customer using add method
                CustomerList.Add();
            }

            else
            {
                CustomerList.ThisCustomer.Find(CustomerId);
                CustomerList.ThisCustomer = ACustomer;
                //if customer exists, then update selected customer
                CustomerList.Update();
            }

            //redirect to customer list
            Response.Redirect("CustomerList.aspx");

        }
        else
        {
            //Else display error message in error label
            lblError.Text = Error;
        }




    }

    protected void chkCustomerSubscribe_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {

        //create new instance of clsCustomer
        clsCustomer ACustomer = new clsCustomer();

        Int32 CustomerId;

        Boolean Found = false;
        //convert customerId textbox to int32 data type
        CustomerId = Convert.ToInt32(txtCustomerID.Text);

        Found = ACustomer.Find(CustomerId);

        //if record exists, update blank textboxes to customer's details
        if (Found == true)
        {
            txtCustomerDOB.Text = ACustomer.CustomerDOB.ToString();
            txtCustomerEmail.Text = ACustomer.CustomerEmail;
            txtCustomerName.Text = ACustomer.CustomerName;

        }

        //if not found then open a message box with error message
        else if (Found == false)
        {
            //pop up box shows and displays error message
            System.Windows.Forms.MessageBox.Show("This record does not exist");
        }

        

}



    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //redirect back to customer list
        Response.Redirect("CustomerList.aspx");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //make all text fields blank if any data is within them
        txtCustomerDOB.Text = "";
        txtCustomerEmail.Text = "";
        txtCustomerID.Text = "";
        txtCustomerName.Text = "";
        
    }
}