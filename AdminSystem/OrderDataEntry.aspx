<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDataEntry.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="lstOrders" runat="server">
        <div style="margin-left: 280px">
            <p style="margin-left: 320px">
                Order Page</p>
        </div>
        <br />
        <asp:Label ID="lblOrderId" runat="server" Text="Order  ID: " height="27px" width="192px"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="txtOrderId" runat="server" height="27px" width="200px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
        <br />
        <asp:Label ID="lblGameTitle" runat="server" Text="Game Title: " height="27px" width="200px"></asp:Label>
        <asp:TextBox ID="txtGameTitle" runat="server" height="27px" width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price: " height="27px" width="200px"></asp:Label>
        <asp:TextBox ID="txtTotalPrice" runat="server" height="27px" width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="lblDeliveryDate" runat="server" Text="Delivery Date: " height="27px" width="200px"></asp:Label>
        <asp:TextBox ID="txtDeliveryDate" runat="server" height="27px" width="200px"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="chbShipment" runat="server" height="27px" Text="Shipment" TextAlign="Left" width="200px" OnCheckedChanged="chbShipment_CheckedChanged" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnApply_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    </form>
</body>
</html>
