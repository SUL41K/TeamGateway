<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteCustomer.aspx.cs" Inherits="DeleteCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Are you sure you want to delete this record?<br />
            <br />
        </div>
        <asp:Button ID="btnYes" runat="server" OnClick="Button1_Click" Text="Yes" Width="41px" />
        <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" />
    </form>
</body>
</html>
