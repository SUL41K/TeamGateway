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
        clsOrder AnOrder = new clsOrder();
        AnOrder = (clsOrder)Session["AnOrder"];
        Response.Write(AnOrder.OrderId);
        Response.Write("<br>");
        Response.Write(AnOrder.GameTitle);
        Response.Write("<br>");
        Response.Write(AnOrder.TotalPrice);
        Response.Write("<br>");
        Response.Write(AnOrder.DeliveryDate);
        Response.Write("<br>");
        Response.Write(AnOrder.Shipment);
    }
}