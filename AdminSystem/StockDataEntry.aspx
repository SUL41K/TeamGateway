<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblGameID" runat="server" Text="Game No:" width="90px"></asp:Label>
        <asp:TextBox ID="txtGameID" runat="server" Width="125px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblGameName" runat="server" Text="Game Name:" width="90px"></asp:Label>
        <asp:TextBox ID="txtGameName" runat="server" width="125px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblDate" runat="server" Text="Release Date:" width="90px"></asp:Label>
        <asp:TextBox ID="txtDate" runat="server" width="125px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Price:" width="90px"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server" width="125px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblAgeRating" runat="server" Text="Age Rating:" width="90px"></asp:Label>
        <asp:TextBox ID="txtAgeRating" runat="server" width="125px"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="chkAvailable" runat="server" Text="Available" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </form>
</body>
</html>
