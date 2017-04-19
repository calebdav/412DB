<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="HumanResources.EmployeePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem NavigateUrl="~/ViewTimesheets.aspx" Text="View Timesheets" Value="View Timesheets"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/SubmitNewTimesheet.aspx" Text="Submit New Timesheet" Value="Submit New Timesheet"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LoginPage.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <asp:Label ID="WelcomeLabel" runat="server"></asp:Label>
        <br />
    
        </div>
    </form>
</body>
</html>
