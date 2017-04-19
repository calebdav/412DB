﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerPage.aspx.cs" Inherits="HumanResources.ManagerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/ViewUnapprovedTimesheets.aspx" Text="View Unapproved Timesheets" Value="View Unapproved Timesheets"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewProjects.aspx" Text="View Projects" Value="View Projects"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewEmployees.aspx" Text="View Employees" Value="View Employees"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewSpecialReports.aspx" Text="View Special Reports" Value="View Special Reports"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LoginPage.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <asp:Label ID="WelcomeLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>