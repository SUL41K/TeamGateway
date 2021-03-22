using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class DeleteStock : System.Web.UI.Page
{
    //gameID variable at page scope to ensure it is applied to entire page
    Int32 gameID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //gameID is converted to Int and applied to session(database)
        gameID = Convert.ToInt32(Session["gameID"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        //create new instance of stock collection
        clsStockCollection StockBook = new clsStockCollection();
        StockBook.ThisStock.Find(gameID);
        //invoke the delete method
        StockBook.Delete();
        //redirect user to stocklist
        Response.Redirect("StockList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //redirect to stock list on input
        Response.Redirect("StockList.aspx");
    }
}