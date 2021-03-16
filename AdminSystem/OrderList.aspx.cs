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
            DisplayOrders();
        }
    }

    void DisplayOrders()
    {
        clsOrderCollection Orders = new clsOrderCollection();
        LstOrders.DataSource = Orders.OrderList;
        LstOrders.DataValueField = "OrderID";
        LstOrders.DataValueField = "OrderID";
        LstOrders.DataBind();
        
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["OrderId"] = -1;
        Response.Redirect("OrderDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Int32 OrderID;

        if (LstOrders.SelectedIndex != -1)
        {
            OrderID = Convert.ToInt32(LstOrders.SelectedValue);
            Session["OrderID"] = OrderID;
            Response.Redirect("OrderDataEntry.aspx");
        }
        else
        {
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    protected void LstOrders_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}