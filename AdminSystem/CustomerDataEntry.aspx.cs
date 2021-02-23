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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        clsCustomer ACustomer = new clsCustomer();

        string CustomerName = txtCustomerName.Text;

        string CustomerEmail = txtCustomerEmail.Text;

        string CustomerDOB = txtCustomerDOB.Text;

        string CustomerId = txtCustomerID.Text;

        string Error = "";

        Error = ACustomer.Valid(CustomerName, CustomerEmail, CustomerDOB, CustomerId);

        if (Error == "")
        {
            ACustomer.CustomerName = CustomerName;
            ACustomer.CustomerEmail = CustomerEmail;
            ACustomer.CustomerDOB = Convert.ToDateTime(CustomerDOB);

            Session["ACustomer"] = ACustomer;
            Response.Write("CustomerViewer.aspx");

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