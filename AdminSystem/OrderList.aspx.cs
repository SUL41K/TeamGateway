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
        if (IsPostBack == false) //if a postback was made then load page
        {
            DisplayOrders();
        }
    }

    void DisplayOrders()
    {
        ClassLibrary.clsOrderCollection Orders = new ClassLibrary.clsOrderCollection();
        LstOrders.DataSource = Orders.OrderList;
        LstOrders.DataValueField = "OrderID";
        LstOrders.DataTextField = "GameTitle"; //display game titles on viewpage form
        LstOrders.DataBind(); //bind ID and titles

    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["OrderId"] = -1;  //set session to -1 to check for errors later
        Response.Redirect("OrderDataEntry.aspx"); //redirect
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Int32 OrderID;

        if (LstOrders.SelectedIndex != -1) //nothing should be selected so we can edit the variables
        {
            OrderID = Convert.ToInt32(LstOrders.SelectedValue);
            Session["OrderID"] = OrderID;
            Response.Redirect("OrderDataEntry.aspx");
        }
        else //write error text if this somehow happens
        {
            lblError.Text = "Please select a record to edit from the list";
        }
    }

    protected void LstOrders_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Int32 OrderID;

        if (LstOrders.SelectedIndex != -1) //if ID is not set proceed to delete
        {
            OrderID = Convert.ToInt32(LstOrders.SelectedValue);
            Session["OrderID"] = OrderID;
            Response.Redirect("OrderConfirmDelete.aspx");
        }
        else //error if something goes wrong
        {
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        clsOrderCollection Orders = new clsOrderCollection();
        Orders.ReportByGameTitle(txbGameTitle.Text); //sort by game title
        LstOrders.DataSource = Orders.OrderList;

        LstOrders.DataValueField = "OrderID";
        LstOrders.DataTextField = "GameTitle"; //filter by game title with stored name
        LstOrders.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clsOrderCollection Orders = new clsOrderCollection();
        Orders.ReportByGameTitle("");

        txbGameTitle.Text = "";
        LstOrders.DataSource = Orders.OrderList;

        LstOrders.DataValueField = "OrderID";
        LstOrders.DataTextField = "GameTitle"; //sort by unfiltered game titles
        LstOrders.DataBind();
    }
}