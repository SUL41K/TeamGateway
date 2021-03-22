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

        //creates a new instance of stockCollection
        clsStockCollection Stocks = new clsStockCollection();
        //set the data source to the list of stock
        lstStockList.DataSource = Stocks.StockList;
        //set primary key
        lstStockList.DataValueField = "gameID";
        //set selected field to display
        lstStockList.DataTextField = "gameName";
        //binds the data to the list
        lstStockList.DataBind();

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //store -1 in the session to convey a new record
        Session["gameID"] = -1;
        //redirect to data entry page
        Response.Redirect("StockDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // create Int32 for gameID varible
        Int32 gameID;

        //IF statement to see if a name has been selected
        if (lstStockList.SelectedIndex != -1)
        {
            //Convert gameID into Int32
            gameID = Convert.ToInt32(lstStockList.SelectedValue);
            //store the data in the session object
            Session["gameID"] = gameID;
            //redirect to data entry page
            Response.Redirect("StockDataEntry.aspx");

        }

        else
        {
            //Displays error message
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // create Int32 for gameID varible
        Int32 gameID;
        //checks if record has been selected from the list
        if (lstStockList.SelectedIndex != -1)
        {
            //Convert gameID into Int32
            gameID = Convert.ToInt32(lstStockList.SelectedValue);
            //store the data in the session object
            Session["gameID"] = gameID;
            //redirect to delete page
            Response.Redirect("DeleteStock.aspx");
        }
        else
        {
            //Displays error message
            lblError.Text = "Please Select a record to delete from the list";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        //create new instance of stock collection
        clsStockCollection Stocks = new clsStockCollection();
        //implemented the filtered attribute
        Stocks.ReportBygameName(txtFilter.Text);
        //see data source to stockList
        lstStockList.DataSource = Stocks.StockList;
        //Select primary key
        lstStockList.DataValueField = "gameID";
        //set game name to filed display
        lstStockList.DataTextField = "gameName";
        //bind data
        lstStockList.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //create new instance of stock collection
        clsStockCollection Stocks = new clsStockCollection();
        Stocks.ReportBygameName("");
        //sets text field to empty
        txtFilter.Text = "";
        //see data source to stockList
        lstStockList.DataSource = Stocks.StockList;
        //displays primary key enteries back into list
        lstStockList.DataValueField = "gameID";
        //displays name field
        lstStockList.DataTextField = "gameName";
        //binds data
        lstStockList.DataBind();
    }
}


