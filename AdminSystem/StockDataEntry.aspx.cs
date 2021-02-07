using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        //create a new instance of clsStock
        clsStock AnStock = new clsStock();
        //Capture the gamename
        AnStock.gameName = txtGameName.Text;
        //Store the stock in the session object
        Session["AnStock"] = AnStock;

        AnStock.gameID = Convert.ToInt32(txtGameID.Text);
        Session["AnStock"] = AnStock;

        AnStock.ReleaseDate = Convert.ToDateTime(txtDate.Text);
        Session["AnStock"] = AnStock;

        AnStock.Price = Convert.ToInt32(txtPrice.Text);
        Session["AnStock"] = AnStock;


        AnStock.AgeRating = Convert.ToInt32(txtAgeRating.Text);
        Session["AnStock"] = AnStock;

        //navigate to the viewer page
        Response.Redirect("StockViewer.aspx");
    }
}