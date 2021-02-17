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

        AnOrder.OrderId = Convert.ToInt32(txtOrderId.Text);
        AnOrder.GameTitle = txtGameTitle.Text;
        AnOrder.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
        AnOrder.DeliveryDate = Convert.ToDateTime(txtDeliveryDate.Text);
        AnOrder.Shipment = chbShipment.Checked;

        Session["AnOrder"] = AnOrder;
        Response.Redirect("OrderViewer.aspx");
    }



    protected void chbShipment_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }



    protected void btnFind_Click(object sender, EventArgs e)
    {
        clsOrder AnOrder = new clsOrder();

        Int32 OrderId;
        Boolean Found = false;

        OrderId = Convert.ToInt32(txtOrderId.Text);

        Found = AnOrder.Find(OrderId);

        if (Found == true)
        {
            txtGameTitle.Text = AnOrder.GameTitle;
            txtTotalPrice.Text = AnOrder.TotalPrice.ToString();
            txtDeliveryDate.Text = AnOrder.DeliveryDate.ToString();
            chbShipment.Checked = AnOrder.Shipment;

        }
    }
}