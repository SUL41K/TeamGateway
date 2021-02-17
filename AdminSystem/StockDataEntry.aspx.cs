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
      
        AnStock.gameName = txtGameName.Text; 
        Session["AnStock"] = AnStock;

        AnStock.gameID = Convert.ToInt32(txtGameID.Text);
        Session["AnStock"] = AnStock;

        AnStock.ReleaseDate = Convert.ToDateTime(txtDate.Text);
        Session["AnStock"] = AnStock;

        AnStock.Price = Convert.ToDecimal(txtPrice.Text);
        Session["AnStock"] = AnStock;

        AnStock.AgeRating = Convert.ToInt32(txtAgeRating.Text);
        Session["AnStock"] = AnStock;

        AnStock.Availability= chkAvailable.Checked;
        Session["AnStock"] = AnStock;

        //navigate to the viewer page
        Response.Redirect("StockViewer.aspx");
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

