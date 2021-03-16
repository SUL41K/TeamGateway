using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
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

    void DisplayStock()
    {
        clsStockCollection StockBook = new clsStockCollection();

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

        clsStock AnStock = new clsStock();

        string gameName = txtGameName.Text;

        string ReleaseDate = txtDate.Text;

        string Price = txtPrice.Text;

        string AgeRating = txtAgeRating.Text;



        string Error = "";

        Error = AnStock.Valid(gameName, Price, AgeRating, ReleaseDate);

        if (Error == "")
        {


            AnStock.gameID = gameID;
            AnStock.gameName = gameName;
            AnStock.ReleaseDate = Convert.ToDateTime(ReleaseDate);
            AnStock.Price = Convert.ToDecimal(Price);
            AnStock.AgeRating = Convert.ToInt32(AgeRating);
            AnStock.Availability = chkAvailable.Checked;

            clsStockCollection StockList = new clsStockCollection();

            if (gameID == -1)
            {
                StockList.ThisStock = AnStock;
                StockList.Add();
            }

            else
            {
                StockList.ThisStock.Find(gameID);
                StockList.ThisStock = AnStock;
                StockList.Update();
            }

            //navigate to the viewer page
            Response.Redirect("StockList.aspx");

        }

        else
        {
            lblError.Text = Error;
        }
    }



    
    protected void chkAvailable_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        clsStock AnStock = new clsStock();
        Int32 gameID;
        Boolean Found = false;
        gameID = Convert.ToInt32(txtGameID.Text);
        Found = AnStock.Find(gameID);
        if (Found == true)
        {
            txtGameID.Text = AnStock.gameID.ToString();
            txtGameName.Text = AnStock.gameName;
            txtAgeRating.Text = AnStock.AgeRating.ToString();
            txtPrice.Text = AnStock.Price.ToString();
            txtDate.Text = AnStock.ReleaseDate.ToString();
        }
        else if (Found == false)
        {
            System.Windows.Forms.MessageBox.Show("This record does not exist");
        }

    }
}

