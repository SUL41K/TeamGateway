using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            DisplayCustomers();
        }

    }

    void DisplayCustomers()
    {
        //create new instance of customer collection
        clsCustomerCollection Customers = new clsCustomerCollection();
        //set the data source to the list of customers
        lstCustomerList.DataSource = Customers.CustomerList;
        //set the name of the primary key
        lstCustomerList.DataValueField = "CustomerId";
        //set the field to display
        lstCustomerList.DataTextField = "CustomerName";
        //bind the data to the list
        lstCustomerList.DataBind();

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //store -1 in the session to indicate it is a new record
        Session["customerId"] = -1;
        //redirect to the customer data entry
        Response.Redirect("CustomerDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //create Int32 customerId variable to apply to button event
        Int32 CustomerId;

        //checks to see if a name form the list has been selected
        if (lstCustomerList.SelectedIndex != -1)
        {
            //converts ID to Int32
            CustomerId = Convert.ToInt32(lstCustomerList.SelectedValue);
            //store the data in the session object
            Session["customerId"] = CustomerId;
            //redirect to customer data entry
            Response.Redirect("CustomerDataEntry.aspx");

        }

        else
        {
            //update error label to display error message
            lblError.Text = "Please select a record to delete from the list";
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //int32 CustomerId variable created to apply to button event
        Int32 CustomerId;
        //check if a name has been selected from the list
        if (lstCustomerList.SelectedIndex != -1)
        {
            //convert customerId to int32 when selected
            CustomerId = Convert.ToInt32(lstCustomerList.SelectedValue);
            //store the data in session object
            Session["customerId"] = CustomerId;
            //redirect to delete customer page
            Response.Redirect("DeleteCustomer.aspx");

        }

        else
        {
            //update error label to display error message
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        //create new instance
        clsCustomerCollection Customers = new clsCustomerCollection();
        //applies the filtered attribute entered
        Customers.ReportByName(txtName.Text);
        //set data source to customer list
        lstCustomerList.DataSource = Customers.CustomerList;
        //Select the primary key from list
        lstCustomerList.DataValueField = "customerId";
        //set name field to display
        lstCustomerList.DataTextField = "customerName";
        //bind data to the list
        lstCustomerList.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //create new instance of customer collection class
        clsCustomerCollection Customers = new clsCustomerCollection();
        Customers.ReportByName("");
        //sets the text field back to blank
        txtName.Text = "";
        //sets the data source to customer list
        lstCustomerList.DataSource = Customers.CustomerList;
        //displays primary key entries back into the list
        lstCustomerList.DataValueField = "customerId";
        //displays name field in list
        lstCustomerList.DataTextField = "customerName";
        //binds data to the list
        lstCustomerList.DataBind();
    }
}
    







