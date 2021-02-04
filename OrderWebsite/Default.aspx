<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="lstOrders" runat="server">
        <div>
            My Order Page</div>
        <asp:ListBox ID="lstOrder" runat="server" Height="240px" Width="304px"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="lblOrderId" runat="server" Text="Enter Name of game you want"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtGameName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnApply" runat="server" Text="Apply" />
        <asp:Button ID="btnDisplayAll" runat="server" Text="Display All" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    </form>
</body>
</html>
