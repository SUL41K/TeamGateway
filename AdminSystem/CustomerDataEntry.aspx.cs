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
        clsCustomerCollection CustomerBook = new clsCustomerCollection();

        CustomerBook.ThisCustomer.Find(CustomerId);
        txtCustomerID.Text = CustomerBook.ThisCustomer.CustomerId.ToString();
        txtCustomerEmail.Text = CustomerBook.ThisCustomer.CustomerEmail;
        txtCustomerName.Text = CustomerBook.ThisCustomer.CustomerName;
        txtCustomerDOB.Text = CustomerBook.ThisCustomer.CustomerDOB.ToString();
        chkCustomerSubscribe.Checked = CustomerBook.ThisCustomer.CustomerSubscribe;

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        clsCustomer ACustomer = new clsCustomer();

        string CustomerName = txtCustomerName.Text;

        string CustomerEmail = txtCustomerEmail.Text;

        string CustomerDOB = txtCustomerDOB.Text;

        string Error = "";

        Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB);

        if (Error == "")
        {
            ACustomer.CustomerId = CustomerId;
            ACustomer.CustomerName = CustomerName;
            ACustomer.CustomerEmail = CustomerEmail;
            ACustomer.CustomerDOB = Convert.ToDateTime(CustomerDOB);
            ACustomer.CustomerSubscribe = chkCustomerSubscribe.Checked;
            clsCustomerCollection CustomerList = new clsCustomerCollection();

            if (CustomerId == -1)
            {
                CustomerList.ThisCustomer = ACustomer;
                CustomerList.Add();
            }

            else
            {
                CustomerList.ThisCustomer.Find(CustomerId);
                CustomerList.ThisCustomer = ACustomer;
                CustomerList.Update();
            }

            Response.Redirect("CustomerList.aspx");

        }
        else
        {
            lblError.Text = Error;
        }




    }

    protected void chkCustomerSubscribe_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {

        
        clsCustomer ACustomer = new clsCustomer();

        Int32 CustomerId;

        Boolean Found = false;

        CustomerId = Convert.ToInt32(txtCustomerID.Text);

        Found = ACustomer.Find(CustomerId);


        if (Found == true)
        {
            txtCustomerDOB.Text = ACustomer.CustomerDOB.ToString();
            txtCustomerEmail.Text = ACustomer.CustomerEmail;
            txtCustomerName.Text = ACustomer.CustomerName;

        }

        else if (Found == false)
        {
            System.Windows.Forms.MessageBox.Show("This record does not exist");
        }

        

}


}