<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUnapprovedTimesheets.aspx.cs" Inherits="HumanResources.ViewManagerTimesheets" %>

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
                <asp:MenuItem NavigateUrl="~/ManagerPage.aspx" Text="Manager Welcome Page" Value="Manager Welcome Page"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewProjects.aspx" Text="View Projects" Value="View Projects"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewEmployees.aspx" Text="View Employees" Value="View Employees"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewSpecialReports.aspx" Text="View Special Reports" Value="View Special Reports"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LoginPage.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
        Unapproved Timesheets<br />
        <br />
        Mon&nbsp;&nbsp;&nbsp; Tue&nbsp;&nbsp;&nbsp; Wed&nbsp;&nbsp;&nbsp; Thu&nbsp;&nbsp;&nbsp; Fri&nbsp;&nbsp;&nbsp; Week Of&nbsp;&nbsp;&nbsp; Employee ID<br />
        <asp:ListBox ID="TimesheetListBox" runat="server" OnSelectedIndexChanged="TimesheetListBox_SelectedIndexChanged" Rows="10"></asp:ListBox>
        <br />
        <asp:Button ID="ApproveButton" runat="server" OnClick="ApproveButton_Click" Text="Approve" />
        <br />
        <asp:Label ID="StatusLabel" runat="server" style="font-weight: 700"></asp:Label>
    </form>
</body>
</html>
