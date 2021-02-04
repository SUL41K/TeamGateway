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
        <asp:Label ID="lblOrderId" runat="server" Text="OrderID: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
        <asp:TextBox ID="txtOrderId" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblGameTitle" runat="server" Text="Game Title: " height="27px" width="189px"></asp:Label>
        <asp:TextBox ID="txtGameTitle" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price: " height="27px" width="189px"></asp:Label>
        <asp:TextBox ID="txtTotalPrice" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDeliveryDate" runat="server" Text="Delivery Date: " height="27px" width="189px"></asp:Label>
        <asp:TextBox ID="txtDeliveryDate" runat="server"></asp:TextBox>
        <br />
        <asp:CheckBox ID="chbAvailability" runat="server" height="27px" Text="Availability" TextAlign="Left" width="161px" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnApply" runat="server" Text="Apply" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEdit" runat="server" Text="Edit" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    </form>
</body>
</html>
