<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblCustomerID" runat="server" Text="CustomerID" width="78px"></asp:Label>
        <asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find" />
        <p>
            <asp:Label ID="lblCustomerName" runat="server" Text="Name" width="78px"></asp:Label>
            <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblCustomerDOB" runat="server" Text="Date of Birth" width="78px"></asp:Label>
        <asp:TextBox ID="txtCustomerDOB" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lblCustomerEmail" runat="server" Text="Email" width="78px"></asp:Label>
            <asp:TextBox ID="txtCustomerEmail" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:CheckBox ID="chkCustomerSubscribe" runat="server" Text="Subscribe for updates" />
        </p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <p>
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Account" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </p>
    </form>
</body>
</html>
