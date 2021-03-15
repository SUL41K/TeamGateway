using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class ACustomer : System.Web.UI.Page
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

            if(CustomerId == -1)
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
    }

    

  