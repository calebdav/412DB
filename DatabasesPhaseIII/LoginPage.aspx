<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="HumanResources.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Welcome to the Human Resources for your business!<br />
        Please log in.</div>
        <asp:Panel ID="LoginPanel" runat="server" HorizontalAlign="Left">
            <asp:Label ID="UserIDLabel" runat="server" Text="UserID: " Width="100px"></asp:Label>
            <asp:TextBox ID="UserIDTextBox" runat="server" style="text-align: left" Width="100px"></asp:TextBox>
            <br />
            <asp:Label ID="PasswordLabel" runat="server" Text="Password: " Width="100px"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server" Width="100px" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" style="width: 53px" Text="Log in" />
            <br />
            <asp:Label ID="StatusLabel" runat="server" style="font-weight: 700"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
