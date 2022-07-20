<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="asp.net_loginpage.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUserDetail" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnLogOut" runat="server" Text="Logout" OnClick="btnLogOut_Click" />
        </div>
    </form>
</body>
</html>
