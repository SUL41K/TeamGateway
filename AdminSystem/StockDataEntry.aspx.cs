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

        clsStock AnStock = new clsStock();
        string gameID = txtGameID.Text;

        string gameName = txtGameName.Text;

        string ReleaseDate = txtDate.Text;

        string Price = txtPrice.Text;

        string AgeRating = txtAgeRating.Text;



        string Error = "";
        Error = AnStock.Valid(gameID, gameName, Price, AgeRating, ReleaseDate);
        if (Error == "")
        {
            AnStock.gameName = txtGameName.Text;

            AnStock.gameID = Convert.ToInt32(txtGameID.Text);


            AnStock.ReleaseDate = Convert.ToDateTime(txtDate.Text);


            AnStock.Price = Convert.ToDecimal(txtPrice.Text);


            AnStock.AgeRating = Convert.ToInt32(txtAgeRating.Text);


            AnStock.Availability = chkAvailable.Checked;
            Session["AnStock"] = AnStock;

            //navigate to the viewer page
            Response.Redirect("StockViewer.aspx");

        }

        else
            lblError.Text = Error;
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

