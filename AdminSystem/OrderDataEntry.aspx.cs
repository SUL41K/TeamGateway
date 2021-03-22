using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _Default : System.Web.UI.Page
{
    Int32 orderID;

    protected void Page_Load(object sender, EventArgs e)
    {
        orderID = Convert.ToInt32(Session["OrderID"]);
        if (IsPostBack == false)
        {
            if (orderID != -1)
            {
                DisplayOrder();
            }
        }
    }

    private void DisplayOrder()
    {
        clsOrderCollection OrderBook = new clsOrderCollection();
        OrderBook.ThisOrder.Find(orderID);

        txtOrderId.Text = OrderBook.ThisOrder.orderID.ToString();
        txtGameTitle.Text = OrderBook.ThisOrder.GameTitle;
        txtTotalPrice.Text = OrderBook.ThisOrder.TotalPrice.ToString();
        txtDeliveryDate.Text = OrderBook.ThisOrder.DeliveryDate.ToString();
        chbShipment.Checked = OrderBook.ThisOrder.Shipment;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderConfirmDelete.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsOrder AnOrder = new clsOrder();

        string OrderId = txtOrderId.Text;
        string GameTitle = txtGameTitle.Text;
        string TotalPrice = txtTotalPrice.Text;
        string DeliveryDate = txtDeliveryDate.Text;
        string Shipment = chbShipment.Text;
        string Error = "";

        Error = AnOrder.Valid(GameTitle, TotalPrice, DeliveryDate);

        if (Error == "")
        {
            AnOrder.orderID = orderID;
            AnOrder.GameTitle = GameTitle;
            AnOrder.TotalPrice = Convert.ToDecimal(TotalPrice);
            AnOrder.Shipment = chbShipment.Checked;
            AnOrder.DeliveryDate = Convert.ToDateTime(DeliveryDate);

            clsOrderCollection OrderList = new clsOrderCollection();
            if (orderID == -1)
            {
                OrderList.ThisOrder = AnOrder;
                OrderList.Add();
            }
            else
            {
                OrderList.ThisOrder.Find(orderID);
                OrderList.ThisOrder = AnOrder;
                OrderList.Update();
            }
            Response.Redirect("OrderList.aspx");
        }
        else lblError.Text = Error;
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

    protected void txtTotalPrice_TextChanged(object sender, EventArgs e)
    {

    }
}