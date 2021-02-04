using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderConfirmDelete.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsOrder AnOrder = new clsOrder();

        AnOrder.GameTitle = txtGameTitle.Text;
        Session["AnOrder"] = AnOrder;
        
        AnOrder.TotalPrice = txtTotalPrice.Text;
        Session["AnOrder"] = AnOrder;

        Response.Redirect("OrderViewer.aspx");
    }
}