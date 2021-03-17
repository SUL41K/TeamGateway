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
            DisplayStock();
        }

    }

    void DisplayStock()
    {
        clsStockCollection Stocks = new clsStockCollection();
        lstStockList.DataSource = Stocks.StockList;
        lstStockList.DataValueField = "gameID";
        lstStockList.DataTextField = "gameName";
        lstStockList.DataBind();

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["gameID"] = -1;
        Response.Redirect("StockDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Int32 gameID;
        if (lstStockList.SelectedIndex != -1)
        {

            gameID = Convert.ToInt32(lstStockList.SelectedValue);
            Session["gameID"] = gameID;
            Response.Redirect("StockDataEntry.aspx");

        }

        else
        {
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Int32 gameID;
        if (lstStockList.SelectedIndex != -1)
        {
            gameID = Convert.ToInt32(lstStockList.SelectedValue);
            Session["gameID"] = gameID;
            Response.Redirect("DeleteStock.aspx");
        }
        else
        {
            lblError.Text = "Please Select a record to delete from the list";
        }
    }
}


