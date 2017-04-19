<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSpecialReports.aspx.cs" Inherits="HumanResources.ViewSpecialReports" %>

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
                <asp:MenuItem NavigateUrl="~/ViewUnapprovedTimesheets.aspx" Text="View Unapproved Timesheets" Value="View Unapproved Timesheets"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewProjects.aspx" Text="View Projects" Value="View Projects"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewEmployees.aspx" Text="View Employees" Value="View Employees"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LoginPage.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        Select a special report to view:<br />
        <asp:Button ID="Query12Button" runat="server" OnClick="Query12Button_Click" Text="New Employees Not From Chicago" />
        &nbsp;<asp:Button ID="CorrelatedNestedQueryButton" runat="server" OnClick="CorrelatedNestedQueryButton_Click" Text="Most Valuable Managers" />
        <br />
        <asp:Panel ID="Query12Panel" runat="server" Visible="False">
            Showing employees that aren&#39;t from Chicago that have fewer than 40 hours in their work history:<br /> ID&nbsp;&nbsp;&nbsp; First&nbsp;&nbsp;&nbsp; Last&nbsp;&nbsp;&nbsp; City<br />
            <asp:ListBox ID="Query12ListBox" runat="server"></asp:ListBox>
        </asp:Panel>
        </div>
        <asp:Panel ID="CorrelatedNestedQueryPanel" runat="server" Visible="False">
            Top ten managers by salary:<br /> First&nbsp;&nbsp;&nbsp; Last&nbsp;&nbsp;&nbsp; Address&nbsp;&nbsp;&nbsp; Salary<br />
            <asp:ListBox ID="ManagerBySalaryListBox" runat="server"></asp:ListBox>
        </asp:Panel>
    </form>
</body>
</html>
