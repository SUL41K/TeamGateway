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

        ACustomer.CustomerName = txtCustomerName.Text;

        Session["ACustomer"] = ACustomer;

        ACustomer.CustomerEmail = txtCustomerEmail.Text;

        Session["ACustomer"] = ACustomer;

        ACustomer.CustomerId = Convert.ToInt32(txtCustomerID.Text);

        Session["ACustomer"] = ACustomer;

        ACustomer.CustomerDOB = Convert.ToDateTime(txtCustomerDOB.Text);

        Session["ACustomer"] = ACustomer;

        ACustomer.CustomerSubscribe = chkCustomerSubscribe.Checked;

        Session["ACustomer"] = ACustomer;



        Response.Redirect("CustomerViewer.aspx");

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