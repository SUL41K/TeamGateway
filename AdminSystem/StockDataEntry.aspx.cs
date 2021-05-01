using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    // page scope variable implemented to assign Int32 to primary key
    Int32 gameID;
    protected void Page_Load(object sender, EventArgs e)
    {
        gameID = Convert.ToInt32(Session["gameID"]);

        if (IsPostBack == false)
        {
            if (gameID != -1)
            {
                DisplayStock();
            }
        }
    }

    private void DisplayStock()
    {
        //creates new instant of Stock collection class
        clsStockCollection StockBook = new clsStockCollection();
        //Finds gameID and updates all textboxes & textboxes to show relevant attributes
        StockBook.ThisStock.Find(gameID);
        txtGameID.Text = StockBook.ThisStock.gameID.ToString();
        txtGameName.Text = StockBook.ThisStock.gameName;
        txtPrice.Text = StockBook.ThisStock.Price.ToString();
        txtAgeRating.Text = StockBook.ThisStock.AgeRating.ToString();
        txtDate.Text = StockBook.ThisStock.ReleaseDate.ToString();
        chkAvailable.Checked = StockBook.ThisStock.Availability;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {

        //create new instance of clsStock
        clsStock AnStock = new clsStock();
        //create a string variables of all textboxes that can be updated
        string gameName = txtGameName.Text;

        string ReleaseDate = txtDate.Text;

        string Price = txtPrice.Text;

        string AgeRating = txtAgeRating.Text;


        //create test data for error message
        string Error = "";

        //implements valid method to string variable
        Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);

        if (Error == "")
        {

            //captures all of the attributes of the stock
            AnStock.gameID = gameID;
            AnStock.gameName = gameName;
            AnStock.ReleaseDate = Convert.ToDateTime(ReleaseDate);
            AnStock.Price = Convert.ToDecimal(Price);
            AnStock.AgeRating = Convert.ToInt32(AgeRating);
            AnStock.Availability = chkAvailable.Checked;

            clsStockCollection StockList = new clsStockCollection();

            //checks for a new record. For example -1
            if (gameID == -1)
            {
                StockList.ThisStock = AnStock;
                //adds new stock using the add method
                StockList.Add();
            }

            else
            {
                StockList.ThisStock.Find(gameID);
                StockList.ThisStock = AnStock;
                //if statement to view if record exists then updates the stock
                StockList.Update();
            }

            //navigate to the viewer page
            Response.Redirect("StockList.aspx");

        }

        else
        {
            //else statement to convey error message
            lblError.Text = Error;
        }
    }



    
    protected void chkAvailable_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        //creates new instance of clsStock
        clsStock AnStock = new clsStock();
        Int32 gameID;
        Boolean Found = false;
        //convert gameID textbox into the Int32 Data Type
        gameID = Convert.ToInt32(txtGameID.Text);
        Found = AnStock.Find(gameID);
        //if statement. If found to be true then it updates the details
        if (Found == true)
        {
            txtGameID.Text = AnStock.gameID.ToString();
            txtGameName.Text = AnStock.gameName;
            txtAgeRating.Text = AnStock.AgeRating.ToString();
            txtPrice.Text = AnStock.Price.ToString();
            txtDate.Text = AnStock.ReleaseDate.ToString();
        }

        //if data is not found then open up a error message
        else if (Found == false)
        {
            //message to convey record not found
            System.Windows.Forms.MessageBox.Show("This record does not exist");
        }

    }

    protected void txtAgeRating_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StockList.aspx");
    }
}

